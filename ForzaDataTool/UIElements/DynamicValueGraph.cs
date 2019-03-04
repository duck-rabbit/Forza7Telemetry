using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ForzaDataTool.UIElements
{
    class DynamicValueGraph : TelemetryGraph
    {
        private int _maxValue = 0;

        public DynamicValueGraph(string name, Color color) : base(name, color)
        {
            ChangeMaxValue(0);
        }

        public override int YPointValue(int input)
        {
            if (input > _maxValue)
                ChangeMaxValue(input);

            return (int)(Y_RESOLUTION - input / (float)_maxValue * Y_RESOLUTION);
        }

        public void ChangeMaxValue(int value)
        {
            int oldMaxValue = _maxValue;
            _maxValue = ((value / 50)  + 1) * 50 ;
            double fraction = (double)oldMaxValue / (double)_maxValue;

            Val0 = 0.ToString();
            Val25 = (_maxValue / 4).ToString();
            Val50 = (_maxValue / 2).ToString();
            Val75 = (_maxValue / 4 * 3).ToString();
            Val100 = _maxValue.ToString();

            foreach (LineSegment segment in graphFigure.Segments)
            {
                segment.Point = new Point(segment.Point.X, Y_RESOLUTION * (1 - fraction) + segment.Point.Y * fraction);
            }
        }
    }
}
