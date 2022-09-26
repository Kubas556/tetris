using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Location
    {
        public int X, Y = 0;

        public Location(int x, int y)
        {
            X = x;
            Y = y; 
        }
    }
}
