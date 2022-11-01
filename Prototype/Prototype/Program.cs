using System;

namespace Prototype
{
    internal class Program
    {
        public class Adventurer
        {
            public int age;
            public string name;
            public string battleclass;
            public AdventureId adventureId;

            public Adventurer ShallowCopy()
            {
                return (Adventurer)this.MemberwiseClone();
            }

            public Adventurer DeepCopy()
            {
                Adventurer clone = (Adventurer)this.MemberwiseClone();
                clone.adventureId = new AdventureId(adventureId.idNumber);
                clone.name = String.Copy(name);
                clone.battleclass = String.Copy(battleclass);
                return clone;
            }
        }

        public class AdventureId
        {
            public int idNumber;

            public AdventureId(int idNumber)
            {
                this.idNumber = idNumber;
            }
        }
        static void Main(string[] args)
        {
            Adventurer a1 = new Adventurer();
            a1.age = 42;
            a1.name = "Jack Daniels";
            a1.battleclass = "Mage";
            a1.adventureId = new AdventureId(666);
            Adventurer a2 = a1.ShallowCopy();
            Adventurer a3 = a1.DeepCopy();
            Console.WriteLine("{0},{1},{2},{3}",a1.age,a1.name,a1.battleclass,a1.adventureId.idNumber);
            Console.WriteLine("{0},{1},{2},{3}",a2.age,a2.name,a2.battleclass,a2.adventureId.idNumber);
            Console.WriteLine("{0},{1},{2},{3}",a3.age,a3.name,a3.battleclass,a3.adventureId.idNumber);


        }
    }
}
