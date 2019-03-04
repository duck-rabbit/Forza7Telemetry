using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ForzaDataCollector;

namespace ForzaDataTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IDataHandler
    {
        StreamReader str = new StreamReader(4247);
        public delegate void DataDelegate(DataPiece dataPiece);

        public DataDelegate dataHandler;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            str.RegisterConsumer(this);
            str.StartListening();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            str.UnregisterConsumer(this);
            str.StopListening();
            base.OnExit(e);
        }

        public void HandleData(DataPiece dataPiece)
        {
            if (dataHandler != null)
            {
                if (dataPiece.IsRaceOn == 1)
                    Dispatcher.Invoke(dataHandler, dataPiece);
            }
        }
    }
}
