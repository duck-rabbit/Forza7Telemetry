using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ForzaDataTool
{
    public class TelemetryGraph
    {
        public string GraphName { get; set; }

        public SolidColorBrush StrokeColor { get; set; }

        public string Val100 { get; set; }
        public string Val75 { get; set; }
        public string Val50 { get; set; }
        public string Val25 { get; set; }
        public string Val0 { get; set; }

        public PathFigure GraphGeometry { get; set; }

        public TelemetryGraph(string name, Color color)
        {
            GraphName = name;
            StrokeColor = new SolidColorBrush(color);

            Val0 = "0%";
            Val25 = "25%";
            Val50 = "50%";
            Val75 = "75%";
            Val100 = "100%";

            GraphGeometry = new PathFigure();
            GraphGeometry.Segments = new PathSegmentCollection();

        }

        public void UpdateGraph(int step, int value, bool reset = false)
        {
            if (reset)
            {
                GraphGeometry = new PathFigure();
                GraphGeometry.Segments = new PathSegmentCollection();
                GraphGeometry.StartPoint = new Point(0, 100 - (double)value * 0.39215d);

                return;
            }
            else
            {
                GraphGeometry.Segments.Add(new LineSegment(new Point(step, 100 - (double)value * 0.39215d), true));
            }
        }
    }
}
