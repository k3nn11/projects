using System;
using System.Threading.Channels;

namespace LSP
{
    public abstract class Bird
    {
        public abstract void Fly();
        
    }

    public abstract class FlyingBird : Bird
    {
        public override void Fly()
        { Console.WriteLine("This bird flies"); }
    }
    public abstract class NonFlyingBird : Bird
    {
        public override void Fly()
        {
            Console.WriteLine("This bird cannot fly");
        }
       
    }

    public class Duck : FlyingBird
    {
        public override void Fly() => Console.WriteLine("Duck flies, quack-quack!");
    }

    public class Falcon : FlyingBird
    {
        public override void Fly() => Console.WriteLine("Falcon flies very fast");
    }

    public  class Ostrich : NonFlyingBird
    {
       public override void Fly() => throw new NotSupportedException("Ostrich can't fly");
        
    }

    public  class Penguin : NonFlyingBird
    {
         public override void Fly() => throw new InvalidOperationException("Penguin: - I wish I could, but...");
       
    }
}
