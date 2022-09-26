using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    static internal class ArrayExtensions
    {
        public static void CopyFrom(this byte[,] _array1, byte[,] array2)
        {
            for (int i = 0; i < _array1.GetLength(0); i++)
            {
                for (int j = 0; j < _array1.GetLength(1); j++)
                {
                    _array1[i, j] = array2[i, j];
                }
            }
        }
        public static byte[,] CopyField(this byte[,] _array)
        {
            byte[,] copy = new byte[_array.GetLength(0), _array.GetLength(1)];

            for (int i = 0; i < _array.GetLength(0); i++)
            {
                for (int j = 0; j < _array.GetLength(1); j++)
                {
                    copy[i, j] = _array[i, j];
                }
            }
            
            return copy;   
        }
        public static void ClearField(this byte[,] _array)
        {
            for (int i = 0; i < _array.GetLength(0); i++)
            {
                for (int j = 0; j < _array.GetLength(1); j++)
                {
                    _array[i, j] = 0;
                }
            }
        }
    }
}
