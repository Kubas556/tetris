using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tetris.Shapes;

namespace Tetris
{
    internal class ShapeFactory
    {
        private static Random _rnd = new Random();

        public static IEnumerable<Shape> getShapes()
        {
            while (true)
            {
                /*int index = _rnd.Next(1, 6);

                Shape shape;

                switch(index)
                {
                    case 1:
                        shape = new Line();
                        break;
                    case 2:
                        shape = new Square();
                        break;
                    case 3:
                        shape = new TShape();
                        break;
                    case 4:
                        shape = new ZShape();
                        break;
                    case 5:
                        shape = new LShape();
                        break;

                    default: throw new ArgumentOutOfRangeException("Not Enough Shapes");
                }

                yield return shape;*/

                Type[] shapes = Assembly.GetExecutingAssembly().GetTypes().Where((t) => 
                    t.IsClass &&
                    t.Namespace == "Tetris.Shapes" &&
                    t.IsAssignableTo(typeof(Shape)) &&
                    !t.IsAbstract
                ).ToArray();

                int rndIndex = _rnd.Next(0, shapes.Length);
                object? nextShape = Activator.CreateInstance(shapes[rndIndex]);
                Shape shape;
                if (nextShape != null)
                    shape = (Shape)nextShape;
                else throw new Exception("type not found");

                yield return shape;
            }
        }
    }
}
