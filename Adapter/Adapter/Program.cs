using System;

namespace Adapter
{
    internal class Program
    {
        public class BasicShapes
        {
            public void drawline(int x1, int x2, int y1, int y2)
            {
                Console.WriteLine("Drawing line between ({0},{1}) and ({2},{3})",x1,y1,x2,y2);
            }
            public void drawcirle(int x, int y, int r)
            {
                Console.WriteLine("Drawing circle with center in ({0},{1}) and radius of {2})", x, y, r); ;
            }
            public void drawrectangle(int x, int y, int h, int w)
            {
                Console.WriteLine("Drawing rectangle with top-left corner in ({0},{1}), hight of {2}) and width of {3}", x, y, h, w);
            }
        }
        public interface Drawing
        {
            void drawcar(int x,int y, int size);
            void drawrabbit(int x, int y, int size);
        }
        public class Adapter:Drawing
        {
            BasicShapes basicShapes;
            public Adapter()
            {
                basicShapes = new BasicShapes();
            }
            public void drawcar(int x, int y, int size)
            {
                //main body of car
                basicShapes.drawrectangle(x, y, 3 * size, 8 * size);
                //wheels
                basicShapes.drawcirle(x+3 * size,y+size, size);
                basicShapes.drawcirle(x+3 * size, y+7*size, size);
            }
            public void drawrabbit(int x, int y, int size)
            {
                //ears
                basicShapes.drawrectangle(x,y,3*size,size);
                basicShapes.drawrectangle(x+size,y,3*size,size);
                //head
                basicShapes.drawcirle(x + 3 * size, y + size, size);

            }
        }
        static void Main(string[] args)
        {
            Drawing drawing = new Adapter();
            drawing.drawrabbit(0, 0, 2);
            Console.WriteLine();
            drawing.drawcar(0, 0, 2);
        }
    }
}
