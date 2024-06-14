using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            //объявление двумерного массива
            int[,] W = new int[6, 6];
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                    W[i, j] = 0;
            //заполнение заштрихованной области единицами
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                    if (i + j <= 5)
                        W[i, j] = 1;
            // вывод двумерного массива в виде матрицы
            //красным цветом элементы заштрихованной области
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.ForegroundColor = (W[i, j] == 1) ? ConsoleColor.Magenta : ConsoleColor.DarkGray;
                    Console.Write($"{W[i, j]} \t");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();

            //   Задание элементов двумерного массива случайным образом
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                    W[i, j] = rnd.Next(-6, 20);

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write($"{W[i, j]} \t");
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            //1) Найти минимальный положительный элемент в заштрихованной области матрицы.  
            int min = int.MaxValue;
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                    if (i + j <= 5)
                    {
                        if (W[i, j] > 0 && W[i, j] < min)
                        {
                            min = W[i, j];
                        }
                    }
            Console.WriteLine($"min={min}");
            //2) Сформировать одномерный массив R из элементов заштрихованной области матрицы,
            //больших W16
            int N = 0;
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                    if (i + j <= 5)
                    {
                        if (W[i, j] > 16)
                        {
                            N = N + 1;
                        }
                    }

            int[] R = new int[N];
            int k = 0;
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                    if (i + j <= 5)
                    {
                        if (W[i, j] > 16)
                        {
                            R[k] = W[i, j];
                            k = k + 1;
                        }
                    }

            Console.Write("R: ");
            Console.WriteLine(String.Join(", ", R));

            //// 3) Сформировать одномерный массив S из количеств 
            int[] S = new int[6];
            int P = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (i + j <= 5)
                    {
                        if (W[i, j] > 0)
                            P += 1;
                    }
                }
                S[i] = P;
                P = 0;

            }

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"Строка{i + 1} S={S[i]}");
            }
            Console.WriteLine();
        }
    }
}
