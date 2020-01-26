using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            string password = "";
            string tryPassword;
            string inputComand = "";
            bool exit = false;
            int backColor = 16;
            int textColor = 13;
            Console.WindowWidth = 100;
            Console.WindowHeight = 25;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Random rand = new Random();

            Console.WriteLine("Добро пожаловать в ConsoleMenu\n");

            while (!exit)
            {
                switch (backColor)
                {
                    case 1:
                        Console.BackgroundColor = ConsoleColor.Red;
                        break;
                    case 2:
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        break;
                    case 3:
                        Console.BackgroundColor = ConsoleColor.Blue;
                        break;
                    case 4:
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        break;
                    case 5:
                        Console.BackgroundColor = ConsoleColor.Green;
                        break;
                    case 6:
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        break;
                    case 7:
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        break;
                    case 8:
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        break;
                    case 9:
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        break;
                    case 10:
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 11:
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        break;
                    case 12:
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        break;
                    case 13:
                        Console.BackgroundColor = ConsoleColor.Gray;
                        break;
                    case 14:
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        break;
                    case 15:
                        Console.BackgroundColor = ConsoleColor.White;
                        break;
                    case 16:
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                }

                switch (textColor)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case 9:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 10:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 11:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case 12:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        break;
                    case 13:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 14:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case 15:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 16:
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                }

                Console.WriteLine("Доступные команды (вводить строго с сохранением регистра):");
                Console.WriteLine("1. SetName - установить имя"); //+
                Console.WriteLine("2. SetPassword - установить пароль"); //+
                Console.WriteLine("3. WriteName - вывести имя после ввода пароля"); //+
                Console.WriteLine("4. ChangeConsoleColor - изменить цвет фона консоли");
                Console.WriteLine("5. ChangeTextColor - изменить цвет текста");//+
                Console.WriteLine("6. Converter - запустить конвертер валют"); //+
                Console.WriteLine("7. Secret - узнать секретное слово"); //+
                Console.WriteLine("8. Game - зайти в раздел с играми"); //+-
                Console.WriteLine("9. Esc - выход"); //+
                inputComand = Console.ReadLine();

                switch (inputComand)
                {
                    case "1":
                    case "SetName":
                        if (password == "")
                        {
                            Console.Write("\nВведите ваше имя: ");
                            name = Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("\nЧтобы изменить имя сначала введите пароль: ");
                            tryPassword = Console.ReadLine();
                            if (tryPassword == password)
                            {
                                Console.Write("\nВведите ваше имя: ");
                                name = Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("\nНеверный пароль! Попробуйте еще раз");
                            }
                        }
                        break;
                    case "2":
                    case "SetPassword":
                        if (name == "")
                        {
                            Console.WriteLine("\nЧтобы пользоваться этой командой, сначала нужно установить имя");
                            Console.ReadKey();
                        }
                        else {
                            if (password == "")
                            {
                                Console.Write("\nВведите ваш новый пароль: ");
                                password = Console.ReadLine();
                            }
                            else
                            {
                                Console.Write("\nЧтобы изменить пароль, сначала введите старый пароль: ");
                                tryPassword = Console.ReadLine();
                                if (tryPassword == password)
                                {
                                    Console.Write("\nВаш новый пароль: ");
                                    name = Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("\nНеверный пароль! Попробуйте еще раз");
                                    Console.ReadKey();
                                }
                            }
                        }

                        break;
                    case "3":
                    case "WriteName":
                        if (name == "")
                        {
                            Console.WriteLine("\nУ вас еще нет имени");
                            Console.ReadKey();
                        }
                        else if (password == "")
                        {
                            Console.WriteLine("\nЧтобы пользоваться этой командой, сначала нужно задать пароль");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Write("\nЧтобы вывести имя введите пароль: ");
                            tryPassword = Console.ReadLine();
                            if (tryPassword == password)
                            {
                                if (name == "100")
                                {
                                    Console.Clear();
                                    Console.WriteLine("********");
                                    Console.WriteLine("*Победа*");
                                    Console.WriteLine("********");
                                    Console.WriteLine("Секрет 2. 1000 - обмен жизнями");
                                    break;
                                }
                                else {
                                    Console.WriteLine("\nВаше имя: ");
                                    for (int i = 0; i < name.Length + 2; i++)
                                    {
                                        Console.Write("*");
                                    }
                                    Console.WriteLine("\n*" + name + "*");
                                    for (int i = 0; i < name.Length + 2; i++)
                                    {
                                        Console.Write("*");
                                    }
                                    Console.ReadKey();
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Пароль не верный. Попробуйте еще раз");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case "4":
                    case "ChangeConsoleColor":
                        if (password == "")
                        {
                            Console.WriteLine("\nЧтобы пользоваться этой командой, сначала нужно задать пароль");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Write("\nЧтобы изменить цвет фона введите пароль: ");
                            tryPassword = Console.ReadLine();
                            if (tryPassword == password)
                            {
                                bool exitColorBack = false;

                                while (!exitColorBack)
                                {
                                    Console.Clear();
                                    Console.BackgroundColor = ConsoleColor.White;
                                    for (int i = 0; i < 103; i++)
                                    {
                                        Console.Write(" ");
                                    }

                                    for (int table = 0; table < 4; table++)
                                    {
                                        for (int colB = 0; colB < 3; colB++)
                                        {
                                            for (int col = 0; col < 4; col++)
                                            {
                                                Console.BackgroundColor = ConsoleColor.Black;
                                                for (int i = 0; i < 22; i++)
                                                {
                                                    Console.Write(" ");
                                                }
                                                Console.BackgroundColor = ConsoleColor.White;
                                                Console.Write(" ");
                                                Console.Write(" ");
                                            }
                                            Console.Write(" ");
                                            Console.Write(" ");
                                            Console.Write(" ");
                                            Console.Write(" ");
                                        }
                                        Console.BackgroundColor = ConsoleColor.White;
                                        for (int i = 0; i < 100; i++)
                                        {
                                            Console.Write(" ");
                                        }
                                    }

                                    Console.BackgroundColor = ConsoleColor.Black;
                                    int x = 13;
                                    int y = 2;
                                    Console.SetCursorPosition(x, y);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Red");

                                    Console.SetCursorPosition(x + 22, y);
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("DarkRed");

                                    Console.SetCursorPosition(x + 47, y);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Cyan");

                                    Console.SetCursorPosition(x + 69, y);
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine("DarkCyan");

                                    Console.SetCursorPosition(x, y + 4);
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("Blue");

                                    Console.SetCursorPosition(x + 22, y + 4);
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.WriteLine("DarkBlue");

                                    Console.SetCursorPosition(x + 46, y + 4);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("Magenta");

                                    Console.SetCursorPosition(x + 67, y + 4);
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    Console.WriteLine("DarkMagenta");

                                    Console.SetCursorPosition(x - 1, y + 8);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Green");

                                    Console.SetCursorPosition(x + 21, y + 8);
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("DarkGreen");

                                    Console.SetCursorPosition(x + 47, y + 8);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine("Gray");

                                    Console.SetCursorPosition(x + 69, y + 8);
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("DarkGray");

                                    Console.SetCursorPosition(x - 1, y + 12);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Yellow");

                                    Console.SetCursorPosition(x + 21, y + 12);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("DarkYellow");

                                    Console.SetCursorPosition(x + 47, y + 12);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("White");

                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.SetCursorPosition(x + 70, y + 12);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("Black");

                                    switch (backColor)
                                    {
                                        case 1:
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            break;
                                        case 2:
                                            Console.BackgroundColor = ConsoleColor.DarkRed;
                                            break;
                                        case 3:
                                            Console.BackgroundColor = ConsoleColor.Blue;
                                            break;
                                        case 4:
                                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                                            break;
                                        case 5:
                                            Console.BackgroundColor = ConsoleColor.Green;
                                            break;
                                        case 6:
                                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                                            break;
                                        case 7:
                                            Console.BackgroundColor = ConsoleColor.Cyan;
                                            break;
                                        case 8:
                                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                                            break;
                                        case 9:
                                            Console.BackgroundColor = ConsoleColor.Yellow;
                                            break;
                                        case 10:
                                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                                            break;
                                        case 11:
                                            Console.BackgroundColor = ConsoleColor.Magenta;
                                            break;
                                        case 12:
                                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                            break;
                                        case 13:
                                            Console.BackgroundColor = ConsoleColor.Gray;
                                            break;
                                        case 14:
                                            Console.BackgroundColor = ConsoleColor.DarkGray;
                                            break;
                                        case 15:
                                            Console.BackgroundColor = ConsoleColor.White;
                                            break;
                                        case 16:
                                            Console.BackgroundColor = ConsoleColor.Black;
                                            break;
                                    }

                                    switch (textColor)
                                    {
                                        case 1:
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            break;
                                        case 2:
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            break;
                                        case 3:
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            break;
                                        case 4:
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            break;
                                        case 5:
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            break;
                                        case 6:
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            break;
                                        case 7:
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            break;
                                        case 8:
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                            break;
                                        case 9:
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            break;
                                        case 10:
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            break;
                                        case 11:
                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                            break;
                                        case 12:
                                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                            break;
                                        case 13:
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            break;
                                        case 14:
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            break;
                                        case 15:
                                            Console.ForegroundColor = ConsoleColor.White;
                                            break;
                                        case 16:
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            break;
                                    }

                                    Console.SetCursorPosition(0, y + 15);

                                    Console.WriteLine("Выберите и введите цвет из таблицы");
                                    Console.WriteLine("Esc - вернуться в главное меню");
                                    inputComand = Console.ReadLine();

                                    switch (inputComand)
                                    {
                                        case "Red":
                                            backColor = 1;
                                            break;
                                        case "DarkRed":
                                            backColor = 2;
                                            break;
                                        case "Blue":
                                            backColor = 3;
                                            break;
                                        case "DarkBlue":
                                            backColor = 4;
                                            break;
                                        case "Green":
                                            backColor = 5;
                                            break;
                                        case "DarkGreen":
                                            backColor = 6;
                                            break;
                                        case "Cyan":
                                            backColor = 7;
                                            break;
                                        case "DarkCyan":
                                            backColor = 8;
                                            break;
                                        case "Yellow":
                                            backColor = 9;
                                            break;
                                        case "DarkYellow":
                                            backColor = 10;
                                            break;
                                        case "Magenta":
                                            backColor = 11;
                                            break;
                                        case "DarkMagenta":
                                            backColor = 12;
                                            break;
                                        case "Gray":
                                            backColor = 13;
                                            break;
                                        case "DarkGray":
                                            backColor = 14;
                                            break;
                                        case "White":
                                            backColor = 15;
                                            break;
                                        case "Black":
                                            backColor = 16;
                                            break;
                                        case "Esc":
                                            Console.Clear();
                                            exitColorBack = true;
                                            break;
                                        default:
                                            Console.WriteLine("\nЯ не знаю такой команды");
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Пароль не верный. Попробуйте еще раз");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case "5":
                    case "ChangeTextColor":
                        if (password == "")
                        {
                            Console.WriteLine("\nЧтобы пользоваться этой командой, сначала нужно задать пароль");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Write("\nЧтобы изменить цвет текста введите пароль: ");
                            tryPassword = Console.ReadLine();
                            if (tryPassword == password)
                            {
                                bool exitColorBack = false;

                                while (!exitColorBack)
                                {
                                    Console.Clear();
                                    Console.BackgroundColor = ConsoleColor.White;
                                    for (int i = 0; i < 103; i++)
                                    {
                                        Console.Write(" ");
                                    }

                                    for (int table = 0; table < 4; table++)
                                    {
                                        for (int colB = 0; colB < 3; colB++)
                                        {
                                            for (int col = 0; col < 4; col++)
                                            {
                                                Console.BackgroundColor = ConsoleColor.Black;
                                                for (int i = 0; i < 22; i++)
                                                {
                                                    Console.Write(" ");
                                                }
                                                Console.BackgroundColor = ConsoleColor.White;
                                                Console.Write(" ");
                                                Console.Write(" ");
                                            }
                                            Console.Write(" ");
                                            Console.Write(" ");
                                            Console.Write(" ");
                                            Console.Write(" ");
                                        }
                                        Console.BackgroundColor = ConsoleColor.White;
                                        for (int i = 0; i < 100; i++)
                                        {
                                            Console.Write(" ");
                                        }
                                    }

                                    Console.BackgroundColor = ConsoleColor.Black;
                                    int x = 13;
                                    int y = 2;
                                    Console.SetCursorPosition(x, y);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Red");

                                    Console.SetCursorPosition(x + 22, y);
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("DarkRed");

                                    Console.SetCursorPosition(x + 47, y);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Cyan");

                                    Console.SetCursorPosition(x + 69, y);
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine("DarkCyan");

                                    Console.SetCursorPosition(x, y + 4);
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("Blue");

                                    Console.SetCursorPosition(x + 22, y + 4);
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.WriteLine("DarkBlue");

                                    Console.SetCursorPosition(x + 46, y + 4);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("Magenta");

                                    Console.SetCursorPosition(x + 67, y + 4);
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    Console.WriteLine("DarkMagenta");

                                    Console.SetCursorPosition(x - 1, y + 8);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Green");

                                    Console.SetCursorPosition(x + 21, y + 8);
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("DarkGreen");

                                    Console.SetCursorPosition(x + 47, y + 8);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine("Gray");

                                    Console.SetCursorPosition(x + 69, y + 8);
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("DarkGray");

                                    Console.SetCursorPosition(x - 1, y + 12);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Yellow");

                                    Console.SetCursorPosition(x + 21, y + 12);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("DarkYellow");

                                    Console.SetCursorPosition(x + 47, y + 12);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("White");

                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.SetCursorPosition(x + 70, y + 12);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("Black");

                                    switch (backColor)
                                    {
                                        case 1:
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            break;
                                        case 2:
                                            Console.BackgroundColor = ConsoleColor.DarkRed;
                                            break;
                                        case 3:
                                            Console.BackgroundColor = ConsoleColor.Blue;
                                            break;
                                        case 4:
                                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                                            break;
                                        case 5:
                                            Console.BackgroundColor = ConsoleColor.Green;
                                            break;
                                        case 6:
                                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                                            break;
                                        case 7:
                                            Console.BackgroundColor = ConsoleColor.Cyan;
                                            break;
                                        case 8:
                                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                                            break;
                                        case 9:
                                            Console.BackgroundColor = ConsoleColor.Yellow;
                                            break;
                                        case 10:
                                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                                            break;
                                        case 11:
                                            Console.BackgroundColor = ConsoleColor.Magenta;
                                            break;
                                        case 12:
                                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                            break;
                                        case 13:
                                            Console.BackgroundColor = ConsoleColor.Gray;
                                            break;
                                        case 14:
                                            Console.BackgroundColor = ConsoleColor.DarkGray;
                                            break;
                                        case 15:
                                            Console.BackgroundColor = ConsoleColor.White;
                                            break;
                                        case 16:
                                            Console.BackgroundColor = ConsoleColor.Black;
                                            break;
                                    }

                                    switch (textColor)
                                    {
                                        case 1:
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            break;
                                        case 2:
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            break;
                                        case 3:
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            break;
                                        case 4:
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            break;
                                        case 5:
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            break;
                                        case 6:
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            break;
                                        case 7:
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            break;
                                        case 8:
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                            break;
                                        case 9:
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            break;
                                        case 10:
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            break;
                                        case 11:
                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                            break;
                                        case 12:
                                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                            break;
                                        case 13:
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            break;
                                        case 14:
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            break;
                                        case 15:
                                            Console.ForegroundColor = ConsoleColor.White;
                                            break;
                                        case 16:
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            break;
                                    }

                                    Console.SetCursorPosition(0, y + 15);

                                    Console.WriteLine("Выберите и введите цвет из таблицы");
                                    Console.WriteLine("Esc - вернуться в главное меню");
                                    inputComand = Console.ReadLine();

                                    switch (inputComand)
                                    {
                                        case "Red":
                                            textColor = 1;
                                            break;
                                        case "DarkRed":
                                            textColor = 2;
                                            break;
                                        case "Blue":
                                            textColor = 3;
                                            break;
                                        case "DarkBlue":
                                            textColor = 4;
                                            break;
                                        case "Green":
                                            textColor = 5;
                                            break;
                                        case "DarkGreen":
                                            textColor = 6;
                                            break;
                                        case "Cyan":
                                            textColor = 7;
                                            break;
                                        case "DarkCyan":
                                            textColor = 8;
                                            break;
                                        case "Yellow":
                                            textColor = 9;
                                            break;
                                        case "DarkYellow":
                                            textColor = 10;
                                            break;
                                        case "Magenta":
                                            textColor = 11;
                                            break;
                                        case "DarkMagenta":
                                            textColor = 12;
                                            break;
                                        case "Gray":
                                            textColor = 13;
                                            break;
                                        case "DarkGray":
                                            textColor = 14;
                                            break;
                                        case "White":
                                            textColor = 15;
                                            break;
                                        case "Black":
                                            textColor = 16;
                                            break;
                                        case "Esc":
                                            Console.Clear();
                                            exitColorBack = true;
                                            break;
                                        default:
                                            Console.WriteLine("\nЯ не знаю такой команды");
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Пароль не верный. Попробуйте еще раз");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case "6":
                    case "Converter":
                        if (password == "")
                        {
                            Console.WriteLine("\nЧтобы пользоваться этой командой, сначала нужно задать пароль");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Write("\nЧтобы войти введите пароль: ");
                            tryPassword = Console.ReadLine();
                            if (tryPassword == password)
                            {
                                Console.Clear();
                                float ruBalance, usdBalance, euBalance;
                                float ru = 1, usd = 63, eu = 70;
                                int command;
                                float convertingCount;
                                bool exitConverter = false;

                                Console.WriteLine("\nДобро пожаловать в конвертер валют!");
                                Console.WriteLine("Введите ваш баланс в трех валютах.");

                                Console.Write("Сколько у вас рублей: ");
                                ruBalance = Convert.ToSingle(Console.ReadLine());

                                Console.Write("Сколько у вас долларов: ");
                                usdBalance = Convert.ToSingle(Console.ReadLine());

                                Console.Write("Сколько у вас евро: ");
                                euBalance = Convert.ToSingle(Console.ReadLine());
                                                               
                                while (!exitConverter)
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
                                            exitConverter = true;
                                            break;
                                        default:
                                            Console.WriteLine("\nЯ не знаю такой команды");
                                            break;
                                    }
                                }

                                Console.WriteLine("\nУ вас на счету выходит:\n" + ruBalance + " рублей\n" + usdBalance + " долларов\n" + euBalance + " евро");
                                Console.WriteLine("\nСпасибо, что воспользовались нашим конвертером валют!");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nПароль не верный. Попробуйте еще раз");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case "7":
                    case "Secret":
                        if (password == "")
                        {
                            Console.WriteLine("\nЧтобы пользоваться этой командой, сначала нужно задать пароль");
                            Console.ReadKey();
                        }
                        else {
                            Console.Write("\nЧтобы узнать секрет введите пароль: ");
                            tryPassword = Console.ReadLine();
                            if (tryPassword == password)
                            {
                                Console.WriteLine("Секрет. Можно читерить. Там где 100 - всегда победа");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Пароль не верный. Попробуйте еще раз");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case "8":
                    case "Game":
                        if (password == "")
                        {
                            Console.WriteLine("\nЧтобы пользоваться этой командой, сначала нужно задать пароль");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Write("\nЧтобы поиграть введите пароль: ");
                            tryPassword = Console.ReadLine();
                            if (tryPassword == password)
                            {
                                bool exitGame = false;

                                while (!exitGame)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Добро пожаловать в раздел Game, {name}");
                                    Console.WriteLine("В какую игру вы хотите поиграть?");
                                    Console.WriteLine("1. Угадай число");
                                    Console.WriteLine("2. Бой с боссом");
                                    Console.WriteLine("3. Выход");
                                    inputComand = Console.ReadLine();

                                    switch (inputComand)
                                    {
                                        case "1":
                                            bool exitNumber = false;
                                            while (!exitNumber)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("0. Esc - выход\n");
                                                int tryCount = 3;
                                                int number = rand.Next(1, 100);
                                                Console.WriteLine($"Загадано число от {number - 5} до {number + 5}. Какое это число?");
                                                while (tryCount > 0)
                                                {
                                                    inputComand = Console.ReadLine();
                                                    if (inputComand == "0" || inputComand == "Esc")
                                                    {
                                                        exitNumber = true;
                                                        tryCount = 0;
                                                    }
                                                    else if (Convert.ToInt32(inputComand) == number)
                                                    {
                                                        Console.WriteLine($"Правильно! Ты выиграл, {name}, это число {number}");
                                                        tryCount = 0;
                                                    }
                                                    else if (Convert.ToInt32(inputComand) > number)
                                                    {
                                                        Console.WriteLine($"Меньше! Осталось {tryCount-- - 1} попыток");
                                                    }
                                                    else if (Convert.ToInt32(inputComand) < number)
                                                    {
                                                        Console.WriteLine($"Больше! Осталось {tryCount-- - 1} попыток");
                                                    }
                                                }
                                                Console.WriteLine($"Это было число {number}");
                                                Console.ReadKey();
                                            }
                                            break;
                                        case "2":
                                            float maxPlayerHealth = 1000f;
                                            float maxEnemyHealth = 2000f;
                                            float playerHealth = 1000f;
                                            float enemyHealth = 2000f;
                                            int enemyComand;
                                            int call = 0;
                                            int coconStroke = 0;
                                            int bloodStroke = 0;
                                            bool exitBoss = false;
                                            bool enemyMove = true;

                                            Console.Clear();
                                            Console.WriteLine($"Добро пожаловать в бой с боссом, {name}!\nПеред тобой самый ужасный монстр из существующих - Огонек. У Огонька, как и у тебя, целых четыре способности!");
                                            Console.WriteLine("\nТебе нужно победить его своей силой!");
                                            Console.ReadKey();

                                            while (playerHealth > 0 && enemyHealth > 0 && !exitBoss)
                                            {
                                                Console.Clear();
                                                Console.SetCursorPosition(5, 24);
                                                Console.Write($"HP Огонек: {enemyHealth}");
                                                Console.SetCursorPosition(60, 24);
                                                Console.Write($"HP {name}: {playerHealth}");
                                                Console.SetCursorPosition(0, 0);
                                                Console.WriteLine("\nКакую способность ты хочешь использовать?");
                                                Console.WriteLine("1. Кровавый призыв - ты открываешь портал, нанося себе урон в размере 25 HP, и в следующем ходу \nможешь призвать одного из существ");
                                                Console.WriteLine("2. Светлячки - существа, которые можно призвать только после кровавого призыва. Исцеляют тебе 150 HP и наносят противнику 100 урона");
                                                Console.WriteLine("3. Демон - существо, которое можно призвать только посе кровавого призыва. Наносит всем 200 урона");
                                                Console.WriteLine("4. Кокон - защитная оболочка, которая исцеляет 100 HP и защищает от следующего удара, при условии, \nчто удар не огнем");
                                                Console.WriteLine("10. help - если хочешь узнать способности Огонька\n11. clear - чтобы очистить окно");
                                                Console.WriteLine("12. Esc - выход из игры");
                                                inputComand = Console.ReadLine();

                                                switch (inputComand)
                                                {
                                                    case "1":
                                                    case "Кровавый призыв":
                                                    case "кровавый призыв":
                                                        enemyMove = true;
                                                        playerHealth -= 25;
                                                        call = 2;
                                                        break;
                                                    case "2":
                                                    case "Светлячки":
                                                    case "светлячки":
                                                        enemyMove = true;
                                                        if (call >= 0)
                                                        {
                                                            playerHealth += 150;
                                                            if (playerHealth > maxPlayerHealth)
                                                            {
                                                                playerHealth = maxPlayerHealth;
                                                            }
                                                            enemyHealth -= 100;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Сейчас ты не можешь использовать эту способность");
                                                            Console.ReadKey();
                                                            continue;
                                                        }
                                                        break;
                                                    case "3":
                                                    case "Демон":
                                                    case "демон":
                                                        enemyMove = true;
                                                        if (call >= 0)
                                                        {
                                                            playerHealth -= 200;
                                                            enemyHealth -= 200;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Сейчас ты не можешь использовать эту способность");
                                                            Console.ReadKey();
                                                            continue;
                                                        }
                                                        break;
                                                    case "4":
                                                    case "Кокон":
                                                    case "кокон":
                                                        enemyMove = true;
                                                        playerHealth += 100;
                                                        if (playerHealth > maxPlayerHealth)
                                                        {
                                                            playerHealth = maxPlayerHealth;
                                                        }
                                                        coconStroke = 1;
                                                        break;
                                                    case "10":
                                                    case "help":
                                                        enemyMove = false;
                                                        Console.WriteLine("Способности Огонька:");
                                                        Console.WriteLine("1. Пожирание - Огонек ест свою плоть и в ярости наносит игроку 300 урона. Из раны течет кровь, что отнимает у Огонька по 50 HP в этот следующие 2 хода");
                                                        Console.WriteLine("2. Огненная кровь - может быть активирована при истечении крови. Поджигает противника, нанося ему 150 урона и восстанавливая себе 50 HP");
                                                        Console.WriteLine("3. Обычный удар - наносит игроку случайный урон от 50 до 100");
                                                        Console.WriteLine("4. Пелвок - наносит 200 урона кислотой");
                                                        break;
                                                    case "11":
                                                    case "clear":
                                                        enemyMove = false;
                                                        Console.Clear();
                                                        break;
                                                    case "100":
                                                        enemyMove = false;
                                                        enemyHealth = 0;
                                                        break;
                                                    case "1000":
                                                        enemyMove = false;
                                                        playerHealth += enemyHealth;
                                                        enemyHealth = playerHealth - enemyHealth;
                                                        playerHealth -= enemyHealth;

                                                        maxPlayerHealth += maxEnemyHealth;
                                                        maxEnemyHealth = maxPlayerHealth - maxEnemyHealth;
                                                        maxPlayerHealth -= maxEnemyHealth;
                                                        break;
                                                    case "12":
                                                    case "Esc":
                                                        exitBoss = true;
                                                        Console.WriteLine($"Огонек еще не побежден, {name}! Возвращайся");
                                                        continue;
                                                    default:
                                                        continue;
                                                }

                                                enemyComand = rand.Next(1, 5);

                                                if (enemyMove)
                                                {
                                                    switch (enemyComand)
                                                    {
                                                        case 1:
                                                            Console.WriteLine("Огонек использовал Пожирание");
                                                            if (coconStroke < 1)
                                                            {
                                                                playerHealth -= 300;
                                                            }
                                                            bloodStroke = 3;
                                                            break;
                                                        case 2:
                                                        case 3:
                                                            if (bloodStroke > 0)
                                                            {
                                                                Console.WriteLine("Огонек использовал Огненную кровь");
                                                                playerHealth -= 150;
                                                                enemyHealth += 50;
                                                                if (enemyHealth > maxEnemyHealth)
                                                                {
                                                                    enemyHealth = maxEnemyHealth;
                                                                }
                                                                break;
                                                            }

                                                            if (coconStroke < 1)
                                                            {
                                                                Console.WriteLine("Огонек использовал Обычный удар");
                                                                playerHealth -= rand.Next(50, 101);
                                                            }
                                                            break;
                                                        case 4:
                                                            Console.WriteLine("Огонек использовал Плевок");
                                                            if (coconStroke < 1)
                                                            {
                                                                playerHealth -= 200;
                                                            }
                                                            break;
                                                    }

                                                    if (bloodStroke > 0)
                                                    {
                                                        enemyHealth -= 50;
                                                    }

                                                    call--;
                                                    coconStroke--;
                                                    bloodStroke--;
                                                    Console.ReadKey();
                                                }
                                            }

                                            if (playerHealth > 0 && !exitBoss)
                                            {
                                                Console.WriteLine($"\n\nПоздравляю, {name}! Ты победил!");
                                            }
                                            else if (!exitBoss)
                                            {
                                                Console.WriteLine($"\n\nТы пал, {name}... Огонек победил! Надеюсь в следующий раз у тебя получится одолеть злобного Огонька");
                                            }
                                            Console.ReadKey();
                                            break;
                                        case "3":
                                            exitGame = true;
                                            break;
                                        default:
                                            Console.WriteLine("\nЯ не знаю такой команды");
                                            Console.ReadKey();
                                            break;
                                    }
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Пароль не верный. Попробуйте еще раз");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case "9":
                    case "Esc":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\nЯ не знаю такой команды");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
    }
}
