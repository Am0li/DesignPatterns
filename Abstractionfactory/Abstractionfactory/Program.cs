using System;

namespace Abstractionfactory
{
    internal class Program
    {
        public interface Abstract_Scholl
        {
            Student return_student();
            Profesor return_profesor();

        }
        public interface Student
        {
            void attack();
        }
        public interface Profesor
        {
            void subject();
        }
        class Shool_of_Magic : Abstract_Scholl
        {
            public Student return_student()
            {
                return new Magic_Student();
            }
            public Profesor return_profesor()
            {
                return new Magic_Profesor();
            }
        }
        class Magic_Student : Student
        {
            public void attack()
            {
                Console.WriteLine("Fire magic misile");
            }
        }
        class Magic_Profesor : Profesor
        {
            public void subject()
            {
                Console.WriteLine("Control of magic");
            }
        }
        class Shool_of_Warriors : Abstract_Scholl
        {
            public Student return_student()
            {
                return new Warrior_Student();
            }
            public Profesor return_profesor()
            {
                return new Warrior_Profesor();
            }
        }
        class Warrior_Student : Student
        {
            public void attack()
            {
                Console.WriteLine("Strike with a sword");
            }
        }
        class Warrior_Profesor : Profesor
        {
            public void subject()
            {
                Console.WriteLine("Fundamentals of sword fighting");
            }
        }

        static void Main(string[] args)
        {
            Abstract_Scholl ms = new Shool_of_Magic();
            Abstract_Scholl ws = new Shool_of_Warriors();

            Student m = ms.return_student();
            Profesor mp = ms.return_profesor();
            m.attack();
            mp.subject();
            Console.WriteLine();
            Student w = ws.return_student();
            Profesor wp = ws.return_profesor();
            w.attack();
            wp.subject();

        }
    }
}
