using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[0];
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("1. Создать случайный массив из n элементов\n" +
                                    "\n2. Shuffle - перемешать массив в случайном порядке\n" +
                                    "\n3. Выход\n");
                Console.Write("Введите номер команды: ");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.Write("\nВведите количество элементов массива (n): ");
                        array = new int[Convert.ToInt32(Console.ReadLine())];
                        RandomFill(ref array);
                        ShowMass(array);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Write("\nСколько раз вы хотите перемешать массив: ");
                        Shuffle(ref array, Convert.ToInt32(Console.ReadLine()));
                        ShowMass(array);
                        Console.ReadKey();
                        break;
                    case 3:
                        exit = true;
                        break;
                }
            }
        }

        static void RandomFill(ref int[] array)
        {
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(0, 100);
            }
        }

        static void ShowMass(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        static void Shuffle(ref int[] array, int tasks = 100)
        {
            Random rand = new Random();
            int randomNumberOne = 0;
            int randomNumberTwo = 0;
            int reserve = 0;
            for (int i = 0; i < tasks; i++)
            {
                randomNumberOne = rand.Next(0, array.Length);
                randomNumberTwo = rand.Next(0, array.Length);
                reserve = array[randomNumberOne];
                array[randomNumberOne] = array[randomNumberTwo];
                array[randomNumberTwo] = reserve;
            }
        }
    }
}
