using AIStudio.Wpf.Business;
using Prism.Ioc;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Util.Controls.Tools;

namespace AIStudio.Wpf.BasePage.Controls
{
    [TemplatePart(Name = PART_UploadFile, Type = typeof(Control))]
    public class UploadFile : Control
    {
        private const string PART_UploadFile = "PART_UploadFile";
        internal Util.Controls.UploadFile _uploadFile;
        protected IDataProvider _dataProvider { get; }

        static UploadFile()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UploadFile), new FrameworkPropertyMetadata(typeof(UploadFile)));
        }

        public UploadFile()
        {
            //读取资源字典文件
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri("/AIStudio.Wpf.BasePage;component/Controls/UploadFile.xaml", UriKind.Relative);
            if (!this.Resources.MergedDictionaries.Any(p => p.Source == rd.Source))
            {
                this.Resources.MergedDictionaries.Add(rd);
            }
            //获取样式

            this.Style = this.FindResource("DefaultUploadFileStyle") as Style;

            if (DesignerHelper.IsInDesignMode) return;
            _dataProvider = ContainerLocator.Current.Resolve<IDataProvider>();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _uploadFile = GetTemplateChild(PART_UploadFile) as Util.Controls.UploadFile;
            if (_uploadFile != null)
            {
                _uploadFile.Upload = async (path) =>
                {
                    var result = await _dataProvider.UploadFileByForm(path);
                    if (result.status == "done")
                    {
                        return new Tuple<string, string>(result.url, result.name);
                    }
                    else
                    {
                        return new Tuple<string, string>("", "");
                    }
                };

            }
        }

        public static readonly DependencyProperty UploadFileTypeProperty = DependencyProperty.Register(
                "UploadFileType", typeof(Util.Controls.UploadFileType), typeof(UploadFile), new PropertyMetadata(Util.Controls.UploadFileType.File));

        public Util.Controls.UploadFileType UploadFileType
        {
            get { return (Util.Controls.UploadFileType)this.GetValue(UploadFileTypeProperty); }
            set { this.SetValue(UploadFileTypeProperty, value); }
        }

        public static readonly DependencyProperty FilesProperty = DependencyProperty.Register(
            "Files", typeof(ObservableCollection<string>), typeof(UploadFile), new PropertyMetadata(null));

        public ObservableCollection<string> Files
        {
            get { return (ObservableCollection<string>)this.GetValue(FilesProperty); }
            set { this.SetValue(FilesProperty, value); }
        }

        public static readonly DependencyProperty MaxCountProperty = DependencyProperty.Register(
            "MaxCount", typeof(int), typeof(UploadFile), new PropertyMetadata(1));

        public int MaxCount
        {
            get { return (int)this.GetValue(MaxCountProperty); }
            set { this.SetValue(MaxCountProperty, value); }
        }

        public static readonly DependencyProperty FileProperty = DependencyProperty.Register(
            "File", typeof(string), typeof(UploadFile), new PropertyMetadata(default(string)));

        public string File
        {
            get { return (string)this.GetValue(FileProperty); }
            set { this.SetValue(FileProperty, value); }
        }

        public static readonly DependencyProperty UploadVisibleProperty = DependencyProperty.Register(
            "UploadVisible", typeof(Visibility), typeof(UploadFile), new PropertyMetadata(Visibility.Visible));

        public Visibility UploadVisible
        {
            get { return (Visibility)this.GetValue(UploadVisibleProperty); }
            set { this.SetValue(UploadVisibleProperty, value); }
        }

        public static readonly DependencyProperty FilesDisplayProperty = DependencyProperty.Register(
            "FilesDisplay", typeof(ObservableCollection<Util.Controls.UploadFileDisplay>), typeof(UploadFile), new PropertyMetadata(new ObservableCollection<Util.Controls.UploadFileDisplay>() { new Util.Controls.UploadFileDisplay() { IsUploadTemplate = true } }));

        public ObservableCollection<Util.Controls.UploadFileDisplay> FilesDisplay
        {
            get { return (ObservableCollection<Util.Controls.UploadFileDisplay>)this.GetValue(FilesDisplayProperty); }
            set { this.SetValue(FilesDisplayProperty, value); }
        }

        public static readonly DependencyProperty DisableProperty = DependencyProperty.Register(
           "Disable", typeof(bool), typeof(UploadFile), new PropertyMetadata(false));

        public bool Disable
        {
            get { return (bool)this.GetValue(DisableProperty); }
            set { this.SetValue(DisableProperty, value); }
        }

    } 

}

