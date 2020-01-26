using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMax
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];
            Random rand = new Random();

            Console.WriteLine("Числа: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("\n" + (i + 1) + ". ");
                array[i] = rand.Next(0, 100);
                Console.Write(array[i]);
            }

            Console.WriteLine("\n\nЛокальные максимумы: ");
            if (array[0] > array[1])
            {
                Console.WriteLine("1. " + array[0]);
            }
            for (int i = 1; i < array.Length - 1; i++)
            {
                    if (array[i] > array[i - 1] && array[i] > array[i + 1])
                    {
                        Console.WriteLine((i + 1) + ". " + array[i]);
                    }
            }
            if (array[array.Length - 1] > array[array.Length - 2])
            {
                Console.WriteLine(array.Length + ". " + array[array.Length - 1]);
            }
            Console.ReadKey();
        }
    }
}
