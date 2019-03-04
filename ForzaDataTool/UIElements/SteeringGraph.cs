using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ForzaDataTool.UIElements
{
    public class SteeringGraph : TelemetryGraph
    {
        public SteeringGraph(string name, Color color) : base(name, color)
        {
            Val0 = "R";
            Val25 = "";
            Val50 = "N";
            Val75 = "";
            Val100 = "L";
        }

        public override int YPointValue(int input)
        {
            return (int)((Y_RESOLUTION / 2) + input / (float)127 * Y_RESOLUTION / 2);
        }
    }
}
