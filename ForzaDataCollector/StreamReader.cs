using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;

namespace ForzaDataCollector
{
    public class StreamReader
    {
        IPEndPoint _udpEndpoint;
        UdpClient _udpClient;
        DataAnnouncer _announcer;
        Thread _listenThread;
        ManualResetEvent _resetEvent;

        public StreamReader(int port)
        {
            _listenThread = new Thread(Listen);

            //_udpEndpoint = new IPEndPoint(IPAddress.Any, port);
            _udpClient = new UdpClient(port);

            _announcer = new DataAnnouncer();

            _resetEvent = new ManualResetEvent(true);
        }

        public void StartListening()
        {
            //_udpClient.Connect(_udpEndpoint);

            if (!_listenThread.IsAlive)
            {
                _listenThread.Start();
            }
        }

        public void StopListening()
        {
            if (_listenThread.IsAlive)
            {
                _listenThread.Abort();
            }

            _udpClient.Close();
        }

        public void RegisterConsumer(IDataHandler handler)
        {
            _announcer.RegisterHandler(handler);
        }

        public void UnregisterConsumer(IDataHandler handler)
        {
            _announcer.UnregisterHandler(handler);
        }

        private void Listen()
        {
            while (true)
            {
                _resetEvent.Reset();
                UdpState state = new UdpState();
                state.e = _udpEndpoint;
                state.u = _udpClient;

                //Console.WriteLine("Listening");
                //_udpClient.BeginReceive(new AsyncCallback(DataReceived), null);

                //_resetEvent.WaitOne();

                byte[] data = _udpClient.Receive(ref _udpEndpoint);

                DataPiece dataPiece = new DataPiece(data);
                _announcer.AnnounceData(dataPiece);
            }
        }

        public void DataReceived(IAsyncResult ar)
        {
            //Console.WriteLine("DataReceived!");
            byte[] data = _udpClient.EndReceive(ar, ref _udpEndpoint);

            _resetEvent.Set();

            DataPiece dataPiece = new DataPiece(data);
            _announcer.AnnounceData(dataPiece);
        }
    }
}
