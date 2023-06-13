using System;

namespace Traffic_Controller_Emulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            LaneSelection road = new LaneSelection();
            Lane lane = new Lane();
            FirstController firstcontroller = new FirstController();
            SecondController secondController = new SecondController();
            ThirdController thirdController = new ThirdController();
            road.Roadevent += firstcontroller.Controller;
            road.Roadevent += secondController.Controller;
            road.Roadevent += thirdController.Controller;
            //Traffic_Controller firstcontroller = new FirstController();
            //Traffic_Controller secondcontroller = new SecondController();
            //Traffic_Controller traffic_ = new ThirdController();
            road.GetLane(lane);
        }
    }
}
