using System;
using System.Threading;

namespace State
{
    abstract class Service
    {
        public abstract void work();
        public abstract bool done();
        public abstract Service next_state();
    }
    class Automat : Service
    {
        public override void work()
        {
            Console.WriteLine("State your issue");    
        }
        public override bool done()
        {
            Random rand = new Random();
            bool next = Convert.ToBoolean(rand.Next(0, 2));
            if (!next)
            {
                Console.WriteLine("Zakończono połączenie");
            }
            return next;
        }
        public override Service next_state()
        {
            return new Call_Querry();
        }
    }
    class Call_Querry : Service
    {
        public override void work()
        {
            Console.WriteLine("waiting for I line IT Support");
        }
        public override bool done()
        {
            Random rand = new Random();
            bool next = Convert.ToBoolean(rand.Next(0, 2));
            if (!next)
            {
                Console.WriteLine("Zakończono połączenie");
            }
            return next;
        }

        public override Service next_state()
        {
            return new Iline();
        }
    }
    class Iline : Service
    {
        public override void work()
        {
            Console.WriteLine("Talkig with I line IT Support");
        }
        public override bool done()
        {
            Random rand = new Random();
            bool next = Convert.ToBoolean( rand.Next(0,2));
            if (!next)
            {
                Console.WriteLine("Zakończono połączenie");
            }
            return next;
        }

        public override Service next_state()
        {
            return new IIline();
        }
    }
    class IIline : Service
    {
        public override void work()
        {
            Console.WriteLine("Talkig with II line IT Support");
        }
        public override bool done()
        {
            Console.WriteLine("Zakończono połączenie");
            return false;
        }

        public override Service next_state()
        {
            return new Automat();
        }
    }
    class Call
    {
        Service service;
        public Call()
        {
            service = new Automat();
        }
        void set_state()
        {
            service = service.next_state();
        }
        public void start_call()
        {
            service.work();
            Thread.Sleep(1000);
            if(service.done())
            {
                set_state();
                start_call();
            }

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Call call = new Call();
            call.start_call();
        }
    }
}
