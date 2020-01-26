using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeMassiveFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            int[] tables = { 5, 6, 8, 1, 4, 6, 3 };
            
            while (isOpen)
            {
                Console.SetCursorPosition(0, 17);
                for (int i = 0; i < tables.Length; i++)
                {
                    Console.WriteLine("За столом " + (i + 1) + " свободно " + tables[i] + " мест");
                }

                Console.SetCursorPosition(20, 0);
                Console.WriteLine("Администрирование кафе");
                Console.WriteLine("\n\n1. Забронировать место\n\n2. Выход\n");
                Console.Write("Введите номер команды: ");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        int userTable, userPlace;
                        Console.Write("За каким столом вы хотите забронировать: ");
                        userTable = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (tables.Length <= userTable || userTable < 0)
                        {
                            Console.WriteLine("Такого стола нет");
                        }
                        Console.Write("Сколько мест вы хотите забронировать: ");
                        userPlace = Convert.ToInt32(Console.ReadLine());
                        if (tables[userTable] < userPlace || userPlace < 0)
                        {
                            Console.WriteLine("За этим столом нет столько мест");
                            break;
                        }

                        tables[userTable] -= userPlace;

                        break;
                    case 2:
                        isOpen = false;
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
