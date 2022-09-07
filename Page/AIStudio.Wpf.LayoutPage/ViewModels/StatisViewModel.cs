using AIStudio.Wpf.PrismAvalonExtensions.ViewModels;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AIStudio.Wpf.LayoutPage.ViewModels
{
    class StatisViewModel : DockWindowViewModel
    {
        public StatisPart1ViewModel StatisPart1ViewModel { get; set; } = new StatisPart1ViewModel();
        public StatisPart2ViewModel StatisPart2ViewModel { get; set; } = new StatisPart2ViewModel();
        public StatisPart3ViewModel StatisPart3ViewModel { get; set; } = new StatisPart3ViewModel();
        public StatisPart4ViewModel StatisPart4ViewModel { get; set; } = new StatisPart4ViewModel();
        public StatisPart5ViewModel StatisPart5ViewModel { get; set; } = new StatisPart5ViewModel();
        public StatisPart6ViewModel StatisPart6ViewModel { get; set; } = new StatisPart6ViewModel();
        public StatisPart7ViewModel StatisPart7ViewModel { get; set; } = new StatisPart7ViewModel();
    }

    class StatisPart1ViewModel
    {
        public StatisPart1ViewModel()
        {
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2021",
                    Values = new ChartValues<double> { 10, 50, 39, 50, 60, 70, 36 }
                }
            };

            Labels = new[] { "1月", "2月", "3月", "4月", "5月", "6月", "7月", };
            Formatter = value => value.ToString("N");
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }

    class StatisPart2ViewModel
    {
        public StatisPart2ViewModel()
        {
            SeriesCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "2021",
                    Values = new ChartValues<double> { 10, 50, 39, 50, 60 }
                }
            };

            Labels = new[] { "周一", "周二", "周三", "周四", "周五" };
            Formatter = value => value.ToString("N");
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }

    class StatisPart3ViewModel
    {
        public StatisPart3ViewModel()
        {
            PointLabel = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }

    class StatisPart4ViewModel : BindableBase
    {
        public StatisPart4ViewModel()
        {
            Value = 70;
        }

        private double _value;

        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                RaisePropertyChanged("Value");
            }
        }
    }

    class StatisPart5ViewModel
    {
        public StatisPart5ViewModel()
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,7 }
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 }
                }
            };

            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
            YFormatter = value => value.ToString("C");

            //modifying the series collection will animate and update the chart
            SeriesCollection.Add(new LineSeries
            {
                Values = new ChartValues<double> { 5, 3, 2, 4 },
                LineSmoothness = 0 //straight lines, 1 really smooth lines
            });

            //modifying any series values will also animate and update the chart
            SeriesCollection[2].Values.Add(5d);

        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
    }

    class StatisPart6ViewModel : BindableBase
    {
        public StatisPart6ViewModel()
        {
            SeriesCollection = new SeriesCollection
            {
                new StackedAreaSeries
                {
                    Title = "Africa",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new DateTime(2014, 1, 1), .228),
                        new DateTimePoint(new DateTime(2015, 1, 1), .285),
                        new DateTimePoint(new DateTime(2016, 1, 1), .366),
                        new DateTimePoint(new DateTime(2017, 1, 1), .478),
                        new DateTimePoint(new DateTime(2018, 1, 1), .629),
                        new DateTimePoint(new DateTime(2019, 1, 1), .808),
                        new DateTimePoint(new DateTime(2020, 1, 1), 1.031),
                        new DateTimePoint(new DateTime(2021, 1, 1), 1.110)
                    },
                    LineSmoothness = 0
                },
                new StackedAreaSeries
                {
                    Title = "N & S America",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new DateTime(2014, 1, 1), .339),
                        new DateTimePoint(new DateTime(2015, 1, 1), .424),
                        new DateTimePoint(new DateTime(2016, 1, 1), .519),
                        new DateTimePoint(new DateTime(2017, 1, 1), .618),
                        new DateTimePoint(new DateTime(2018, 1, 1), .727),
                        new DateTimePoint(new DateTime(2019, 1, 1), .841),
                        new DateTimePoint(new DateTime(2020, 1, 1), .942),
                        new DateTimePoint(new DateTime(2021, 1, 1), .972)
                    },
                    LineSmoothness = 0
                },
                new StackedAreaSeries
                {
                    Title = "Asia",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new DateTime(2014, 1, 1), 1.395),
                        new DateTimePoint(new DateTime(2015, 1, 1), 1.694),
                        new DateTimePoint(new DateTime(2016, 1, 1), 2.128),
                        new DateTimePoint(new DateTime(2017, 1, 1), 2.634),
                        new DateTimePoint(new DateTime(2018, 1, 1), 3.213),
                        new DateTimePoint(new DateTime(2019, 1, 1), 3.717),
                        new DateTimePoint(new DateTime(2020, 1, 1), 4.165),
                        new DateTimePoint(new DateTime(2021, 1, 1), 4.298)
                    },
                    LineSmoothness = 0
                },
                new StackedAreaSeries
                {
                    Title = "Europe",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new DateTime(2014, 1, 1), .549),
                        new DateTimePoint(new DateTime(2015, 1, 1), .605),
                        new DateTimePoint(new DateTime(2016, 1, 1), .657),
                        new DateTimePoint(new DateTime(2017, 1, 1), .694),
                        new DateTimePoint(new DateTime(2018, 1, 1), .723),
                        new DateTimePoint(new DateTime(2019, 1, 1), .729),
                        new DateTimePoint(new DateTime(2020, 1, 1), .740),
                        new DateTimePoint(new DateTime(2021, 1, 1), .742)
                    },
                    LineSmoothness = 0
                }
            };

            XFormatter = val => new DateTime((long)val).ToString("yyyy");
            YFormatter = val => val.ToString("N") + " M";

        }

        public SeriesCollection SeriesCollection { get; set; }
        public Func<double, string> XFormatter { get; set; }

        private Func<double, string> _yFormatter;
        public Func<double, string> YFormatter
        {
            get { return _yFormatter; }
            set
            {
                _yFormatter = value;
                RaisePropertyChanged("YFormatter");
            }
        }

        public StackMode StackMode { get; set; }

        private void ChangeStackModeOnClick(object sender, RoutedEventArgs e)
        {
            foreach (var series in SeriesCollection.Cast<StackedAreaSeries>())
            {
                series.StackMode = series.StackMode == StackMode.Percentage
                    ? StackMode.Values
                    : StackMode.Percentage;
            }

            if (((StackedAreaSeries)SeriesCollection[0]).StackMode == StackMode.Values)
            {
                YFormatter = val => val.ToString("N") + " M";
            }
            else
            {
                YFormatter = val => val.ToString("P");
            }
        }
    }

    class StatisPart7ViewModel : BindableBase
    {
        public StatisPart7ViewModel()
        {
            var now = DateTime.Now;

            _values = new ChartValues<GanttPoint>
            {
                new GanttPoint(now.Ticks, now.AddDays(2).Ticks),
                new GanttPoint(now.AddDays(1).Ticks, now.AddDays(3).Ticks),
                new GanttPoint(now.AddDays(3).Ticks, now.AddDays(5).Ticks),
                new GanttPoint(now.AddDays(5).Ticks, now.AddDays(8).Ticks),
                new GanttPoint(now.AddDays(6).Ticks, now.AddDays(10).Ticks),
                new GanttPoint(now.AddDays(7).Ticks, now.AddDays(14).Ticks),
                new GanttPoint(now.AddDays(9).Ticks, now.AddDays(12).Ticks),
                new GanttPoint(now.AddDays(9).Ticks, now.AddDays(14).Ticks),
                new GanttPoint(now.AddDays(10).Ticks, now.AddDays(11).Ticks),
                new GanttPoint(now.AddDays(12).Ticks, now.AddDays(16).Ticks),
                new GanttPoint(now.AddDays(15).Ticks, now.AddDays(17).Ticks),
                new GanttPoint(now.AddDays(18).Ticks, now.AddDays(19).Ticks)
            };

            Series = new SeriesCollection
            {
                new RowSeries
                {
                    Values = _values,
                    DataLabels = true
                }
            };
            Formatter = value => new DateTime((long)value).ToString("dd MMM");

            var labels = new List<string>();
            for (var i = 0; i < 12; i++)
                labels.Add("Task " + i);
            Labels = labels.ToArray();

            ResetZoomOnClick(null, null);
        }

        private readonly ChartValues<GanttPoint> _values;

        public SeriesCollection Series { get; set; }
        public Func<double, string> Formatter { get; set; }
        public string[] Labels { get; set; }

        private double _from;
        public double From
        {
            get { return _from; }
            set
            {
                _from = value;
                RaisePropertyChanged("From");
            }
        }

        private double _to;
        public double To
        {
            get { return _to; }
            set
            {
                _to = value;
                RaisePropertyChanged("To");
            }
        }

        private void ResetZoomOnClick(object sender, RoutedEventArgs e)
        {
            From = _values.First().StartPoint;
            To = _values.Last().EndPoint;
        }
    }
}
