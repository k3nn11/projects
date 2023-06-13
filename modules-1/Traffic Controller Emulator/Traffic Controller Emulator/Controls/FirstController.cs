using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Controller_Emulator
{
    public class FirstController : Traffic_Controller
    {
        public void Controller(object source, LaneEventArgs e)
        {
            if (_standingRightside == BooleanChoice() || _standingLeftside == BooleanChoice())
            {
                if (_leftarmExtended != BooleanChoice() && _rightarmExtended != BooleanChoice())
                {
                    Console.WriteLine("STOP!!Movement not allowed");
                    return;
                }

                Console.WriteLine("First controller: ");
                _movestraight = true;
                Console.Write("Drive straight, " + e.Lane.LaneName + " ");
                if (e.Lane.IsRightturn == true)
                {
                    Console.WriteLine("STOP!!Movement not allowed");
                    return;
                }

                _turnright = true;
                Console.WriteLine(" or turn right ");
                return;
            }
            else
            {
                Console.WriteLine("STOP!! Movement not allowed");
            }
        }
    }
}
