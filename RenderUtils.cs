using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class RenderUtils
    {
        public static void DrawAreaBorder()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("╔");
            for (int i = 0; i < Program.width * Program.brickCharWidth; i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");
            for (int i = 0; i < Program.height; i++)
            {
                Console.SetCursorPosition(0, i + 1);
                Console.Write("║");
                Console.SetCursorPosition((Program.width * Program.brickCharWidth) + 1, i + 1);
                Console.Write("║");
            }
            Console.SetCursorPosition(0, Program.height + 1);
            Console.Write("╚");
            for (int i = 0; i < Program.width * Program.brickCharWidth; i++)
            {
                Console.Write("═");
            }
            Console.Write("╝");

        }
        public static void DrawArea(byte[,] area, int offset = 1)
        {
            for (int i = 0; i < area.GetLength(0); i++)
            {
                for (int j = 0; j < area.GetLength(1); j++)
                {
                    Console.SetCursorPosition(offset + (j * Program.brickCharWidth), 1 + i);
                    Console.Write(area[i, j] == 1 ? "██" : "  ");
                }
            }
        }
    }
}
