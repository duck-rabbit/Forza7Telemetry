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
    /// Interaction logic for Graphs.xaml
    /// </summary>
    public partial class Graphs : Page
    {
        public static double TRACK_LENGTH = 720;
        public static double Y_RESOLUTION = 255;

        private double xResolution;

        private int currentLap = -1;

        private float lapStartDistance;

        private int distanceStep;

        public List<TelemetryGraph> graphs = new List<TelemetryGraph>();

        public Graphs()
        {
            InitializeComponent();

            DataContext = new
            {
                teleGraphs = graphs
            };

            graphs.Add(new TelemetryGraph("THROTTLE", Colors.LightGreen));
            graphs.Add(new TelemetryGraph("BRAKE", Colors.Red));
            graphs.Add(new TelemetryGraph("STEERING", Colors.White));

            graphHolder.ItemsSource = graphs;

            ((App)App.Current).dataHandler += UpdateGraphs;
        }

        public void UpdateGraphs(DataPiece data)
        {
            if (data.IsRaceOn == 1)
            {
                if (data.LapNumber > currentLap)
                {
                    xResolution = TRACK_LENGTH / 1500d;

                    currentLap = (int)data.LapNumber;
                    lapStartDistance = data.DistanceTraveled.Value;
                    distanceStep = 0;

                    graphs[0].UpdateGraph(0, (int)data.Accel, true);
                    graphs[1].UpdateGraph(0, (int)data.Brake, true);
                    graphs[2].UpdateGraph(0, (int)data.Steer, true);

                    distanceStep++;

                    return;
                }

                if (data.DistanceTraveled >= lapStartDistance + (distanceStep * xResolution))
                {
                    graphs[0].UpdateGraph(distanceStep, (int)data.Accel);
                    graphs[1].UpdateGraph(distanceStep, (int)data.Brake);
                    graphs[2].UpdateGraph(distanceStep, (int)data.Steer);

                    distanceStep++;
                    return;
                }
            }
        }


    }
}
