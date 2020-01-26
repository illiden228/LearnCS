using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docs
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[0];
            string[] posts = new string[0];
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Кадровый учет. Меню:\n\n" +
                                "1. Добавить досье\n\n" +
                                "2. Вывести все досье\n\n" +
                                "3. Удалить досье\n\n" +
                                "4. Поиск по фамилии\n\n" +
                                "5. Выход\n");
                Console.Write("Введите номер команды: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("\nВведите ФИО через пробел: ");
                        string fio = Console.ReadLine() + " ";
                        Console.Write("Введите должность: ");
                        string post = Console.ReadLine();
                        AddDoc(ref names, ref posts, fio, post);
                        break;
                    case "2":
                        ShowDoc(names, posts);
                        break;
                    case "3":
                        Console.Write("\nВведите номер удаляемого досье: ");
                        int deleteNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                        DeleteDoc(ref names, ref posts, deleteNumber);
                        break;
                    case "4":
                        Console.Write("\nВведите фамилиию: ");
                        string surname = Console.ReadLine();
                        Search(names, posts, surname);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\nТакой команды не существует");
                        Console.ReadKey();
                        break;
                }
            }

            static void AddDoc(ref string[] fio, ref string[] position, string newFio, string newPosition) 
            {
                string[] addFio = new string[fio.Length + 1];
                string[] addPosition = new string[position.Length + 1]; 
                
                for (int i = 0; i < fio.GetLength(0); i++)
                {
                    addFio[i] = fio[i];
                    addPosition[i] = position[i];
                }

                addFio[addFio.Length - 1] = newFio;
                addPosition[addPosition.Length - 1] = newPosition;
                fio = addFio;
                position = addPosition;
            }

            static void ShowDoc(string[] fio, string[] position)
            {
                for (int i = 0; i < position.Length; i++)
                {
                    Console.WriteLine(Convert.ToString(i + 1) + ". " + fio[i] + "- " + position[i]);
                }
                Console.ReadKey();
            }

            static void DeleteDoc(ref string[] fio, ref string[] position, int deleteDocIndex)
            {
                if (fio.Length < deleteDocIndex)
                {
                    Console.WriteLine("\nДосье под таким номером не существует");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    string[] newFio = new string[fio.Length - 1];
                    string[] newPosts = new string[position.Length - 1];
                    int index = 0;

                    for (int i = 0; i < newFio.Length; i++)
                    {
                        if (i == deleteDocIndex)
                        {
                            index++;
                        }
                        newFio[i] = fio[index];
                        newPosts[i] = position[index];
                        index++;
                    }
                    fio = newFio;
                    position = newPosts;
                }
            }

            static void Search(string[] fio, string[] position, string searchWord)
            {
                string[] search = new string[3];
                for (int i = 0; i < fio.Length; i++)
                {
                    search = fio[i].ToLower().Split();
                    if (search[0] == searchWord.ToLower())
                    {
                        Console.WriteLine(Convert.ToString(i + 1) + ". " + fio[i] + "- " + position[i]);
                        break;
                    }
                    if (search[0] != searchWord.ToLower() && i == fio.Length - 1)
                    {
                        Console.WriteLine("\nФамилия не найдена");
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
