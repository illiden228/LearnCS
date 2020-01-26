using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 100;
            bool exit = false;
            Aquarium aqua = new Aquarium();
            aqua.CreateRandomFishes(3);
            
            while (!exit)
            {
                aqua.DrawAquarium();
                aqua.Live();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("space - пауза");
                aqua.ShowFishes(0, 3);

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                        bool menu = true;
                        while (menu)
                        {
                            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                            {
                                menu = false;
                            }
                            Console.Clear();
                            aqua.DrawAquarium();
                            aqua.ShowFishes(50, 15);
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("1. Добавить рыб\n\n2. Удалить рыбу\n\n3. Изменить рыбе имя\n\n4. Очистить аквариум от мертвых рыб\n\n5. Выход из меню\n\n6. Выход\n\n");
                            Console.Write("Введите номер команды: ");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.Write("\nСколько рыб вы хотите добавить: ");
                                    aqua.CreateRandomFishes(Convert.ToInt32(Console.ReadLine()));
                                    break;
                                case "2":
                                    Console.Write("\nВведите номер рыбы: ");
                                    aqua.DeleteFish(Convert.ToInt32(Console.ReadLine()) - 1);
                                    break;
                                case "3":
                                    Console.Write("\nВведите номер рыбы: ");
                                    int n = Convert.ToInt32(Console.ReadLine()) - 1;
                                    Console.Write($"Введите новое имя для {aqua.fishes[n].Name}: ");
                                    aqua.fishes[n].SetName(Console.ReadLine());
                                    break;
                                case "4":
                                    aqua.DeleteDeadFishes();
                                    Console.ReadKey();
                                    break;
                                case "5":
                                    menu = false;
                                    Console.Clear();
                                    aqua.DrawAquarium();
                                    break;
                                case "6":
                                    menu = false;
                                    exit = true;
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.WriteLine("Я не знаю такой команды");
                                    break;
                            }
                        
                    }
                }
                System.Threading.Thread.Sleep(1000);
            }
            Console.ReadKey();
        }
    }

    class Aquarium
    {
        char[,] _aquarium =
            {
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            };

        private string[] _names = { "Леле", "Нана", "Таната", "Адора", "Тира" };
        private string[] _types = { "Золотая", "Обычная", "Гуппи" };
        public Fish[] fishes = new Fish[0];
        public int MaxValue { get; private set; }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        Random random = new Random();

        public Aquarium(int maxValue = 10, int x = 50, int y = 0)
        {
            MaxValue = maxValue;
            PositionX = x;
            PositionY = y;
        }

        public void ChangePosition(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }

        public void DrawAquarium()
        {
            int row = PositionY;
            int column = PositionX;
            for (int i = 0; i < _aquarium.GetLength(0); i++)
            {
                for (int j = 0; j < _aquarium.GetLength(1); j++)
                {
                    Console.SetCursorPosition(column++, row);
                    if (_aquarium[i, j] == '@')
                    {
                        DrawAquariumFish(j, i);
                        continue;
                    }
                    Console.Write(_aquarium[i, j]);
                }
                row++;
                column = PositionX;
                Console.WriteLine();
            }
        }

        public void DrawAquariumFish(int x, int y)
        {
            for (int i = 0; i < fishes.Length; i++)
            {
                if (fishes[i].X == x && fishes[i].Y == y)
                {
                    fishes[i].DrawFish();
                }
            }
        }
        
        public void CreateRandomFishes(int n = 1)
        {
            if (n + fishes.Length <= MaxValue)
            {
                for (int i = 0; i < n; i++)
                {
                    CreateFish(_names[random.Next(0, _names.Length)], random.Next(10, 200), _types[random.Next(0, _types.Length)]);
                }
            }
            else
            {
                n = MaxValue - fishes.Length;
                Console.WriteLine("Возможно создать только " + n + " рыб! Попробуйте снова");
                Console.ReadKey();
            }
            
        }

        public void CreateFish(string name, int hp, string type)
        {
            Fish[] newFishes = new Fish[fishes.Length + 1];

            for (int i = 0; i < fishes.Length; i++)
            {
                newFishes[i] = fishes[i];
            }
            newFishes[newFishes.Length - 1] = new Fish(name, hp, type, random.Next(2, 44), random.Next(1, 11));
            fishes = newFishes;

            foreach (Fish fish in fishes)
            {
                _aquarium[fish.Y, fish.X] = '@';
            }
        }

        public void DeleteFish(int deleteFish)
        {
            Fish[] newFishes = new Fish[fishes.Length - 1];
            int index = 0;
            if (fishes.Length > deleteFish)
            {
                if (deleteFish == fishes.Length - 1)
                {
                    _aquarium[fishes[fishes.Length - 1].Y, fishes[fishes.Length - 1].X] = ' ';
                }
                for (int i = 0; i < newFishes.Length; i++)
                {
                    if (deleteFish == i)
                    {
                        _aquarium[fishes[i].Y, fishes[i].X] = ' ';
                        index++;
                    }
                    newFishes[i] = fishes[index];
                    index++;
                }
                fishes = newFishes;
            }
            else
            {
                Console.Write("Рыбы стаким номером не существет!");
                Console.ReadKey();
            }
        }

        public void DeleteDeadFishes()
        {
            for (int i = 0; i < fishes.Length; i++)
            {
                if (!fishes[i].Alive)
                {
                    DeleteFish(i--);
                }
            }

            for (int i = 1; i < _aquarium.GetLength(1) - 1; i++)
            {
                _aquarium[0, i] = ' ';
            }
        }

        public void ShowFishes(int x = 0, int y = 0)
        {
            int row = y;
            int column = x;
            for (int i = 0; i < fishes.Length; i++)
            {
                Console.SetCursorPosition(column, row++);
                Console.Write((i + 1) + ". ");
                fishes[i].ShowStats();
            }
        }

        public void Live()
        {
            foreach (Fish fish in fishes)
            {
                fish.IsAlive();
                fish.Oldest();
                fish.Move(random, _aquarium);
            }
        }
    }

    class Fish : Behaviour
    {
        public int Health { get; private set; }
        public string Name { get; private set;  }
        public bool Alive { get; private set; }
        public string Type { get; private set; }
        private char _symbol;
        private ConsoleColor _color;
        private ConsoleColor _defaultColor = Console.ForegroundColor;

        public Fish(string name, int hp, string type, int x, int y) : base(x, y)
        {
            Name = name;
            Health = hp;
            Type = type;
            X = x;
            Y = y;
            _symbol = '>';
            Alive = Health > 0;
            switch (type.ToLower())
            {
                case "обычная":
                    _color = ConsoleColor.White;
                    break;
                case "золотая":
                    _color = ConsoleColor.Yellow;
                    break;
                case "гуппи":
                    _color = ConsoleColor.Blue;
                    break;
            }
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void IsAlive()
        {
            Alive = Health > 0;
        }

        public void Oldest()
        {
            if (Alive)
            {
                Health--;
            }
        }

        public void DrawFish()
        {
            Console.ForegroundColor = _color;
            Console.Write(_symbol);
            Console.ForegroundColor = _defaultColor;
        }

        public void ShowStats()
        {
            if (Alive)
            {
                Console.Write($"{Name} - ");
                Console.ForegroundColor = _color;
                Console.Write(Type);
                Console.ForegroundColor = _defaultColor;
                Console.WriteLine($" : {Health}   ");
            }
            else
            {
                Console.Write($"{Name} - ");
                Console.ForegroundColor = _color;
                Console.Write(Type);
                Console.ForegroundColor = _defaultColor;
                Console.WriteLine($": мертва   ");
            }
        }

        public void Move(Random rand, char[,] aqua)
        {
            Direction(rand, aqua, Alive);

            if (Alive)
            {
                if (dx < 0)
                {
                    _symbol = '<';
                }
                else
                {
                    _symbol = '>';
                }
            }
            else
            {
                _symbol = 'x';
            }

            if (aqua[Y + dy, X + dx] != '#')
            {
                X += dx;
                Y += dy;
                aqua[Y - dy, X - dx] = ' ';
            }
            
            aqua[Y, X] = '@';
        }
    }

    class Behaviour
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        protected int dx = 1;
        protected int dy = 0;

        public Behaviour(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        protected void Direction(Random rand, char[,] aqua, bool alive)
        {
            if (Y > 0 && !alive)
            {
                dx = 0;
                dy = -1;
                return;
            }
            else if (Y == 0 && !alive)
            {
                dx = 0;
                dy = 0;
                return;
            }
            if (Y + dy < 0 && alive)
            {
                dy = 1;
                return;
            }

            while(true)
            {
                dx = rand.Next(-1, 2);
                dy = rand.Next(-1, 2);
                if (X + dx > 0 && X + dx < aqua.GetLength(1) && Y + dy > 0 && Y + dy < aqua.GetLength(0))
                {
                    if (aqua[Y + dy, X + dx] == ' ')
                    {
                        break;
                    }
                    else if (X + dx == X && Y + dy == Y)
                    {
                        break;
                    }
                }
            }
        }
    }
}
