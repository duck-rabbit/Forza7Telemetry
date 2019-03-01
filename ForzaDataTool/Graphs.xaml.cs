using ForzaDataCollector;
using ForzaDataTool.UIElements;
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

            graphs.Add(new DynamicValueGraph("SPEED", Colors.Yellow));
            graphs.Add(new PercentageFromByteGraph("THROTTLE", Colors.LightGreen));
            graphs.Add(new PercentageFromByteGraph("BRAKE", Colors.Red));
            graphs.Add(new SteeringGraph("STEERING", Colors.White));
            graphs.Add(new DynamicValueGraph("RPM", Colors.LightGoldenrodYellow));
            graphs.Add(new DynamicValueGraph("POWER", Colors.OrangeRed));
            graphs.Add(new DynamicValueGraph("TORQUE", Colors.Magenta));

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

                    graphs[0].UpdateGraph(0, (int)(data.Speed * 3.6f), true);
                    graphs[1].UpdateGraph(0, (int)data.Accel, true);
                    graphs[2].UpdateGraph(0, (int)data.Brake, true);
                    graphs[3].UpdateGraph(0, (int)data.Steer, true);
                    graphs[4].UpdateGraph(0, (int)data.CurrentEngineRpm, true);
                    graphs[5].UpdateGraph(0, (int)data.Power, true);
                    graphs[6].UpdateGraph(0, (int)data.Torque, true);

                    distanceStep++;

                    return;
                }

                if (data.DistanceTraveled >= lapStartDistance + (distanceStep * xResolution))
                {
                    graphs[0].UpdateGraph(distanceStep, (int)(data.Speed * 3.6f));
                    graphs[1].UpdateGraph(distanceStep, (int)data.Accel);
                    graphs[2].UpdateGraph(distanceStep, (int)data.Brake);
                    graphs[3].UpdateGraph(distanceStep, (int)data.Steer);
                    graphs[4].UpdateGraph(distanceStep, (int)data.CurrentEngineRpm);
                    graphs[5].UpdateGraph(distanceStep, (int)data.Power);
                    graphs[6].UpdateGraph(distanceStep, (int)data.Torque);

                    distanceStep++;
                    return;
                }
            }
        }


    }
}
