using System;
using System.Collections.Generic;
using System.Text;

namespace ForzaDataCollector
{
    public interface IDataHandler
    {
        void HandleData(DataPiece dataPiece);
    }
}
