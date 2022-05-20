using System;
using System.Windows.Controls;

namespace AIStudio.Wpf.Base_Manage.Views
{
    /// <summary>
    /// Base_DictionaryView.xaml 的交互逻辑
    /// </summary>
    public partial class Base_DictionaryView : UserControl
    {
        public Base_DictionaryView()
        {
            InitializeComponent();
            this.table.LoadingRow += new EventHandler<DataGridRowEventArgs>(this.table_LoadingRow);
        }

        private void table_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        } 
    }
}
