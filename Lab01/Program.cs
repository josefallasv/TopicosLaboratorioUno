using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    public class Program
    {
        private static string input;
        private static int size;
        private static bool player = true;
        private static string[,] matrix;
        private static bool gameover = false;
        private static int turns;

        static void Main(string[] args)
        {
            Console.Out.WriteLine("Lab 01");
            Console.Out.WriteLine("Digite cualquier tecla para iniciar.");
            Console.WriteLine();
            Console.ReadKey();
            Console.Out.WriteLine("Digite la dimension del juego (3-10):");
            input = Console.In.ReadLine();
            bool flag = false;
            while (!flag)
            {
                if (Int32.TryParse(input, out size))
                {
                    if ((size < 3) || (size >= 11))
                    {
                        Console.WriteLine("Dimension no valida, intelo de nuevo.");
                        input = Console.In.ReadLine();
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else
                {
                    Console.WriteLine("Dimension no valida, intelo de nuevo.");
                    input = Console.In.ReadLine();
                }
            }
            matrix = new string[size, size];
            turns = 0;
            FillMatrix();
            DisplayMatrix();

            while (!gameover)
            {
                string input = "";
                Console.WriteLine();
                Player();
                Console.WriteLine();
                Console.Out.WriteLine("Digite la posicion.");
                input = Console.In.ReadLine();
                flag = false;
                while (!flag)
                {
                    if (ReplacePosition(input))
                    {
                        if (Winner())
                        {
                            flag = true;
                            gameover = true;
                        }
                        else
                        {
                            if (player)
                            {
                                player = false;
                            }
                            else
                            {
                                player = true;
                            }
                            flag = true;
                            turns++;
                            if (turns == size * size)
                            {
                                gameover = true;
                                Console.WriteLine();
                                Console.Out.WriteLine("Resultado: Empate.");
                                DisplayMatrix();
                                Console.ReadKey();
                            }
                        }
                    }
                    else
                    {
                        Console.Out.WriteLine("Posicion no valida, intelo de nuevo.");
                        input = Console.In.ReadLine();
                    }
                }
                DisplayMatrix(); 
            }
            
        }

        public static bool Winner()
        {
            if (Validations.Vertical(matrix, size, player) || Validations.Horizontal(matrix, size, player) || Validations.Diagonal1(matrix, size, player) || Validations.Diagonal2(matrix, size, player))
            {
                gameover = true;
                Console.WriteLine();
                if (player)
                {
                    Console.Out.WriteLine("Resultado: el jugador X gano.");
                }
                else
                {
                    Console.Out.WriteLine("Resultado: el jugador O gano.");
                }
                DisplayMatrix();
                Console.ReadKey();
                return true;
            }
            return false;
        }

        public static void Player()
        {
            if (player)
            {
                Console.Out.WriteLine("Turno del jugador: X.");
            }
            else
            {
                Console.Out.WriteLine("Turno del jugador: O");
            }
        }

        public static void FillMatrix()
        {
            int count = 0;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    matrix[y, x] = count.ToString();
                    count++;
                }
            }
        }

        public static void DisplayMatrix()
        {
            Console.WriteLine();
            for (int j = 0; j < size; j++)
            {
                for (int i = 0; i < size; i++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static bool ReplacePosition(string position)
        {
            for (int j = 0; j < size; j++)
            {
                for (int i = 0; i < size; i++)
                {
                    if (matrix[j, i] == position)
                    {
                        if ((position != "X") && (position != "O"))
                        {
                            if (player)
                            {
                                matrix[j, i] = "X";
                            }
                            else
                            {
                                matrix[j, i] = "O";
                            }
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
        //public static bool Vertical( string[] array, int size)
        //{
        //    //string[] array = new string[size];
        //    for (int x = 0; x < size; x++)
        //    {
        //        for (int y = 0; y < size; y++)
        //        {
        //            array[y] = matrix[y, x];
        //        }
        //        if (player)
        //        {
        //            if (array.All(s => string.Equals("X", s, StringComparison.CurrentCulture)))
        //            {
        //                return true;
        //            }
        //        }
        //        else
        //        {
        //            if (array.All(s => string.Equals("O", s, StringComparison.CurrentCulture)))
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

        //public static bool Horizontal(string[] array, string[,] matrix, int size)
        //{
        //    //string[] array = new string[size];
        //    for (int x = 0; x < size; x++)
        //    {
        //        for (int y = 0; y < size; y++)
        //        {
        //            array[y] = matrix[x, y];
        //        }
        //        if (player)
        //        {
        //            if (array.All(s => string.Equals("X", s, StringComparison.CurrentCulture)))
        //            {
        //                return true;
        //            }
        //        }
        //        else
        //        {
        //            if (array.All(s => string.Equals("O", s, StringComparison.CurrentCulture)))
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

        //public static bool Diagonal1(string[] array, string[,] matrix, int size)
        //{
        //    //string[] array = new string[size];
        //    int x = 0;
        //    for (int y = 0; y < size; y++)
        //    {
        //        array[y] = matrix[x, y];
        //        x++; 
        //    }
        //    if (player)
        //    {
        //        if (array.All(s => string.Equals("X", s, StringComparison.CurrentCulture)))
        //        {
        //            return true;
        //        }
        //    }
        //    else
        //    {
        //        if (array.All(s => string.Equals("O", s, StringComparison.CurrentCulture)))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public static bool Diagonal2(string[] array, string[,] matrix, int size)
        //{
        //    //string[] array = new string[size];
        //    int y = size - 1;
        //    for (int x = 0; x < size; x++)
        //    {
        //        array[x] = matrix[x, y];
        //        y--;
        //    }
        //    if (player)
        //    {
        //        if (array.All(s => string.Equals("X", s, StringComparison.CurrentCulture)))
        //        {
        //            return true;
        //        }
        //    }
        //    else
        //    {
        //        if (array.All(s => string.Equals("O", s, StringComparison.CurrentCulture)))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
