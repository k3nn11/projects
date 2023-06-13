using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Controller_Emulator
{
    public delegate void RoadEventHandler(object source, LaneEventArgs e);

    public class LaneEventArgs : EventArgs
    {
        public Lane Lane { get; set; }
    }
}
