using System;
using System.IO;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace AIStudio.Wpf.PrismAvalonExtensions.DockStrategies
{
    [Serializable]
    [XmlInclude(typeof(SideDockStrategy))]
    [XmlInclude(typeof(NestedDockStrategy))]
    public abstract class DockStrategy
    {
        public DockStrategy()
        {
        }

        public DockStrategy(object view, string title)
        {
            View = view;
            Title = title;
        }

        public DockStrategy(object view, string title, string id)
        {
            View = view;
            Title = title;
            Id = id;
        }

        string _id;
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        BitmapSource _icon;
        [XmlIgnore]
        public BitmapSource Icon
        {
            get
            {
                if (_icon == null && !string.IsNullOrEmpty(_base64Icon)) _icon = Base64ToImage(_base64Icon);
                return _icon;
            }
            set
            {
                _icon = value;
            }
        }

        string _base64Icon;
        public string Base64Icon
        {
            get
            {
                if (_base64Icon == null) _base64Icon = ImageToBase64(Icon);
                return _base64Icon;
            }
            set
            {
                _base64Icon = value;
            }
        }

        object _view;
        [XmlIgnore]
        public object View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
                ViewType = string.Format("{0}, {1}", value.GetType().FullName, value.GetType().Assembly.GetName().Name);
            }
        }

        string _viewType;
        public string ViewType
        {
            get
            {
                return _viewType;
            }
            set
            {
                _viewType = value;
            }
        }

        string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        bool _canClose = true;
        public bool CanClose
        {
            get
            {
                return _canClose;
            }
            set
            {
                _canClose = value;
            }
        }

        string ImageToBase64(BitmapSource bitmap)
        {
            if (bitmap == null) return null;
            var encoder = new PngBitmapEncoder();
            var frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        BitmapSource Base64ToImage(string base64)
        {
            if (string.IsNullOrEmpty(base64)) return null;
            byte[] bytes = Convert.FromBase64String(base64);
            using (var stream = new MemoryStream(bytes))
            {
                return BitmapFrame.Create(stream);
            }
        }
    }
}
