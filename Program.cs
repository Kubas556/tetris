

using System.ComponentModel.DataAnnotations.Schema;

namespace Tetris // Note: actual namespace depends on the project name.
{
    
    internal class Program
    {

        private const int Width = RenderUtils.Width;
        private const int Height = RenderUtils.Height;




        private static readonly byte[,] _field = new byte[Height, Width];

        static void Main(string[] args)
        {
            Console.ReadKey();
            RenderUtils.DrawAreaBorder();
            _field.ClearField();
            Console.CursorVisible = false;

            Console.SetCursorPosition(0, Height + 2);

            byte[,] lastUncolidedCopy = new byte[Height, Width];
            int collisionCount = 0;
            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.Now;
            float deltaTime = 0;

            foreach (Shape shape in ShapeFactory.getShapes())
            {
                RemoveFullRows(_field);
                shape.Location.X = Width / 2;
                shape.Location.Y = 0;

                if (collisionCount > 1)
                    break;

                do
                {
                    byte[,] copy = _field.CopyField();


                    for (int y = 0; y < shape.Height; y++)
                    {
                        for (int x = 0; x < shape.Width; x++)
                        {
                            copy[shape.Location.Y + y, shape.Location.X + x] += shape.RotatedPattern[y, x];

                        }
                    }

                    //DrawArea(previewCopy, 25);

                    if (OnGround(shape))
                    {
                        _field.CopyFrom(copy);
                        collisionCount = 0;
                        break;
                    }

                    if (Collided(copy))
                    {
                        _field.CopyFrom(lastUncolidedCopy);
                        RenderUtils.DrawArea(_field);
                        collisionCount++;
                        break;
                    }
                    else
                        RenderUtils.DrawArea(copy);
                    
                    collisionCount = 0;

                    lastUncolidedCopy.CopyFrom(copy);
                    time2 = DateTime.Now;
                    deltaTime += (time2.Ticks - time1.Ticks) / 10000f;
                    time1 = time2;

                    if (deltaTime > 100)
                    {
                        deltaTime = 0;
                        shape.Location.Y++;
                    }


                    if (Console.KeyAvailable)
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.LeftArrow:
                                if(shape.Location.X >= 1)
                                    shape.Location.X--;
                                break;
                            case ConsoleKey.RightArrow:
                                if(shape.Location.X + shape.Width < Width)
                                    shape.Location.X++;
                                break;
                            case ConsoleKey.UpArrow:
                                shape.Rotate();
                                if (shape.Location.X + shape.Width > Width)
                                    shape.Location.X -= ((shape.Location.X + shape.Width) - Width);
                                break;
                        }

                    //System.Threading.Thread.Sleep(100);

                } while (true);
            }
        }

        static bool OnGround(Shape shape)
        {
            return shape.Location.Y + shape.Height >= Height;
        }

        static bool RemoveFullRows(byte[,] area)
        {
            List<byte[]> withoutFullRown = new List<byte[]>();
            for (int y = 0; y < area.GetLength(0); y++)
            {
                bool withSpace = false;
                byte[] newRow = new byte[area.GetLength(1)];
                for (int x = 0; x < area.GetLength(1); x++)
                {
                    newRow[x] = area[y,x];
                    if(area[y,x] == 0)
                    {
                        withSpace = true;
                    }
                }

                if(withSpace)
                    withoutFullRown.Add(newRow);
            }

            if(withoutFullRown.Count < area.GetLength(0))
            {
                withoutFullRown.Reverse();
                while (area.GetLength(0) > withoutFullRown.Count)
                {
                    byte[] empty = new byte[area.GetLength(1)];
                    for (int x = 0; x < area.GetLength(1); x++)
                    {
                        empty[x] = 0;
                    }
                    withoutFullRown.Add(empty);
                }
                withoutFullRown.Reverse();

                area.CopyFrom(withoutFullRown.ToArray());
            }

            return true;
        }

        static bool Collided(byte[,] area)
        {
            for (int i = 0; i < area.GetLength(0); i++)
            {
                for (int j = 0; j < area.GetLength(1); j++)
                {
                    if (area[i, j] >= 2)
                        return true;
                }
            }

            return false;
        }
        
    }
}