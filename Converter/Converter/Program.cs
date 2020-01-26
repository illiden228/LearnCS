using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            float ruBalance, usdBalance, euBalance;
            float ru = 1, usd = 63, eu = 70;
            int command;
            float convertingCount;
            bool exit = false;

            Console.WriteLine("Добро пожаловать в конвертер валют!");
            Console.WriteLine("Введите ваш баланс в трех валютах.");

            Console.Write("Сколько у вас рублей: ");
            ruBalance = Convert.ToSingle(Console.ReadLine());

            Console.Write("Сколько у вас долларов: ");
            usdBalance = Convert.ToSingle(Console.ReadLine());

            Console.Write("Сколько у вас евро: ");
            euBalance = Convert.ToSingle(Console.ReadLine());

            

            while (!exit)
            {
                Console.WriteLine("\nЧто вы хотите сделать?");
                Console.WriteLine("1 - Перевести рубли в доллары");
                Console.WriteLine("2 - Перевести рубли в евро");
                Console.WriteLine("3 - Перевести доллары в рубли");
                Console.WriteLine("4 - Перевести доллары в евро");
                Console.WriteLine("5 - Перевести евро в рубли");
                Console.WriteLine("6 - Перевести евро в доллары");
                Console.WriteLine("7 - Посмотреть баланс");
                Console.WriteLine("8 - Выход");
                command = Convert.ToInt32(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        Console.WriteLine("\nПеревод рублей в доллары");
                        Console.Write("Сколько рублей вы хотите перевести? ");
                        convertingCount = Convert.ToSingle(Console.ReadLine());
                        if (convertingCount <= ruBalance)
                        {
                            ruBalance -= convertingCount;
                            usdBalance += convertingCount * ru / usd;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег для обмена");
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nПеревод рублей в евро");
                        Console.Write("Сколько рублей вы хотите перевести? ");
                        convertingCount = Convert.ToSingle(Console.ReadLine());
                        if (convertingCount <= ruBalance)
                        {
                            ruBalance -= convertingCount;
                            euBalance += convertingCount * ru / eu;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег для обмена");
                        }
                        break;
                    case 3:
                        Console.WriteLine("\nПеревод долларов в рубли");
                        Console.Write("Сколько долларов вы хотите перевести? ");
                        convertingCount = Convert.ToSingle(Console.ReadLine());
                        if (convertingCount <= usdBalance)
                        {
                            usdBalance -= convertingCount;
                            ruBalance += convertingCount * usd / ru;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег для обмена");
                        }
                        break;
                    case 4:
                        Console.WriteLine("\nПеревод долларов в евро");
                        Console.Write("Сколько долларов вы хотите перевести? ");
                        convertingCount = Convert.ToSingle(Console.ReadLine());
                        if (convertingCount <= usdBalance)
                        {
                            usdBalance -= convertingCount;
                            euBalance += convertingCount * usd / eu;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег для обмена");
                        }
                        break;
                    case 5:
                        Console.WriteLine("\nПеревод евро в рубли");
                        Console.Write("Сколько евро вы хотите перевести? ");
                        convertingCount = Convert.ToSingle(Console.ReadLine());
                        if (convertingCount <= euBalance)
                        {
                            euBalance -= convertingCount;
                            ruBalance += convertingCount * eu / ru;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег для обмена");
                        }
                        break;
                    case 6:
                        Console.WriteLine("\nПеревод евро в доллары");
                        Console.Write("Сколько евро вы хотите перевести? ");
                        convertingCount = Convert.ToSingle(Console.ReadLine());
                        if (convertingCount <= euBalance)
                        {
                            euBalance -= convertingCount;
                            usdBalance += convertingCount * eu / usd;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег для обмена");
                        }
                        break;
                    case 7:
                        Console.WriteLine("\nУ вас на счету " + ruBalance + " рублей, " + usdBalance + " долларов и " + euBalance + " евро.");
                        break;
                    case 8:
                        exit = true;
                        break;
                }
            }

            Console.WriteLine("\nУ вас на счету выходит:\n" + ruBalance + " рублей\n" + usdBalance + " долларов\n" + euBalance + " евро");
            Console.WriteLine("\nСпасибо, что воспользовались нашим конвертером валют!");
            Console.ReadKey();
        }
    }
}
