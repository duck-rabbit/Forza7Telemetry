using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForzaDataCollector;

namespace ForzaDataTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader str = new StreamReader(4247);
            DataWriter dataWriter = new DataWriter();
            str.RegisterConsumer(dataWriter);
            str.StartListening();
            Console.ReadKey();
            str.UnregisterConsumer(dataWriter);
            str.StopListening();
        }
    }

    class DataWriter : IDataHandler
    {
        public void HandleData(DataPiece dataPiece)
        {
            Console.Clear();
            Console.WriteLine(dataPiece.IsRaceOn == 1 ? "Race is on." : "Race is off.");
            Console.WriteLine(String.Format("RPM: {0}", dataPiece.CurrentEngineRpm));
            Console.WriteLine(String.Format("Gear: {0}", dataPiece.Gear));
            Console.WriteLine(String.Format("Speed: {0}", dataPiece.Speed * 3.6f));
        }
    }
}
