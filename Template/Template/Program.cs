using System;

namespace Template
{
    interface IRumba
    {
        public void forward()
        {
            Console.WriteLine("Rumba goes forward");
        }
        public void left()
        {
            Console.WriteLine("Rumba turns left");
        }
        public void right()
        {
            Console.WriteLine("Rumba turns right");
        }
        public void sound()
        {
            Console.WriteLine("Rumb gives sound signal");
        }
        public void mop()
        {
            Console.WriteLine("Rumba uses mop");
        }
        public void lights()
        {
            Console.WriteLine("Rumba gives light signal");
        }
    }
    class Rumba_A : IRumba
    {
        public void mop() { }
    }
    class Rumba_B : IRumba
    {
        public void lights() { }
    }
    
    internal class Program
    {
        public static void simulation(IRumba r)
        {
            r.forward();
            r.left();
            r.right();
            r.lights();
            r.sound();
            r.mop();
        }
        static void Main(string[] args)
        {
            IRumba a = new Rumba_A();
            IRumba b = new Rumba_B();
            Console.WriteLine("Rumba_1");
            simulation(a);
            Console.WriteLine("Rumba_2");
            simulation(b);

        }
    }
}
