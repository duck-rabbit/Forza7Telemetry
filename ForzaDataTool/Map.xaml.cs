using ForzaDataCollector;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ForzaDataTool
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : Page
    {
        private PathFigure graphFigure = new PathFigure();

        private PathGeometry graphGeometry = new PathGeometry();

        private bool drawing = false;

        public Map()
        {
            InitializeComponent();

            graphGeometry.Figures = new PathFigureCollection();

            graphFigure.Segments = new PathSegmentCollection();

            graphGeometry.Figures.Add(graphFigure);

            MapPath.Data = graphGeometry;

            ((App)App.Current).dataHandler += UpdateGraph;
        }

        public void UpdateGraph(DataPiece data)
        {
            if (!drawing)
            {
                graphFigure = new PathFigure();
                graphFigure.Segments = new PathSegmentCollection();
                graphFigure.StartPoint = new Point(MapCanvas.ActualWidth -(double)data.PositionX - 350, MapCanvas.ActualHeight + (double)data.PositionZ + 30);

                drawing = true;
            }
            else
            {
                graphFigure.Segments.Add(new LineSegment(new Point(MapCanvas.ActualWidth - (double)data.PositionX - 350, MapCanvas.ActualHeight + (double)data.PositionZ + 30), true));
            }

            graphGeometry.Figures[0] = graphFigure;

            MapPath.Data = graphGeometry;
        }
    }
}
