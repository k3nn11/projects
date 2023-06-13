using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Controller_Emulator
{
    public class SecondController :Traffic_Controller
    {
        public void Controller(object source, LaneEventArgs e)
        {
            if (_isFaceForward == BooleanChoice())
            {
                if (_rightarmExtended != BooleanChoice())
                {
                    Console.WriteLine("STOP!! Movement not allowed");
                    return;
                }

                Console.WriteLine("Second Controller:");
                if (e.Lane.IsRightturn != true)
                {
                    Console.WriteLine("STOP!! Movement not allowed");
                    return;
                }

                _turnright = true;
                Console.WriteLine(e.Lane.LaneName + ", Turn right");
            }
            else
            {
                Console.WriteLine("STOP!! Movement not allowed");
            }
        }
    }
}
