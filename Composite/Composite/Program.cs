using System;
using System.Collections.Generic;

namespace Composite
{
    internal class Program
    {
        abstract class Thing
        {
            public virtual void add(Thing t)
            {

            }
            public virtual void remove(int n)
            {

            }
            public abstract float returnvalue();
            public virtual bool isBox()
            {
                return true;
            }
        }
        class Product:Thing
        {
            float valu;
            public Product(float valu)
            {
                this.valu = valu;
            }

            public override float returnvalue()
            {
                return valu;
            }
            public override bool isBox()
            {
                return false;
            }
        }
        class Box:Thing
        {
            List<Thing> things;
            public Box()
            {
                things = new List<Thing>();
            }
            public override void add(Thing t)
            {
               things.Add(t);
            }
            public override void remove(int n)
            {
                things.RemoveAt(n);
            }
            public override float returnvalue()
            {
                float sum = 0;
                foreach(Thing t in things)
                {
                    sum+=t.returnvalue();
                }
                return sum;
            }

        }
        static void Main(string[] args)
        {
            Thing box1 = new Box();
            Thing box2 = new Box();
            Thing box3 = new Box();
            Thing box4 = new Box();
            box1.add(box2);
            box2.add(box3);
            box1.add(box4);
            box2.add(new Product((float)1));
            box3.add(new Product((float)1));
            box3.add(new Product((float)1));
            box3.add(new Product((float)1));
            box4.add(new Product((float)1));
            Console.WriteLine(box1.returnvalue());

        }
    }
}
