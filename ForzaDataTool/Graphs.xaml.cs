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

        public List<Graphs> graphs = new List<Graphs>();

        public Graphs()
        {
            InitializeComponent();

            ((App)App.Current).dataHandler += UpdateGraphs;
        }

        public void UpdateGraphs(DataPiece data)
        {
            if (data.LapNumber > currentLap)
            {
                xResolution = TRACK_LENGTH / ThrottleCanvas.ActualWidth;

                currentLap = (int)data.LapNumber;
                lapStartDistance = data.DistanceTraveled.Value;
                distanceStep = 0;

                

                distanceStep++;

                return;
            }

            if (data.DistanceTraveled >= lapStartDistance + (distanceStep * xResolution))
            {
                distanceStep++;
                return;
            }
        }


    }
}
