using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PointRoutingDemo.Views
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            media.Source = new Uri("Musics/test.mp3", UriKind.Relative);
            media.MediaEnded += new RoutedEventHandler(media_MediaEnded);
            playbtn_Click(null, null);
            runTimetxt.Text = "00:00";
            remainTimetxt.Text = "00:00";
        }

        DispatcherTimer timer = null;
        private bool play = false;
        private void playbtn_Click(object sender, RoutedEventArgs e)
        {
            if (play == false)
            {
                play = true;
                media.Play();
                playBrush.Visual = this.FindResource("appbar_control_pause") as Visual;
            }
            else
            {
                play = false;
                media.Pause();
                playBrush.Visual = this.FindResource("appbar_control_play") as Visual;
            }
        }

        private void stopbtn_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
            play = false;
            playBrush.Visual = this.FindResource("appbar_control_play") as Visual;
        }

        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            sliderPosition.Maximum = media.NaturalDuration.TimeSpan.TotalSeconds;
            //媒体文件打开成功
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            sliderPosition.Value = media.Position.TotalSeconds;
        }

        private void sliderPosition_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Position = TimeSpan.FromSeconds(sliderPosition.Value);
            runTimetxt.Text = TimeSpan.FromSeconds(sliderPosition.Value).ToString("mm\\:ss");
            remainTimetxt.Text = TimeSpan.FromSeconds(sliderPosition.Maximum - sliderPosition.Value).ToString("mm\\:ss");
        }

        //循环播放
        void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (repeatbtn.IsChecked == true)
            {
                (sender as MediaElement).Stop();
                (sender as MediaElement).Play();
            }
            else
            {
                (sender as MediaElement).Stop();
                play = false;
                playBrush.Visual = this.FindResource("appbar_control_play") as Visual;
            }
        }

        private void mutebtn_Click(object sender, RoutedEventArgs e)
        {
            media.Volume = 0;
            muteBrush.Visual = this.FindResource("appbar_sound_mute") as Visual;
        }

        private void soundmaxbtn_Click(object sender, RoutedEventArgs e)
        {
            media.Volume = 1;
        }

        private void sliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sliderVolume.Value == 0)
            {
                muteBrush.Visual = this.FindResource("appbar_sound_mute") as Visual;
            }
            else
            {
                muteBrush.Visual = this.FindResource("appbar_sound_0") as Visual;
            }
        }
    }
}
