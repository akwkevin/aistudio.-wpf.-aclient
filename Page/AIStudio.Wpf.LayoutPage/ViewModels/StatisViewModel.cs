using AIStudio.Wpf.PrismAvalonExtensions.ViewModels;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.Painting;
using Prism.Mvvm;
using SkiaSharp;
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
        private int _index = 0;
        private readonly Random _random = new();
        private readonly ObservableCollection<ObservablePoint> _observableValues;

        public StatisPart1ViewModel()
        {
            // Use ObservableCollections to let the chart listen for changes (or any INotifyCollectionChanged). // mark
            _observableValues = new ObservableCollection<ObservablePoint>
            {
                // Use the ObservableValue or ObservablePoint types to let the chart listen for property changes // mark
                // or use any INotifyPropertyChanged implementation // mark
                new ObservablePoint(_index++, 2),
                new(_index++, 5), // the ObservablePoint type is redundant and inferred by the compiler (C# 9 and above)
                new(_index++, 4),
                new(_index++, 5),
                new(_index++, 2),
                new(_index++, 6),
                new(_index++, 6),
                new(_index++, 6),
                new(_index++, 4),
                new(_index++, 2),
                new(_index++, 3),
                new(_index++, 8)
            };

            Series = new ObservableCollection<ISeries>
            {
                new ColumnSeries<ObservablePoint>
                {
                    Values = _observableValues
                }
            };
        }

        public ObservableCollection<ISeries> Series { get; set; }
    }

    class StatisPart2ViewModel
    {
        public ISeries[] Series { get; set; } =
        {
            new RowSeries<int>
            {
                Values = new List<int> { 8, -3, 4 },
                Stroke = null,
                DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45)),
                DataLabelsSize = 14,
                DataLabelsPosition = DataLabelsPosition.End
            },
            new RowSeries<int>
            {
                Values = new List<int> { 4, -6, 5 },
                Stroke = null,
                DataLabelsPaint = new SolidColorPaint(new SKColor(250, 250, 250)),
                DataLabelsSize = 14,
                DataLabelsPosition = DataLabelsPosition.Middle
            },
            new RowSeries<int>
            {
                Values = new List<int> { 6, -9, 3 },
                Stroke = null,
                DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45)),
                DataLabelsSize = 14,
                DataLabelsPosition = DataLabelsPosition.Start
            }
        };
    }

    class StatisPart3ViewModel
    {
        public StatisPart3ViewModel()
        {
            // you could convert any IEnumerable to a pie series collection
            var data = new double[] { 2, 4, 1, 4, 3 };

            // Series = data.AsLiveChartsPieSeries(); this could be enough in some cases // mark
            // but you can customize the series properties using the following overload: // mark

            Series = data.AsLiveChartsPieSeries((value, series) =>
            {
                // here you can configure the series assigned to each value.
                series.Name = $"Series for value {value}";
                series.DataLabelsPaint = new SolidColorPaint(new SKColor(30, 30, 30));
                series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Outer;
                series.DataLabelsFormatter = p => $"{p.PrimaryValue} / {p.StackedValue!.Total} ({p.StackedValue.Share:P2})";
            });
        }

        public IEnumerable<ISeries> Series { get; set; }
    }

    class StatisPart4ViewModel : BindableBase
    {
        public IEnumerable<ISeries> Series { get; set; }
         = new GaugeBuilder()
         .WithLabelsSize(50)
         .WithInnerRadius(75)
         .WithBackgroundInnerRadius(75)
         .WithBackground(new SolidColorPaint(new SKColor(100, 181, 246, 90)))
         .WithLabelsPosition(PolarLabelsPosition.ChartCenter)
         .AddValue(30, "gauge value", SKColors.YellowGreen, SKColors.Red) // defines the value and the color // mark
         .BuildSeries();
    }

    class StatisPart5ViewModel
    {
        public ISeries[] Series { get; set; } =
        {
            new LineSeries<double>
            {
                Values = new double[] { 3, 1, 4, 3, 2, -5, -2 },
                GeometrySize = 10,
                Fill = null
            },

            // use the second argument type to specify the geometry to draw for every point
            // there are already many predefined geometries in the
            // LiveChartsCore.SkiaSharpView.Drawing.Geometries namespace
            new LineSeries<double, LiveChartsCore.SkiaSharpView.Drawing.Geometries.RectangleGeometry>
            {
                Values = new double[] { 3, 3, -3, -2, -4, -3, -1 },
                Fill = null
            },

            // you can also define your own SVG geometry
            new LineSeries<double, MyGeometry>
            {
                Values = new double[] { -2, 2, 1, 3, -1, 4, 3 },

                Stroke = new SolidColorPaint(SKColors.DarkOliveGreen, 3),
                Fill = null,
                GeometryStroke = null,
                GeometryFill = new SolidColorPaint(SKColors.DarkOliveGreen),
                GeometrySize = 40
            }
        };
    }

    public class MyGeometry : LiveChartsCore.SkiaSharpView.Drawing.Geometries.SVGPathGeometry
    {
        // the static field is important to prevent the svg path is parsed multiple times // mark
        // Icon from Google Material Icons font.
        // https://fonts.google.com/icons?selected=Material%20Icons%20Outlined%3Atask_alt%3A
        public static SKPath svgPath = SKPath.ParseSvgPathData(
            "M22,5.18L10.59,16.6l-4.24-4.24l1.41-1.41l2.83,2.83l10-10L22,5.18z M19.79,10.22C19.92,10.79,20,11.39,20,12 " +
            "c0,4.42-3.58,8-8,8s-8-3.58-8-8c0-4.42,3.58-8,8-8c1.58,0,3.04,0.46,4.28,1.25l1.44-1.44C16.1,2.67,14.13,2,12,2C6.48,2,2,6.48,2,12 " +
            "c0,5.52,4.48,10,10,10s10-4.48,10-10c0-1.19-0.22-2.33-0.6-3.39L19.79,10.22z");

        public MyGeometry()
            : base(svgPath)
        { }

        public override void OnDraw(SkiaSharpDrawingContext context, SKPaint paint)
        {
            // lets also draw a white circle as background before the svg path is drawn
            // this will just make things look better

            using (var backgroundPaint = new SKPaint())
            {
                backgroundPaint.Style = SKPaintStyle.Fill;
                backgroundPaint.Color = SKColors.White;

                var r = Width / 2;
                context.Canvas.DrawCircle(X + r, Y + r, r, backgroundPaint);
            }

            base.OnDraw(context, paint);
        }
    }

    class StatisPart6ViewModel : BindableBase
    {
        public ISeries[] Series { get; set; } =
        {
            new StackedAreaSeries<double>
            {
                Values = new List<double> { 3, 2, 3, 5, 3, 4, 6 }
            },
            new StackedAreaSeries<double>
            {
                Values = new List<double> { 6, 5, 6, 3, 8, 5, 2 }
            },
            new StackedAreaSeries<double>
            {
                Values = new List<double> { 4, 8, 2, 8, 9, 5, 3 }
            }
        };
    }

    class StatisPart7ViewModel : BindableBase
    {
        public ISeries[] Series { get; set; } =
        {
            new HeatSeries<WeightedPoint>
            {
                HeatMap = new[]
                {
                    new SKColor(255, 241, 118).AsLvcColor(), // the first element is the "coldest"
                    SKColors.DarkSlateGray.AsLvcColor(),
                    SKColors.Blue.AsLvcColor() // the last element is the "hottest"
                },
                Values = new ObservableCollection<WeightedPoint>
                {
                    // Charles
                    new(0, 0, 150), // Jan
                    new(0, 1, 123), // Feb
                    new(0, 2, 310), // Mar
                    new(0, 3, 225), // Apr
                    new(0, 4, 473), // May
                    new(0, 5, 373), // Jun

                    // Richard
                    new(1, 0, 432), // Jan
                    new(1, 1, 312), // Feb
                    new(1, 2, 135), // Mar
                    new(1, 3, 78), // Apr
                    new(1, 4, 124), // May
                    new(1, 5, 423), // Jun

                    // Ana
                    new(2, 0, 543), // Jan
                    new(2, 1, 134), // Feb
                    new(2, 2, 524), // Mar
                    new(2, 3, 315), // Apr
                    new(2, 4, 145), // May
                    new(2, 5, 80), // Jun

                    // Mari
                    new(3, 0, 90), // Jan
                    new(3, 1, 123), // Feb
                    new(3, 2, 70), // Mar
                    new(3, 3, 123), // Apr
                    new(3, 4, 432), // May
                    new(3, 5, 142), // Jun
                },
            }
        };

            public Axis[] XAxes { get; set; } =
            {
            new Axis
            {
                Labels = new[] { "Charles", "Richard", "Ana", "Mari" }
            }
        };

            public Axis[] YAxes { get; set; } =
            {
            new Axis
            {
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" }
            }
        };
    }
}
