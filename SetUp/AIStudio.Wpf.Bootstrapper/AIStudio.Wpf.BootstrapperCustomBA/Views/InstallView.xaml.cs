using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Resources;
using CustomBA.ViewModels;
using Application = System.Windows.Application;
using Cursor = System.Windows.Input.Cursor;
using Cursors = System.Windows.Input.Cursors;
using MessageBox = System.Windows.MessageBox;

namespace CustomBA.Views
{
    /// <summary>
    /// InstallView.xaml 的交互逻辑
    /// </summary>
    public partial class InstallView : Window
    {
        /// <summary>
        /// 视图模型
        /// </summary>
        private InstallViewModel installViewModel;
        private DoubleAnimation dani;



        public InstallView(InstallViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
            installViewModel = viewModel;

            this.Loaded += (sender, e) => CustomBootstrapperApplication.Model.Engine.CloseSplashScreen();
            this.Closed += (sender, e) => viewModel.CancelCommand.Execute(this);


            // AnimateImgsInit();
            dani = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(4),
                BeginTime = TimeSpan.FromSeconds(4),
                // FillBehavior = FillBehavior.Stop,
                //AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(TimeSpan.FromSeconds(4))
            };
            dani.Completed += dani_Completed;

         //   ImgDay.BeginAnimation(OpacityProperty, dani);

        }

        void dani_Completed(object sender, EventArgs e)
        {
          //  ImgDay.BeginAnimation(OpacityProperty, dani);
        }
        private void Background_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public  void LaunchUrl(string uri)
        {
            // Switch the wait cursor since shellexec can take a second or so.
            Cursor cursor = this.Cursor;
             Cursor = Cursors.Wait;

            try
            {
                var process = new Process {StartInfo = {FileName = uri, UseShellExecute = true, Verb = "open"}};
                process.Start();
            }
            finally
            {
               Cursor = cursor; // back to the original cursor.
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                RunHelper.RunInstaller(@"SenseLockDrivers\InstWiz3.exe");
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString(),"错误");
            }
        }


        private void SelectFile_OnClick(object sender, RoutedEventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog {SelectedPath = installViewModel.InstallFollder};

            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //没有DIAVIWE这个文件  还是要自动创建一个为好吧。
                installViewModel.InstallFollder = folderBrowserDialog.SelectedPath;
            }
        }
 
        #region imgs

        private void MinBt_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseBt_OnClick(object sender, RoutedEventArgs e)
        {
            //询问是否要取消安装
            //Close();
            if (!installViewModel.CompleteEnabled)
            {
                installViewModel.CancelCommand.Execute(this);
            }
            else
            {
                Close();
            }
        }
 
     
     
        private void Finished(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
           // Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            LaunchUrl(e.Uri.AbsoluteUri);
            e.Handled = true;
        }
        private void Hyperlink_OpenGuid(object sender, RequestNavigateEventArgs e)
        {
            try
            {
               LaunchUrl("InstallGuide.html");
                //Application.ResourceAssembly = ;
                Uri uri = new Uri("/Resources/InstallGuide.html", UriKind.Relative);
                StreamResourceInfo info = Application.GetResourceStream(uri);

                var xx = StreamToString(info.Stream);


                MessageBox.Show(xx);

                //StreamToFile(info.Stream, "InstallGuide.html");
                //LaunchUrl("InstallGuide.html");

                e.Handled = true;
            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.Message);
            }
          
        }
        public void StreamToFile(Stream stream, string fileName)
        {
            // 把 Stream 转换成 byte[]
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            // 把 byte[] 写入文件
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }

        public static string StreamToString(Stream stream)
        {
            stream.Position = 0;
            using (StreamReader stremReader = new StreamReader(stream, Encoding.UTF8))
            {
                return stremReader.ReadToEnd();
            }
        }
    }
    }

        #endregion 

     
