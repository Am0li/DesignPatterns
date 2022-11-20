using System;
using System.Collections.Generic;

namespace Flyweight
{
    internal class Program
    {
        class Textura
        {
            protected string color;

            public override string ToString()
            {
                return color;
            }
        }
        class Player
        {
            string name;
            public Player(string name)
            {
                this.name = name;
            }

            public override string ToString()
            {
                return name;
            }
        }
        class Unit
        {
            protected Textura textura;
            protected int hp;
            protected int x, y;
            protected Player player;
            public Unit(int hp , int x, int y, Player player)
            {
                this.hp= hp;
                this.x= x;
                this.y= y;
                this.player = player;
            }
            public virtual void show()
            {
                Console.WriteLine("Textura: " + textura + " ,HP: " + hp + " ,Pozycja: (" + x + "," + y + ") Gracz: " + player);
            }
        }
        class TexturaKnight:Textura
        {
            public TexturaKnight()
            {
                color = "Grey";
            }
            public override string ToString()
            {
                return color;
            }
        }
        class Knight : Unit
        {
            public Knight(Textura t,int hp, int x, int y, Player player):base(hp,x,y,player)
            {
                textura = t;
            }
            public override void show()
            {
                Console.Write("Knight ,");
                base.show();
            }
        }
        class TexturaCannon : Textura
        {
            public TexturaCannon()
            {
                color = "Brown";
            }
            public override string ToString()
            {
                return color;
            }
        }
        class Cannon : Unit
        {
            public Cannon(Textura t, int hp, int x, int y, Player player) : base(hp, x, y, player)
            {
                textura = t;
            }
            public override void show()
            {
                Console.Write("Cannon ,");
                base.show();
            }
        }
        class TexturaVilager : Textura
        {
            public TexturaVilager()
            {
                color = "Red";
            }
            public override string ToString()
            {
                return color;
            }
        }
        class Vilager : Unit
        {
            public Vilager(Textura t,int hp, int x, int y, Player player) : base(hp, x, y, player)
            {
                textura = t;
            }
            public override void show()
            {
                Console.Write("Vilager ,");
                base.show();
            }
        }
        static void Main(string[] args)
        {
            Textura tk = new TexturaKnight();
            Textura tc = new TexturaCannon();
            Textura tv = new TexturaVilager();
            Player p1 = new Player("Player1");
            Player p2 = new Player("Player2");
            Player p3 = new Player("Player3");
            List<Unit> units = new List<Unit>();
            units.Add(new Knight(tk, 1000, 0, 0, p1));
            units.Add(new Knight(tk, 1000, 0, 0, p1));
            units.Add(new Knight(tk, 1000, 0, 0, p1));
            units.Add(new Knight(tk, 1000, 0, 0, p1));
            units.Add(new Knight(tk, 1000, 0, 0, p1));
            units.Add(new Knight(tk, 1000, 0, 0, p1));
            units.Add(new Knight(tk, 1000, 0, 0, p1));
            units.Add(new Knight(tk, 1000, 0, 0, p1));
            units.Add(new Cannon(tc, 3000, 0, 0, p2));
            units.Add(new Cannon(tc, 3000, 0, 0, p2));
            units.Add(new Cannon(tc, 3000, 0, 0, p2));
            units.Add(new Cannon(tc, 3000, 0, 0, p2));
            units.Add(new Cannon(tc, 3000, 0, 0, p2));
            units.Add(new Cannon(tc, 3000, 0, 0, p2));
            units.Add(new Cannon(tc, 3000, 0, 0, p2));
            units.Add(new Vilager(tv, 400, 0, 0, p3));
            units.Add(new Vilager(tv, 400, 0, 0, p3));
            units.Add(new Vilager(tv, 400, 0, 0, p3));
            units.Add(new Vilager(tv, 400, 0, 0, p3));
            units.Add(new Vilager(tv, 400, 0, 0, p3));
            units.Add(new Vilager(tv, 400, 0, 0, p3));
            units.Add(new Vilager(tv, 400, 0, 0, p3));
            units.Add(new Vilager(tv, 400, 0, 0, p3));
            units.Add(new Vilager(tv, 400, 0, 0, p3));
            foreach(Unit unit in units)
            {
                unit.show();
            }




        }
    }
}
