using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal abstract class Shape
    {
        public Location Location { get; private set; }
        public int Width => RotatedPattern.GetLength(1);
        public int Height => RotatedPattern.GetLength(0);
        public abstract string Type { get; }

        public abstract byte[,] BasePattern { get; }

        public byte[,] RotatedPattern { get; private set; }
        public void Rotate()
        {
            byte[,] newPattern = new byte[Width,Height];

            for (int y = 0; y < Width; y++)
            {
                for (int x = 0; x < Height; x++)
                {
                    newPattern[y, x] = RotatedPattern[(Height-1) - x, y];
                }
            }

            RotatedPattern = newPattern;
        }

        public Shape(Location location)
        {
            Location = location;
            RotatedPattern = BasePattern;
        }

        public Shape()
        {
            Location = new Location(0, 0);
            RotatedPattern = BasePattern;
        }

    }
}
