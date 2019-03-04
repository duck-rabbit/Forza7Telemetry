using ForzaDataCollector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SectorSheet.xaml
    /// </summary>
    public partial class SectorSheet : Page
    {
        public static double TRACK_LENGTH = 1940;

        private int currentLap = -1;

        private int interStep = 0;

        private int[] interDistances = new int[] { 450, 735, 1005, 1350, 1580 };

        private float lapStartDistance;

        private float previousInterTime;

        public List<Lap> laps = new List<Lap>();

        public SectorSheet()
        {
            InitializeComponent();

            LapChart.ItemsSource = laps;

            var col = new DataGridTextColumn();
            col.Header = "Lap";
            col.Binding = new Binding("LapNo");
            LapChart.Columns.Add(col);

            col = new DataGridTextColumn();
            col.Header = "Lap Time";
            col.Binding = new Binding("LapTime");
            col.Binding.StringFormat = "m:ss.fff";
            LapChart.Columns.Add(col);

            for (int i = 0; i < interDistances.Length; i++)
            {
                col = new DataGridTextColumn();
                col.Header = string.Format("i{0} @{1}m", i + 1, interDistances[i]);
                col.Binding = new Binding(string.Format("InterTimes[{0}]", i));
                col.Binding.StringFormat = "m:ss.fff";
                LapChart.Columns.Add(col);
            }
        }

        public void UpdateSheet(DataPiece data)
        {
            if (data.LapNumber > currentLap)
            {
                if (data.LapNumber > 0)
                {
                    currentLap = (int)data.LapNumber;
                    lapStartDistance = data.DistanceTraveled.Value;

                    if (data.LapNumber >= 2)
                    {
                        laps[laps.Count - 1].LapTime = TimeSpan.FromSeconds((double)data.LastLap);
                    }

                    laps.Add(new Lap());
                    laps[laps.Count - 1].LapNo = currentLap;
                    laps[laps.Count - 1].InterTimes = new TimeSpan[6];

                    interStep = 0;

                    previousInterTime = data.CurrentRaceTime.Value;
                }

                return;
            }


            if (data.DistanceTraveled - lapStartDistance >= interDistances[interStep])
            {
                laps[laps.Count - 1].InterTimes[interStep] = TimeSpan.FromSeconds(data.CurrentRaceTime.Value - previousInterTime);

                interStep++;

                previousInterTime = data.CurrentRaceTime.Value;

                return;
            }
        }
    }
}
