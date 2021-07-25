using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AIStudio.Core
{
    public class ImageAttached
    {
        // Gray8附加属性，Gary8图片样式的"开关"
        public static readonly DependencyProperty Gray8Property =
                DependencyProperty.RegisterAttached("Gray8", typeof(bool), typeof(ImageAttached),
                    new FrameworkPropertyMetadata((bool)false,
                        new PropertyChangedCallback(OnGray8Changed)));

        public static bool GetGray8(DependencyObject d)
        {
            return (bool)d.GetValue(Gray8Property);
        }

        public static void SetGray8(DependencyObject d, bool value)
        {
            d.SetValue(Gray8Property, value);
        }

        private static void OnGray8Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Image currentImage = d as Image;
            if (currentImage == null)
            {
                return;
            }

            bool isGray8 = (bool)d.GetValue(Gray8Property);

            if (isGray8)
            {
                // 附加BitmapSourceBackup属性，备份当前BitmapSource，以备恢复用
                BitmapSource backupBitmapSource = (currentImage.Source as BitmapSource).CloneCurrentValue();
                d.SetValue(BitmapSourceBackupProperty, backupBitmapSource);

                // 建立Gray8的BitmapSource
                FormatConvertedBitmap newFormatedBitmapSource = new FormatConvertedBitmap();
                newFormatedBitmapSource.BeginInit();
                newFormatedBitmapSource.Source = currentImage.Source as BitmapSource;
                newFormatedBitmapSource.DestinationFormat = PixelFormats.Gray8;
                newFormatedBitmapSource.EndInit();

                // 替换ImageSource
                currentImage.Source = newFormatedBitmapSource;
            }
            else
            {
                // 图像恢复操作
                object obj = currentImage.GetValue(BitmapSourceBackupProperty);
                if (obj == null)
                {
                    return;
                }

                BitmapSource bs = obj as BitmapSource;
                if (bs == null)
                {
                    return;
                }

                currentImage.Source = bs;
            }
        }

        // 备份用源图像的附加属性，当Gray8变更时，自动附加
        public static readonly DependencyProperty BitmapSourceBackupProperty =
                DependencyProperty.RegisterAttached("BitmapSourceBackup", typeof(BitmapSource), typeof(ImageAttached),
                    new FrameworkPropertyMetadata(null));

        public static BitmapSource GetBitmapSourceBackup(DependencyObject d)
        {
            return (BitmapSource)d.GetValue(BitmapSourceBackupProperty);
        }

        public static void SetBitmapSourceBackup(DependencyObject d, BitmapSource value)
        {
            d.SetValue(BitmapSourceBackupProperty, value);
        }
    }
}
