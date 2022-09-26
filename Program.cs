

namespace Tetris // Note: actual namespace depends on the project name.
{
    
    internal class Program
    {
        public const int width = 10;
        public const int height = 30;

        public const int borderWidth = 1;
        public const int brickCharWidth = 2;

        private static byte[,] _field = new byte[height, width];

        static void Main(string[] args)
        {
            Console.ReadKey();
            RenderUtils.DrawAreaBorder();
            _field.ClearField();
            Console.CursorVisible = false;

            Console.SetCursorPosition(0, height + 2);

            byte[,] lastUncolidedCopy = new byte[height, width];
            int CollisionCount = 0;

            foreach (Shape shape in ShapeFactory.getShapes())
            {
                shape.Location.X = width / 2;
                shape.Location.Y = 0;

                if (CollisionCount > 1)
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

                    if (!OnGround(shape))
                    {
                        if(Collided(copy))
                        {
                            _field.CopyFrom(lastUncolidedCopy);
                            RenderUtils.DrawArea(_field);
                            CollisionCount++;
                            break;
                        }
                        else
                            RenderUtils.DrawArea(copy);
                        CollisionCount = 0;

                        lastUncolidedCopy.CopyFrom(copy);
                        System.Threading.Thread.Sleep(10);
                    }
                    else
                    {
                        _field.CopyFrom(copy);
                        CollisionCount = 0;
                        break;
                    }
                    shape.Location.Y++;

                    
                    if (Console.KeyAvailable)
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.LeftArrow:
                                if(shape.Location.X >= 1)
                                shape.Location.X--;
                                break;
                            case ConsoleKey.RightArrow:
                                if(shape.Location.X + shape.Width < width)
                                shape.Location.X++;
                                break;
                            case ConsoleKey.UpArrow:
                                shape.Rotate();
                                if (shape.Location.X + shape.Width > width)
                                    shape.Location.X -= ((shape.Location.X + shape.Width) - width);
                                break;
                        }

                    System.Threading.Thread.Sleep(100);

                } while (true);

                if (Console.KeyAvailable)
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                        break;
                    else
                        continue;
            }
        }

        static bool OnGround(Shape shape)
        {
            return shape.Location.Y + shape.Height >= height;
        }

        static bool Collided(byte[,] area)
        {
            for (int i = 0; i < area.GetLength(0); i++)
            {
                for (int j = 0; j < area.GetLength(1); j++)
                {
                    if (area[i, j] == 2)
                        return true;
                }
            }

            return false;
        }
        
    }
}