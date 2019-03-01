using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ForzaDataTool.UIElements
{
    public class PercentageFromByteGraph : TelemetryGraph
    {
        public PercentageFromByteGraph(string name, Color color) : base(name, color)
        {
            Val0 = "0%";
            Val25 = "25%";
            Val50 = "50%";
            Val75 = "75%";
            Val100 = "100%";
        }

        public override int YPointValue(int input)
        {
            return (int)(Y_RESOLUTION - input / (float)255 * Y_RESOLUTION);
        }
    }
}
