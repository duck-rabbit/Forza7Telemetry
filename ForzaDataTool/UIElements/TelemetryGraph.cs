using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ForzaDataTool.UIElements
{
    [AddINotifyPropertyChangedInterface]
    public abstract class TelemetryGraph : INotifyPropertyChanged
    {
        public static int Y_RESOLUTION = 100;

        public string GraphName { get; set; }

        public SolidColorBrush StrokeColor { get; set; }

        public string Val100 { get; set; }
        public string Val75 { get; set; }
        public string Val50 { get; set; }
        public string Val25 { get; set; }
        public string Val0 { get; set; }

        public PathGeometry GraphGeometry { get; set; }

        protected PathFigure graphFigure = new PathFigure();

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public TelemetryGraph(string name, Color color)
        {
            GraphName = name;
            StrokeColor = new SolidColorBrush(color);

            GraphGeometry = new PathGeometry();
            GraphGeometry.Figures = new PathFigureCollection();

            graphFigure.Segments = new PathSegmentCollection();

            GraphGeometry.Figures.Add(graphFigure);

        }

        public void UpdateGraph(int step, int value, bool reset = false)
        {
            if (reset)
            {
                graphFigure = new PathFigure();
                graphFigure.Segments = new PathSegmentCollection();
                graphFigure.StartPoint = new Point(0, YPointValue(value));

                return;
            }
            else
            {
                graphFigure.Segments.Add(new LineSegment(new Point(step, YPointValue(value)), true));
            }

            GraphGeometry.Figures[0] = graphFigure;
        }

        public abstract int YPointValue(int input);
    }
}
