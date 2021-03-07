using AutoMapper;
using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Util.Controls;

namespace AIStudio.Wpf.BasePage.Models
{
    [AutoMap(typeof(AMenuItem))]
    public class AToolItem : AMenuItem
    {
        private string _badge;
        [Browsable(true)]
        public string Badge
        {
            get { return _badge; }
            set
            {
                if (_badge == value) return;
                _badge = value;
                OnPropertyChanged("Badge");
            }
        }

        private string _badgeBrush;
        [Browsable(true)]
        public string BadgeBrush
        {
            get { return _badgeBrush; }
            set
            {
                if (_badgeBrush == value) return;
                _badgeBrush = value;
                OnPropertyChanged("BadgeBrush");
            }
        }
        public int Sort { get; set; }
        private double _width  = 48;
        [Browsable(true)]
        public double Width
        {
            get { return _width; }
            set
            {
                if (value == _width) return;
                _width = value;
                OnPropertyChanged("Width");
            }
        }

        private double _height = 48;
        [Browsable(true)]
        public double Height
        {
            get { return _height; }
            set
            {
                if (value == _height) return;
                _height = value;
                OnPropertyChanged("Height");
            }
        }

        private double _margin = 3;
        [Browsable(true)]
        public double Margin
        {
            get { return _margin; }
            set
            {
                if (value == _margin) return;
                _margin = value;
                OnPropertyChanged("Margin");
            }
        }

        private string _parentCode;
        [SourceMember(nameof(AMenuItem.Parent.Code))]
        public string ParentCode
        {
            get { return _parentCode; }
            set
            {
                if (value == _parentCode) return;
                _parentCode = value;
                OnPropertyChanged("ParentCode");
            }
        }
    }
}
