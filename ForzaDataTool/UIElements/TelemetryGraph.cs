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
    public abstract class TelemetryGraph : INotifyPropertyChanged
    {
        public static int Y_RESOLUTION = 100;

        public string GraphName { get; set; }

        public SolidColorBrush StrokeColor { get; set; }

        private string val100;
        private string val75;
        private string val50;
        private string val25;
        private string val0;

        public string Val100
        {
            get { return val100; }
            set
            {
                if (val100 == value)
                    return;

                val100 = value;
                NotifyPropertyChanged("Val100");
            }
        }

        public string Val75
        {
            get { return val75; }
            set
            {
                if (val75 == value)
                    return;

                val75 = value;
                NotifyPropertyChanged("Val75");
            }
        }

        public string Val50
        {
            get { return val50; }
            set
            {
                if (val50 == value)
                    return;

                val50 = value;
                NotifyPropertyChanged("Val50");
            }
        }

        public string Val25
        {
            get { return val25; }
            set
            {
                if (val25 == value)
                    return;

                val25 = value;
                NotifyPropertyChanged("Val25");
            }
        }

        public string Val0
        {
            get { return val0; }
            set
            {
                if (val0 == value)
                    return;

                val0 = value;
                NotifyPropertyChanged("Val0");
            }
        }

        public PathGeometry GraphGeometry { get; set; }

        protected PathFigure graphFigure = new PathFigure();

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

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
