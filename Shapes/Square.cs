using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Shapes
{
    internal class Square : Shape
    {
        public override string Type => "Square";


        public override byte[,] BasePattern => new byte[,] { 
            { 1, 1 },
            { 1, 1 }
        };
    }
}
