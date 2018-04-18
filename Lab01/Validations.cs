using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    public class Validations
    {

        public static bool Vertical(string[,] matrix, int size, bool player)
        {
            string[] array = new string[size];
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    array[y] = matrix[y, x];
                }
                if (player)
                {
                    if (array.All(s => string.Equals("X", s, StringComparison.CurrentCulture)))
                    {
                        return true;
                    }
                }
                else
                {
                    if (array.All(s => string.Equals("O", s, StringComparison.CurrentCulture)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool Horizontal(string[,] matrix, int size, bool player)
        {
            string[] array = new string[size];
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    array[y] = matrix[x, y];
                }
                if (player)
                {
                    if (array.All(s => string.Equals("X", s, StringComparison.CurrentCulture)))
                    {
                        return true;
                    }
                }
                else
                {
                    if (array.All(s => string.Equals("O", s, StringComparison.CurrentCulture)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool Diagonal1(string[,] matrix, int size, bool player)
        {
            string[] array = new string[size];
            int x = 0;
            for (int y = 0; y < size; y++)
            {
                array[y] = matrix[x, y];
                x++;
            }
            if (player)
            {
                if (array.All(s => string.Equals("X", s, StringComparison.CurrentCulture)))
                {
                    return true;
                }
            }
            else
            {
                if (array.All(s => string.Equals("O", s, StringComparison.CurrentCulture)))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool Diagonal2(string[,] matrix, int size, bool player)
        {
            string[] array = new string[size];
            int y = size - 1;
            for (int x = 0; x < size; x++)
            {
                array[x] = matrix[x, y];
                y--;
            }
            if (player)
            {
                if (array.All(s => string.Equals("X", s, StringComparison.CurrentCulture)))
                {
                    return true;
                }
            }
            else
            {
                if (array.All(s => string.Equals("O", s, StringComparison.CurrentCulture)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
