using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 20);
                database.ShowDatabase();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("База данных игроков\n");
                Console.WriteLine("1. Добавить игрока\n\n2. Удалить игрока\n\n3. Забанить игрока\n\n4. Разбанить игрока\n\n5. Выход");
                Console.Write("\nВведите номер команды: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("\nВведите имя нового игрока: ");
                        database.AddPlayer(Console.ReadLine());
                        break;
                    case "2":
                        Console.Write("\nВведите ID: ");
                        database.DeletePlayerById(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case "3":
                        Console.Write("\nВведите ID: ");
                        database.BannedById(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case "4":
                        Console.Write("\nВведите ID: ");
                        database.UnbannedById(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Такой команды не существует!");
                        break;
                }
                Console.ReadKey();
            }
        }
    }

    class Database
    {
        Player[] players = new Player[0];

        public void AddPlayer(string name)
        {
            Player[] newPlayers = new Player[players.Length + 1];
            for (int i = 0; i < players.Length; i++)
            {
                newPlayers[i] = players[i];
            }
            newPlayers[newPlayers.Length - 1] = new Player(name);
            players = newPlayers;
        }

        public void DeletePlayerById(int id)
        {
            Player[] newPlayers = new Player[players.Length - 1];
            int index = 0;
            for (int i = 0; i < newPlayers.Length; i++)
            {
                if (players[i].Number == id)
                {
                    index++;
                }
                newPlayers[i] = players[index];
                index++;
            }
            players = newPlayers;
        }

        public void BannedById(int id)
        {
            foreach (Player player in players)
            {
                if (player.Number == id)
                {
                    player.Banned();
                    return;
                }
            }
            Console.WriteLine("\nИгрока с таким ID не существуйет!");
        }

        public void UnbannedById(int id)
        {
            foreach (Player player in players)
            {
                if (player.Number == id)
                {
                    player.Unbanned();
                    return;
                }
            }
            Console.WriteLine("\nИгрока с таким ID не существуйет!");
        }

        public void ShowDatabase()
        {
            foreach (Player player in players)
            {
                player.ShowPlayerInfo();
            }
        }
    }

    class Player
    {
        public static int Ids = 1;
        public string NickName { get; private set; }
        public int Number { get; private set; }
        public int Level { get; private set; }

        private bool _ban;

        public Player(string nickName, bool ban = false)
        {
            NickName = nickName;
            Number = Ids++;
            Level = 0;
            _ban = ban;
        }

        public void ShowPlayerInfo()
        {
            Console.Write($"ID: {Number}, Name: {NickName}, Level: {Level}, Banned: {_ban} \n");
        }

        public void Banned()
        {
            _ban = true;
        }

        public void Unbanned()
        {
            _ban = false;
        }
    }
}
