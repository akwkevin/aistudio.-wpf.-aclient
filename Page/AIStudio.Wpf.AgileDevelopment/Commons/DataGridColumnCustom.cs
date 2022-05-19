using Newtonsoft.Json;
using System.Windows;
using System.Windows.Controls;

namespace AIStudio.Wpf.AgileDevelopment.Commons
{
    public class DataGridColumnCustom
    {
        public int DisplayIndex
        {
            get; set;
        }

        public string Binding
        {
            get; set;
        }

        public Style CellStyle
        {
            get; set;
        }

        public bool CanUserSort
        {
            get; set;
        }

        public bool CanUserResize
        {
            get; set;
        }

        public bool CanUserReorder
        {
            get; set;
        }

        [JsonIgnore]
        public Style HeaderStyle
        {
            get; set;
        }

        public DataGridLength Width
        {
            get; set;
        }

        public bool IsFrozen
        {
            get;
        }

        public bool IsReadOnly
        {
            get; set;
        }

        public double MaxWidth
        {
            get; set;
        }

        public double MinWidth
        {
            get; set;
        }


        public string SortMemberPath
        {
            get; set;
        }

        public Visibility Visibility
        {
            get; set;
        }

        public object Header
        {
            get; set;
        }

        public string StringFormat
        {
            get; set;
        }

        public string Converter
        {
            get; set;
        }

        public object ConverterParameter
        {
            get; set;
        }

        public string ForegroundExpression
        {
            get; set;
        }

        public string BackgroundExpression
        {
            get; set;
        }

        public HorizontalAlignment HorizontalAlignment
        {
            get; set;
        }
    }
}
