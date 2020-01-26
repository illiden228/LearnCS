using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameInRect
{
    class Program
    {
        static void Main(string[] args)
        {
            string symbol;
            string name;
            bool trueSymbol = false;

            while (!trueSymbol)
            {
                Console.Write("Введите ваш символ: ");
                symbol = Console.ReadLine();
                if (symbol == "100")
                {
                    Console.Clear();
                    Console.WriteLine("Символ введен неверно! Вам нужно ввести только 1 символ. \nПобеда! Секрет 2. 1000 - обмен жизнями");
                }
                else if (symbol.Length > 1)
                {
                    Console.WriteLine("Вам нужно ввести только 1 символ");
                }
                else
                {
                    trueSymbol = true;
                }
            }

            Console.Write("Введите ваше имя: ");
            name = Console.ReadLine();
            if (name == "100")
            {
                Console.Clear();
                Console.WriteLine("********");
                Console.WriteLine("*Победа*");
                Console.WriteLine("********");

            }
            else
            {
                for (int i = 0; i < name.Length + 2; i++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine("\n" + symbol + name + symbol);
                for (int i = 0; i < name.Length + 2; i++)
                {
                    Console.Write(symbol);
                }
                trueSymbol = true;
            }

            Console.ReadKey();
        }
    }
}
