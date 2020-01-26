using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMassiv
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[0];
            string inputNumbers = "";
            bool exit = false;
            string number = "";

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Доступные команды: \n\n" +
                            "1. Mass - создать новый массив чисел \n\n" +
                            "2. AddMass - добавить числа к массиву \n\n" +
                            "3. SortMn - отсортировать от меньшего к большему \n\n" +
                            "4. SortMx - отсортировать от большего к меньшему \n\n" +
                            "5. Sum - вывести сумму элементов массива \n\n" +
                            "6. Show - вывести элементы массива \n\n" +
                            "7. Exit - выход\n");

                switch (Console.ReadLine())
                {
                    case "1":
                    case "Mass":
                        int[] newArray = new int[0];
                        array = new int[0];
                        Console.WriteLine("\nВведите числа массива через пробел: \n");
                        inputNumbers = Console.ReadLine() + " ";

                        for (int i = 0; i < inputNumbers.Length; i++)
                        {
                            if (Convert.ToString(inputNumbers[i]) == " " && i == 0)
                            {
                                continue;
                            }
                            if (Convert.ToString(inputNumbers[i]) != " ")
                            {
                                number += inputNumbers[i];
                                continue;
                            }
                            if (Convert.ToString(inputNumbers[i]) == " " && Convert.ToString(inputNumbers[i - 1]) == " ")
                            {
                                continue;
                            }
                            newArray = new int[array.Length + 1];
                            for (int length = 0; length < array.Length; length++)
                            {
                                newArray[length] = array[length];
                            }
                            newArray[newArray.Length - 1] = Convert.ToInt32(number);
                            array = newArray;
                            number = "";
                        }
                        break;
                    case "2":
                    case "AddMass":
                        Console.WriteLine("\nВведите через пробел числа, которые вы хотите добавить в массив: \n");
                        inputNumbers = Console.ReadLine() + " ";

                        for (int i = 0; i < inputNumbers.Length; i++)
                        {
                            if (Convert.ToString(inputNumbers[i]) == " " && i == 0)
                            {
                                continue;
                            }
                            if (Convert.ToString(inputNumbers[i]) != " ")
                            {
                                number += inputNumbers[i];
                                continue;
                            }
                            if (Convert.ToString(inputNumbers[i]) == " " && Convert.ToString(inputNumbers[i - 1]) == " ")
                            {
                                continue;
                            }
                            newArray = new int[array.Length + 1];
                            for (int length = 0; length < array.Length; length++)
                            {
                                newArray[length] = array[length];
                            }
                            newArray[newArray.Length - 1] = Convert.ToInt32(number);
                            array = newArray;
                            number = "";
                        }
                        break;
                    case "3":
                    case "SortMn":
                        bool sortMn = true;
                        int reservMn = 0;
                        while (sortMn)
                        {
                            sortMn = false;
                            for (int i = 0; i < array.Length - 1; i++)
                            {
                                if (array[i] > array[i + 1])
                                {
                                    reservMn = array[i + 1];
                                    array[i + 1] = array[i];
                                    array[i] = reservMn;
                                    sortMn = true;
                                }
                            }
                        }
                        Console.WriteLine("\nМассив отсортирован от меньшего к большему\n");
                        Console.ReadKey();
                        break;
                    case "4":
                    case "SortMx":
                        bool sortMx = true;
                        int reservMx = 0;
                        while (sortMx)
                        {
                            sortMx = false;
                            for (int i = 0; i < array.Length - 1; i++)
                            {
                                if (array[i] < array[i + 1])
                                {
                                    reservMx = array[i + 1];
                                    array[i + 1] = array[i];
                                    array[i] = reservMx;
                                    sortMx = true;
                                }
                            }
                        }
                        Console.WriteLine("\nМассив отсортирован от большего к меньшему\n");
                        Console.ReadKey();
                        break;
                    case "5":
                    case "Sum":
                        int sum = 0;
                        for (int i = 0; i < array.Length; i++)
                        {
                            sum += array[i];
                        }
                        Console.WriteLine("\nСумма: " + sum);
                        Console.ReadKey();
                        break;
                    case "6":
                    case "Show":
                        Console.WriteLine("\nВаши числа:\n");
                        for (int i = 0; i < array.Length; i++)
                        {
                            Console.Write(array[i] + " ");
                        }
                        Console.ReadKey();
                        break;
                    case "7":
                    case "Exit":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Я не знаю такой команды!");
                        break;

                }
            }
            
        }
    }
}
