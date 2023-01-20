using System;
using System.Collections.Generic;

namespace Observer
{
    interface Ifuncion
    {
        public abstract void perform(string name);
    }
    class Lights_On : Ifuncion
    {
        public void perform(string name)
        {
            Console.WriteLine("Lights turn on in " + name);
        }
    }
    class Air_Condtioner_On : Ifuncion
    {
        public void perform(string name)
        {
            Console.WriteLine("Aircondtioner turn on in " + name);
        }
    }
    class Kettel_On : Ifuncion
    {
        public void perform(string name)
        {
            Console.WriteLine("Kettel turn on in " + name);
        }
    }
    class Room
    {
        string name;
        List<Ifuncion> funcions;
        public Room(string name)
        {
            this.name = name;
            funcions = new List<Ifuncion>();
        }
        public void add_function(Ifuncion f)
        {
            funcions.Add(f);
        }
        public void remove_function(Ifuncion f)
        {
            funcions.Remove(f);
        }
        public void do_function()
        {
            Console.WriteLine("You entered: " + name);
            foreach (Ifuncion f in funcions)
            {
                f.perform(name);
            }
        }
    }
    class House
    {
        List<Room> room_list;
        public House()
        {
            room_list = new List<Room>();
            room_list.Add(new Room("Bedroom"));
            room_list.Add(new Room("Kitchen"));
            room_list.Add(new Room("Bathroom"));

            room_list[0].add_function(new Lights_On());
            room_list[1].add_function(new Lights_On());
            room_list[2].add_function(new Lights_On());

            room_list[0].add_function(new Air_Condtioner_On());
            room_list[1].add_function(new Air_Condtioner_On());
            room_list[2].add_function(new Air_Condtioner_On());

            room_list[1].add_function(new Kettel_On());
        }
        public void Simulate()
        {
            string action = "";

            while (action != "0")
            {
                Console.WriteLine("What room do you enter?");
                Console.WriteLine("0-exit house");
                Console.WriteLine("1-Bedroom");
                Console.WriteLine("2-Kitchen");
                Console.WriteLine("3-Bathroom");
                action = Console.ReadLine();
                if (action != "0")
                {
                    room_list[Convert.ToInt32(action) - 1].do_function();
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            House h = new House();
            h.Simulate();
        }
    }
}
