using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ForzaDataCollector
{
    public struct UdpState
    {
        public UdpClient u;
        public IPEndPoint e;
    }
}
