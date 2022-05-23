using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;

namespace ServiceMonitor
{
    public static class SystemInfo
    {
        private const string ExtractionFailed = "<Extraction Failed>";

        public static readonly string Caption;
        public static readonly string CSName;
        public static readonly string InstallDate;
        public static readonly string OSArchitecture;
        public static readonly string SerialNumber;
        public static readonly string Version;
        public static readonly long TotalVisibleMemorySize;
        public static readonly string CPUName;
        public static readonly DotNetFramework DotNetFrameworkVersion;

        static SystemInfo()
        {

            var extractionRegex = new Regex("(\\w+?) ?= ?\"(.+?)\";", RegexOptions.Compiled | RegexOptions.Multiline);

            var systemInfo = GetManagementInfo("SELECT * FROM Win32_OperatingSystem", extractionRegex);
            var processorInfo = GetManagementInfo("SELECT * FROM Win32_Processor", extractionRegex);

            Caption = systemInfo.GetValue("Caption");
            CSName = systemInfo.GetValue("CSName");
            InstallDate = systemInfo.GetValue("InstallDate");
            OSArchitecture = systemInfo.GetValue("OSArchitecture");
            SerialNumber = systemInfo.GetValue("SerialNumber");
            Version = systemInfo.GetValue("Version");
            TotalVisibleMemorySize = systemInfo.GetValue("TotalVisibleMemorySize").CastTo<long>();

            CPUName = processorInfo.GetValue("Name");

            DotNetFrameworkVersion = Get45PlusFromRegistry();
        }

        private static IReadOnlyDictionary<string, string> GetManagementInfo(string query, Regex regex)
        {
            try
            {
                var result = new ManagementObjectSearcher(new ObjectQuery(query));
                var infoString = string.Empty;
                using (var collection = result.Get())
                {
                    foreach (var item in collection)
                    {
                        var managementObject = item as ManagementObject;
                        infoString = managementObject?.GetText(TextFormat.Mof);
                        if (!string.IsNullOrEmpty(infoString)) break;
                    }
                }

                if (string.IsNullOrEmpty(infoString)) return null;

                return regex.Matches(infoString).OfType<Match>()
                    .Where(item => item.Success)
                    .ToDictionary(item => item.Groups[1].Value, item => item.Groups[2].Value);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private static string GetValue(this IReadOnlyDictionary<string, string> info, string key)
        {
            return info != null && info.TryGetValue(key, out var value) ? value : ExtractionFailed;
        }

        /*
         * Refer to: 
         * Check Framework 45+: https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed#net_d;
         */

        private static DotNetFramework Get45PlusFromRegistry()
        {
            const string subKey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";

            using (RegistryKey ndpKey = RegistryKey
                .OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                .OpenSubKey(subKey))
            {
                return ndpKey?.GetValue("Release") != null
                    ? CheckFor45PlusVersion((int)ndpKey.GetValue("Release"))
                    : DotNetFramework.Unknown;
            }
        }

        // Checking the version using >= will enable forward compatibility.
        private static DotNetFramework CheckFor45PlusVersion(int releaseKey)
        {
            if (releaseKey >= 461808)
                return DotNetFramework.V472OrLater;
            if (releaseKey >= 461308)
                return DotNetFramework.V471;
            if (releaseKey >= 460798)
                return DotNetFramework.V47;
            if (releaseKey >= 394802)
                return DotNetFramework.V462;
            if (releaseKey >= 394254)
                return DotNetFramework.V461;
            if (releaseKey >= 393295)
                return DotNetFramework.V46;
            if (releaseKey >= 379893)
                return DotNetFramework.V452;
            if (releaseKey >= 378675)
                return DotNetFramework.V451;
            if (releaseKey >= 378389)
                return DotNetFramework.V45;

            // This code should never execute. A non-null release key should mean
            // that 4.5 or later is installed.
            return DotNetFramework.V472OrLater;
        }
    }

    public enum DotNetFramework
    {
        Unknown,
        V45,
        V451,
        V452,
        V46,
        V461,
        V462,
        V47,
        V471,
        V472OrLater
    }

    public static class ObjectExtensions
    {
        private const double Tolerance = 1e-6;

        public static T CastTo<T>(this object value)
        {
            return typeof(T).IsValueType && value != null
                ? (T)Convert.ChangeType(value, typeof(T))
                : value is T typeValue ? typeValue : default;
        }

        public static bool EqualsWithinTolerance(this double @this, double other)
        {
            return Math.Abs(@this - other) < Tolerance;
        }

        public static bool GreaterOrEqual(this double @this, double other)
        {
            return @this > other || @this.EqualsWithinTolerance(other);
        }

        public static bool LessOrEqual(this double @this, double other)
        {
            return @this < other || @this.EqualsWithinTolerance(other);
        }
    }

    public enum DataSizeUnit { B, KB, MB, GB, TB, PB, EB }

    public struct DisplayDataSize : IEquatable<DisplayDataSize>
    {
        public const int OneB = 1;
        public const int OneKB = 1024 * OneB;
        public const int OneMB = 1024 * OneKB;
        public const long OneGB = 1024 * OneMB;
        public const long OneTB = 1024 * OneGB;
        public const long OnePB = 1024 * OneTB;
        public const long OneEB = 1024 * OnePB;

        private DataSizeUnit _unit;

        public long Value { get; }

        public double DisplayValue { get; private set; }

        public DataSizeUnit Unit
        {
            get => _unit;
            set
            {
                if (value == _unit) return;

                DisplayValue *= Math.Pow(OneKB, _unit - value);
                _unit = value;
            }
        }

        public DisplayDataSize(double valueBasedB)
        {
            Value = (long)valueBasedB;
            DisplayValue = valueBasedB;
            _unit = DataSizeUnit.B;
            while (DisplayValue >= OneKB) // long.MaxValue = 8 EB. 
            {
                DisplayValue /= OneKB;
                _unit++;
            }
        }

        public override string ToString() => (Unit == DataSizeUnit.B ? $"{DisplayValue:N0} " : $"{DisplayValue:N2} ") + $"{Unit}";

        public static implicit operator long(DisplayDataSize dataSize) => dataSize.Value;

        public static implicit operator double(DisplayDataSize dataSize) => dataSize.DisplayValue;

        public static implicit operator string(DisplayDataSize dataSize) => dataSize.ToString();

        public static implicit operator DisplayDataSize(double value) => new DisplayDataSize(value);

        #region Implements Equals 

        public bool Equals(DisplayDataSize other) => Value.Equals(other.Value);

        public override bool Equals(object obj) => obj != null && obj is DisplayDataSize size && Equals(size);

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(DisplayDataSize left, DisplayDataSize right) => left.Equals(right);

        public static bool operator !=(DisplayDataSize left, DisplayDataSize right) => !(left == right);

        #endregion
    }
}
