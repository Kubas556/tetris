using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class RenderUtils
    {
        public const int Width = 10;
        public const int Height = 30;

        public const int BorderWidth = 1;
        public const int BrickCharWidth = 2;
        public static void DrawAreaBorder()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("╔");
            for (int i = 0; i < Width * BrickCharWidth; i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");
            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(0, i + 1);
                Console.Write("║");
                Console.SetCursorPosition((Width * BrickCharWidth) + 1, i + 1);
                Console.Write("║");
            }
            Console.SetCursorPosition(0, Height + 1);
            Console.Write("╚");
            for (int i = 0; i < Width * BrickCharWidth; i++)
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
                    Console.SetCursorPosition(offset + (j * BrickCharWidth), 1 + i);
                    Console.Write(area[i, j] == 1 ? "██" : "  ");
                }
            }
        }
    }
}
