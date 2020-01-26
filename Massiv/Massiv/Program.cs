using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massiv
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[10, 10];
            int x = 0, y = 0;
            int max = 0;
            Random rand = new Random();

            Console.WriteLine("Исходная матрица:");
            y = 1;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    Console.SetCursorPosition(x, y);
                    array[i, j] = rand.Next(1, 1000);
                    x += 4;
                    Console.Write(array[i, j]);
                }
                x = 0;
                y += 1;
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                    }
                }
            }

            x = 50;
            y = 0;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Полученная матрица:");
            y = 1;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    Console.SetCursorPosition(x, y);
                    if (array[i, j] == max)
                    {
                        array[i, j] = 0;
                    }
                    x += 4;
                    Console.Write(array[i, j]);
                }
                x = 50;
                y += 1;
            }

            x = 0;
            y = 12;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Наибольший элемент: " + max);

            Console.ReadKey();
        }
    }
}
