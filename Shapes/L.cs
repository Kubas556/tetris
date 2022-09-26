using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Shapes
{
    internal class LShape : Shape
    {
        public override string Type => "LShape";


        public override byte[,] BasePattern => new byte[,] {
            { 1, 0 },
            { 1, 0 },
            { 1, 1 }
        };
    }
}
