using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Traffic_Controller_Emulator
{
    public abstract class Traffic_Controller : RoadBase
    {
        public bool _rightarmExtended = true, _leftarmExtended = true;
        public bool _standingLeftside = true, _standingRightside = true;
        public bool _isFaceForward = true;
        public bool _movestraight = true;
        public bool _turnright, _turnleft = true;

        public Traffic_Controller()
        {
        }

        public bool BooleanChoice()
        {
            int number = _random.Next(0, 2);
            if (number == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
