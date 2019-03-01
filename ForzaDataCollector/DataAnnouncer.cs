using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ForzaDataCollector
{
    public class DataAnnouncer
    {
        private List<IDataHandler> dataHandlers = new List<IDataHandler>();

        public void RegisterHandler(IDataHandler handler)
        {
            if (!dataHandlers.Contains(handler))
                dataHandlers.Add(handler);
            else
                throw (new ArgumentException("Data handler already in use."));
        }

        public void UnregisterHandler(IDataHandler handler)
        {
            if (dataHandlers.Contains(handler))
                dataHandlers.Remove(handler);
            else
                throw (new ArgumentException("Data handler was not registered thus cannot be removed."));
        }

        public void AnnounceData(DataPiece data)
        {
            dataHandlers.ForEach(handler => handler.HandleData(data));
        }
    }
}
