using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            int tryCount = 3;
            string password = "Ya-unior1820";
            string inputUserPassword;

            for (int i = 0; i < tryCount; i++) 
            {
                Console.WriteLine("Введите пароль: ");
                inputUserPassword = Console.ReadLine();
                if (inputUserPassword == password)
                {
                    Console.WriteLine("Секрет. Можно читерить. Там где 100 - всегда победа");
                    break;
                }
                else {
                    Console.WriteLine("Пароль не верный. Попробуйте еще раз. Осталось " + (tryCount - i - 1) + " попыток");
                }
            }
            Console.ReadKey();
        }
    }
}
