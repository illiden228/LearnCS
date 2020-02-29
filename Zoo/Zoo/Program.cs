using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            Random random = new Random();
            string[] parrotPhrases = { "Чего пялишься?", "Как достал меня этот лев", "Еще один приперся...", "" };

            zoo.CreateAviary();
            zoo.CreateTigrInAviary(0, "Людоед", false);
            zoo.CreateSnakeInAviary(0, "Людоглот", true);
            zoo.CreateSnakeInAviary(0, "Живоротень", true);

            zoo.CreateAviary();
            zoo.CreateMouseInAviary(1, "Завтрак", false);
            zoo.CreateMouseInAviary(1, "Обед", false);
            zoo.CreateMouseInAviary(1, "Ужин", false);
            zoo.CreateSnakeInAviary(1, "Голодавка", false);

            zoo.CreateAviary();
            zoo.CreateTigrInAviary(2, "Белоклык", true);
            zoo.CreateTigrInAviary(2, "Пушистик", false);

            zoo.CreateAviary();
            zoo.CreateParrotInAviary(3, "Додо", false, parrotPhrases[random.Next(0, parrotPhrases.Length)]);
            zoo.CreateLeonInAviary(3, "Симба", false);

            zoo.ShowMenu();
        }
    }

    class Zoo
    {
        private Aviary[] _aviaries = new Aviary[0];
        private int _number;

        public Zoo()
        {
            _number = 1;
        }

        public void CreateAviary()
        {
            Aviary[] newAviaries = new Aviary[_aviaries.Length + 1];
            for (int i = 0; i < _aviaries.Length; i++)
            {
                newAviaries[i] = _aviaries[i];
            }
            newAviaries[newAviaries.Length - 1] = new Aviary(_number++);
            _aviaries = newAviaries;
        }

        public void CreateTigrInAviary(int index, string name, bool sex)
        {
            _aviaries[index].CreateTigr(name, sex);
        }

        public void CreateSnakeInAviary(int index, string name, bool sex)
        {
            _aviaries[index].CreateSnake(name, sex);
        }

        public void CreateMouseInAviary(int index, string name, bool sex)
        {
            _aviaries[index].CreateMouse(name, sex);
        }

        public void CreateParrotInAviary(int index, string name, bool sex, string voice = "")
        {
            _aviaries[index].CreateParrot(name, sex, voice);
        }

        public void CreateLeonInAviary(int index, string name, bool sex)
        {
            _aviaries[index].CreateLeon(name, sex);
        }

        public void ShowMenu()
        {
            bool exit = false;
            while(!exit)
            {
                Console.WriteLine("Добро пожаловать в Зоопарк!\n\nВ нашем зоопарке " + _aviaries.Length + " вольеров. Выберите, какой вы хотите посмотреть: \n");
                for (int i = 0; i < _aviaries.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". посмотреть вольер №" + _aviaries[i].GetIndex());
                    Console.WriteLine();
                }
                Console.WriteLine((_aviaries.Length + 1) + ". Выход из зоопарка");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == _aviaries.Length + 1)
                {
                    exit = true;
                }
                if (input >= 0 && input < _aviaries.Length + 1)
                {
                    Console.Clear();
                    _aviaries[input - 1].ShowMenu();
                }
                Console.Clear();
            }
        }
    }

    class Aviary
    {
        private Animal[] _animals = new Animal[0];
        private AviaryMenu _menu;
        private int _number;

        public Aviary(int number)
        {
            _menu = new AviaryMenu(this);
            _number = number;
        }

        public int GetIndex()
        {
            return _number;
        }

        public void CreateTigr(string name, bool sex)
        {
            Animal[] newAnimals = new Animal[_animals.Length + 1];
            for (int i = 0; i < _animals.Length; i++)
            {
                newAnimals[i] = _animals[i];
            }
            newAnimals[newAnimals.Length - 1] = new Tigr(name, sex);
            _animals = newAnimals;
            _menu.AddTigr();
        }

        public void CreateSnake(string name, bool sex)
        {
            Animal[] newAnimals = new Animal[_animals.Length + 1];
            for (int i = 0; i < _animals.Length; i++)
            {
                newAnimals[i] = _animals[i];
            }
            newAnimals[newAnimals.Length - 1] = new Snake(name, sex);
            _animals = newAnimals;
            _menu.AddSnake();
        }

        public void CreateMouse(string name, bool sex)
        {
            Animal[] newAnimals = new Animal[_animals.Length + 1];
            for (int i = 0; i < _animals.Length; i++)
            {
                newAnimals[i] = _animals[i];
            }
            newAnimals[newAnimals.Length - 1] = new Mouse(name, sex);
            _animals = newAnimals;
            _menu.AddMouse();
        }

        public void CreateParrot(string name, bool sex, string voice = "")
        {
            Animal[] newAnimals = new Animal[_animals.Length + 1];
            for (int i = 0; i < _animals.Length; i++)
            {
                newAnimals[i] = _animals[i];
            }
            newAnimals[newAnimals.Length - 1] = new Parrot(name, sex, voice);
            _animals = newAnimals;
            _menu.AddParrot();
        }

        public void CreateLeon(string name, bool sex)
        {
            Animal[] newAnimals = new Animal[_animals.Length + 1];
            for (int i = 0; i < _animals.Length; i++)
            {
                newAnimals[i] = _animals[i];
            }
            newAnimals[newAnimals.Length - 1] = new Leon(name, sex);
            _animals = newAnimals;
            _menu.AddLeon();
        }

        public void ShowAllAnimals()
        {
            foreach (Animal animal in _animals)
            {
                animal.OutputCharacteristics();
                Console.WriteLine();
            }
        }

        public void ShowMenu()
        {
            _menu.ShowMenu();
        }
    }

    class AviaryMenu
    {
        private int _countTigres = 0;
        private int _countSnakes = 0;
        private int _countMouse = 0;
        private int _countParrot = 0;
        private int _countLeon = 0;
        private Aviary _aviary;

        public AviaryMenu(Aviary aviary)
        {
            _aviary = aviary;
        }
        
        public void AddTigr()
        {
            _countTigres++;
        }
        
        public void AddSnake()
        {
            _countSnakes++;
        }
        
        public void AddMouse()
        {
            _countMouse++;
        }
        
        public void AddParrot()
        {
            _countParrot++;
        }
        
        public void AddLeon()
        {
            _countLeon++;
        }

        public void ShowAviary()
        {
            Console.Write("\nВ вольере №" + _aviary.GetIndex() + " находится: \n" +
                            _countTigres + " тигров\n" +
                            _countSnakes + " змей\n" +
                            _countMouse + " мышей\n" +
                            _countParrot + " попугаев\n" +
                            _countLeon + " львов\n\n");
        }

        public void ShowMenu()
        {
            bool exit = false;
            while(!exit)
            {
                Console.WriteLine("Вольер с животными №" + _aviary.GetIndex() + " Выберите действие: \n\n" +
                    "1. Просмотреть животных\n\n" +
                    "2. Подойти поближе\n\n" +
                    "3. Выход\n\n");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        ShowAviary();
                        break;
                    case 2:
                        Console.WriteLine();
                        _aviary.ShowAllAnimals();
                        break;
                    case 3:
                        Console.WriteLine("Нажмите любую клавишу и вы вйдете из вольера");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Я не знаю такой команды! Повторите еще");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    abstract class Animal
    {
        protected string _name;
        protected bool _sex;
        protected string _voice;
        protected string _kind;
        protected string _type;
        protected Random _random = new Random();

        public Animal(string name, bool sex, string voice, string kind)
        {
            _name = name;
            _sex = sex;
            _voice = voice;
            _kind = kind;
        }

        public void GetName()
        {
            Console.Write("Имя: " + _name);
        }

        public void GetSex()
        {
            string sex;
            if (_sex == false)
            {
                sex = "мужской";
            }
            else
            {
                sex = "женский";
            }
            Console.Write("Пол: " + sex);
        }

        public void GetVoice()
        {
            Console.Write("Звук: " + _voice);
        }

        public void GetKind()
        {
            Console.Write("Вид: " + _kind);
        }

        public void GetTypes()
        {
            Console.Write("Тип: " + _type);
        }

        public virtual void OutputCharacteristics()
        {
            GetName();
            Console.WriteLine();
            GetKind();
            Console.WriteLine();
            GetTypes();
            Console.WriteLine();
            GetVoice();
            Console.WriteLine();
            GetSex();
            Console.WriteLine();
        }
    }

    class Tigr : Animal
    {
        private string[] _types = { "Белый", "Красный" };
        
        public Tigr(string name, bool sex, string voice = "Рааа", string kind = "Тигр") : base(name, sex, voice, kind)
        {
            _type = _types[_random.Next(0, _types.Length)];
        }
    }

    class Snake : Animal
    {
        private string[] _types = { "Кобра", "Белая", "Уж", "Василиск", "Питон", "Удав" };

        public Snake(string name, bool sex, string voice = "Тссссс", string kind = "Змея") : base(name, sex, voice, kind)
        {
            _type = _types[_random.Next(0, _types.Length)];
        }
    }

    class Mouse : Animal
    {
        private string[] _types = { "Белая", "Серая" };

        public Mouse(string name, bool sex, string voice = "Пи-пи-пи", string kind = "Мышь") : base(name, sex, voice, kind)
        {
            _type = _types[_random.Next(0, _types.Length)];
        }
    }

    class Parrot : Animal
    {
        private string[] _types = { "Какаду", "Корелла" };
        public Parrot(string name, bool sex, string voice = "Да нууу тебя", string kind = "Попугай") : base(name, sex, voice, kind)
        {
            _type = _types[_random.Next(0, _types.Length)];
            if(voice == "")
            {
                _voice = "Да нууу тебя";
            }
            else
            {
                _voice = voice;
            }
        }
    }

    class Leon : Animal
    {
        private string[] _types = { "Король", "не-король" };
        public Leon(string name, bool sex, string voice = "Ррррр", string kind = "Лев") : base(name, sex, voice, kind)
        {
            _type = _types[_random.Next(0, _types.Length)];
        }
    }
}
