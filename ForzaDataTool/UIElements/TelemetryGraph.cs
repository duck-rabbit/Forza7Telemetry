using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ForzaDataTool
{
    class TelemetryGraph
    {
        public int graphId;
        public string graphName;

        public int xResolution;
        public int yResolution;

        public int maxValue;
        public int minValue;

        private PathFigure graphGeometry;

        public TelemetryGraph()
        {
            graphGeometry = new PathFigure();
            graphGeometry.Segments = new PathSegmentCollection();

            ((PathGeometry)ThrottleGraph.Data).Figures.Add(throttleGraphGeometry);
        }

        public void UpdateGraph(int step, int value, bool reset = false)
        {
            if (reset)
            {
                graphGeometry = new PathFigure();
                graphGeometry.Segments = new PathSegmentCollection();
                graphGeometry.StartPoint = new Point(0, 100 - (double)value * 0.39215d);

                ((PathGeometry)ThrottleGraph.Data).Figures[0] = throttleGraphGeometry;

                return;
            }
            else
            {
                graphGeometry.Segments.Add(new LineSegment(new Point(distanceStep, 100 - (double)data.Accel * 0.39215d), true));
                ((PathGeometry)ThrottleGraph.Data).Figures[0] = throttleGraphGeometry;
            }
        }
    }
}
