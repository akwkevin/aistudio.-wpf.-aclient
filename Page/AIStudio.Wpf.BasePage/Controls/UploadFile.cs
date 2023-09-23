using AIStudio.Wpf.Business;
using Prism.Ioc;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Controls.Helper;
using System.Windows.Data;

namespace AIStudio.Wpf.BasePage.Controls
{
    [TemplatePart(Name = PART_UploadFile, Type = typeof(Control))]
    public class UploadFile : Control
    {
        private const string PART_UploadFile = "PART_UploadFile";
        internal AIStudio.Wpf.Controls.UploadFile _uploadFile;
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

            _uploadFile = GetTemplateChild(PART_UploadFile) as AIStudio.Wpf.Controls.UploadFile;
            if (_uploadFile != null)
            {
                _uploadFile.Upload = async (path) =>
                {
                    if (BigFileUpload == false)
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
                    }
                    else
                    {
                        var result = await _dataProvider.UploadFileChunck(path, progress => { Progress = progress; });
                        if (result.status == "done")
                        {
                            return new Tuple<string, string>(result.url, result.name);
                        }
                        else
                        {
                            return new Tuple<string, string>("", "");
                        }
                    }
                };
            }
        }

        public static readonly DependencyProperty UploadFileTypeProperty = DependencyProperty.Register(
                nameof(UploadFileType), typeof(AIStudio.Wpf.Controls.UploadFileType), typeof(UploadFile), new PropertyMetadata(AIStudio.Wpf.Controls.UploadFileType.File));

        public AIStudio.Wpf.Controls.UploadFileType UploadFileType
        {
            get { return (AIStudio.Wpf.Controls.UploadFileType)this.GetValue(UploadFileTypeProperty); }
            set { this.SetValue(UploadFileTypeProperty, value); }
        }

        public static readonly DependencyProperty FilesProperty = DependencyProperty.Register(
            nameof(Files), typeof(ObservableCollection<string>), typeof(UploadFile));

        public ObservableCollection<string> Files
        {
            get { return (ObservableCollection<string>)this.GetValue(FilesProperty); }
            set { this.SetValue(FilesProperty, value); }
        }

        public static readonly DependencyProperty MaxCountProperty = DependencyProperty.Register(
            nameof(MaxCount), typeof(int), typeof(UploadFile), new PropertyMetadata(1));

        public int MaxCount
        {
            get { return (int)this.GetValue(MaxCountProperty); }
            set { this.SetValue(MaxCountProperty, value); }
        }

        public static readonly DependencyProperty FileProperty = DependencyProperty.Register(
           nameof(File), typeof(string), typeof(UploadFile), new PropertyMetadata(default(string)));

        public string File
        {
            get { return (string)this.GetValue(FileProperty); }
            set { this.SetValue(FileProperty, value); }
        }

        public static readonly DependencyProperty DisableProperty = DependencyProperty.Register(
           nameof(Disable), typeof(bool), typeof(UploadFile), new PropertyMetadata(false));

        public bool Disable
        {
            get { return (bool)this.GetValue(DisableProperty); }
            set { this.SetValue(DisableProperty, value); }
        }

        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register(
         nameof(Progress), typeof(double), typeof(UploadFile), new PropertyMetadata(1d));

        public double Progress
        {
            get
            {
                return (double)this.GetValue(ProgressProperty);
            }
            set
            {
                this.SetValue(ProgressProperty, value);
            }
        }

        public static readonly DependencyProperty BigFileUploadProperty = DependencyProperty.Register(
             nameof(BigFileUpload), typeof(bool), typeof(UploadFile), new PropertyMetadata(false));

        public bool BigFileUpload
        {
            get { return (bool)this.GetValue(BigFileUploadProperty); }
            set { this.SetValue(BigFileUploadProperty, value); }
        }

    } 

}

