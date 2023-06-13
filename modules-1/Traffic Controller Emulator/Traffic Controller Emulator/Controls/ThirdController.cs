using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Controller_Emulator
{
    public class ThirdController : Traffic_Controller
    {
        public void Controller(object source, LaneEventArgs e)
        {
            if (_standingLeftside == BooleanChoice())
            {
                if (_rightarmExtended != BooleanChoice())
                {
                    Console.WriteLine("STOP!! Movement not allowed");
                    return;
                }

                Console.WriteLine("Third controller :");
                _movestraight = true;
                Console.Write("Drive straight , " + e.Lane.LaneName + " ");
                if ( e.Lane.IsRightturn != true)
                {
                     _turnleft = true;
                     Console.WriteLine(" or turn left ");
                     return;
                }

                _turnright = true;
                Console.WriteLine(" or turn right ");
            }
            else
            {
                Console.WriteLine("STOP!! Movement not allowed");
            }
        }
    }
}
