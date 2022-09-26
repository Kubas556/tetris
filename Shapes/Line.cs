using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Shapes
{
    internal class Line : Shape
    {
        public override string Type => "Line";


        public override byte[,] BasePattern => new byte[,] { 
            { 1 },
            { 1 },
            { 1 },
            { 1 }
        };
    }
}
