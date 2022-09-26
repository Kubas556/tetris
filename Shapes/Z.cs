using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Shapes
{
    internal class ZShape : Shape
    {
        public override string Type => "ZShape";


        public override byte[,] BasePattern => new byte[,] { 
            { 0, 1, 1 },
            { 1, 1, 0 }
        };
    }
}
