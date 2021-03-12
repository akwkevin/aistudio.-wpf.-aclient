using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace CustomBA.Models
{
   public class DiaViewModel
    {
        private Version _version;
        private const string BurnBundleInstallDirectoryVariable = "InstallFolder";
        private const string BurnBundleLayoutDirectoryVariable = "WixBundleLayoutDirectory";

        public DiaViewModel(BootstrapperApplication bootstrapper)
        {
            Bootstrapper = bootstrapper;
            Telemetry = new List<KeyValuePair<string, string>>();
        }

        /// <summary>
        /// Gets the bootstrapper.
        /// </summary>
        public BootstrapperApplication Bootstrapper { get; private set; }

        /// <summary>
        /// Gets the bootstrapper command-line.
        /// </summary>
        public Command Command { get { return Bootstrapper.Command; } }

        /// <summary>
        /// Gets the bootstrapper engine.
        /// </summary>
        public Engine Engine { get { return Bootstrapper.Engine; } }

        /// <summary>
        /// Gets the key/value pairs used in telemetry.
        /// </summary>
        public List<KeyValuePair<string, string>> Telemetry { get; private set; }

        /// <summary>
        /// Get or set the final result of the installation.
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// Get the version of the install.
        /// </summary>
        public Version Version
        {
            get
            {
                if (null == _version)
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(assembly.Location);

                    _version = new Version(fileVersion.FileVersion);
                }

                return _version;
            }
        }

        /// <summary>
        /// Get or set the path where the bundle is installed.
        /// </summary>
        public string InstallDirectory
        {
            get
            {
                if (!Engine.StringVariables.Contains(BurnBundleInstallDirectoryVariable))
                {
                    return null;
                }

                return Engine.StringVariables[BurnBundleInstallDirectoryVariable];
            }

            set
            {
                Engine.StringVariables[BurnBundleInstallDirectoryVariable] = value;
            }
        }

        /// <summary>
        /// Get or set the path for the layout to be created.
        /// </summary>
        public string LayoutDirectory
        {
            get
            {
                if (!Engine.StringVariables.Contains(BurnBundleLayoutDirectoryVariable))
                {
                    return null;
                }

                return Engine.StringVariables[BurnBundleLayoutDirectoryVariable];
            }

            set
            {
                Engine.StringVariables[BurnBundleLayoutDirectoryVariable] = value;
            }
        }

        public LaunchAction PlannedAction { get; set; }

        /// <summary>
        /// Creates a correctly configured HTTP web request.
        /// </summary>
        /// <param name="uri">URI to connect to.</param>
        /// <returns>Correctly configured HTTP web request.</returns>
        public HttpWebRequest CreateWebRequest(string uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.UserAgent = String.Concat("WixInstall", Version.ToString());
            return request;
        }
    }
}
