using System;

namespace Traffic_Controller_Emulator
{
    public class LaneSelection : LaneEventArgs
    {
        private readonly Random _random = new Random();

        public LaneSelection()
        {
        }

        public event RoadEventHandler Roadevent;

        public void GetLane( Lane lane)
        {
            var number = _random.Next(0, 2);
            string name;
            switch (number)
            {
                case 0:
                    name = "on the Right lane";
                    lane.LaneName = name;
                    lane.IsRightturn = true;
                    break;
                case 1:
                    name = "on the left lane";
                    lane.LaneName = name;
                    lane.IsRightturn = false;
                    break;
                default:
                    break;
            }

            OnRoadEvent(lane);
        }

        protected virtual void OnRoadEvent(Lane l)
        {
            if (Roadevent != null)
            {
                Roadevent(this, new LaneEventArgs() { Lane = l});
            }
        }
    }
}
