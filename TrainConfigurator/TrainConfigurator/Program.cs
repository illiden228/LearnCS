using System;

namespace TrainConfigurator
{
    class Program
    {
        static void Main(string[] args)
        {
            Configurator configurator = new Configurator();
            configurator.Menu();
        }
    }

    class Configurator
    {
        private int _stage = 1;
        private string _departure = " ";
        private string _arrival = " ";
        private int _passagers = 0;
        private string _departTable = "";

        public void Menu(bool exit = false)
        {
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в конфигуратор пассажирских поездов!\n\n" + Table() +
                                    "\n\nВыберите действие:");
                switch (_stage)
                {
                    case 1:
                        exit = DirectionStage();
                        break;
                    case 2:
                        exit = TiketStage();
                        break;
                    case 3:
                        exit = TrainStage();
                        break;
                    case 4:
                        exit = DepartStage();
                        break;
                }
                Console.ReadKey();
            }
        }

        public void Cancel()
        {
            _stage = 1;
            _departure = " ";
            _arrival = " ";
            _passagers = 0;
        }

        public void SetDepartTable(int places, int smallWagons, int mediumWagons, int largeWagons)
        {
            _departTable = $"По направлению \"{_departure} - {_arrival}\", " +
                $"рассчитанный на {places} мест " +
                $"и состоящий из \n{smallWagons} маленьких вагонов, {mediumWagons} средних вагонов и {largeWagons} больших вагонов " +
                $"отправился с {_passagers} пассажирами.\n" +
                $"В поезде осталось {places - _passagers} свободных мест";
        }

        private void SetDeparture()
        {
            Console.Write("\nВведите место отправления: ");
            _departure = Console.ReadLine();
        }

        private void SetArrival()
        {
            Console.Write("\nВведите место назначения: ");
            _arrival = Console.ReadLine();
        }

        private string Table()
        {
            string direction = _departure + " - " + _arrival;
            string table = $"Составляется поезд по направлению \"{direction}\"";
            if (direction != "  -  ")
            {
                if (_passagers > 0)
                {
                    table += ", продано " + _passagers + " билетов";
                    return table;
                }
                else
                {
                    return table;
                }
            }
            else
            {
                return "Направление поезда не задано";
            }
        }

        private void SellTikets()
        {
            Random random = new Random();
            _passagers = random.Next(50, 2021);
        }

        private bool IsSetDirection()
        {
            if (_departure == " " || _arrival == " ")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool DirectionStage()
        {
            Console.WriteLine("1. Задать место отправления" +
                            "\n2. Задать место назначения" +
                            "\n3. Выход");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    SetDeparture();
                    break;
                case 2:
                    SetArrival();
                    break;
                case 3:
                    return true;
            }
            if (IsSetDirection())
            {
                _stage++;
                return false;
            }
            else
            {
                return false;
            }
        }

        private bool TiketStage()
        {
            Console.WriteLine("1. Изменить место отправления" +
                            "\n2. Изменить место назначения" +
                            "\n3. Отмена поезда" +
                            "\n4. Продать билеты" +
                            "\n5. Выход");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    SetDeparture();
                    return false;
                case 2:
                    SetArrival();
                    return false;
                case 3:
                    Cancel();
                    return false;
                case 4:
                    SellTikets();
                    _stage++;
                    return false;
                case 5:
                    return true;
                default:
                    return false;
            }
        }

        private bool TrainStage()
        {
            TrainConstructor trainConstructor = new TrainConstructor(_passagers, this);
            trainConstructor.Menu(Table());
            _stage++;
            return false;
        }

        private bool DepartStage()
        {
            Console.WriteLine("1. Отправить поезд" +
                            "\n2. Отмена поезда" +
                            "\n3. Выход");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine(_departTable);
                    Cancel();
                    Console.WriteLine("\nНажмите любую клавишу, чтобы составить еще один поезд или 1 - чтобы выйти");
                    if (Console.ReadLine() == "1")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 2:
                    Cancel();
                    return false;
                case 5:
                    return true;
                default:
                    return false;
            }
        }
    }

    class TrainConstructor
    {
        private int _passagers;
        private int _places = 0;
        private int _smallWagonCount = 0;
        private int _mediumWagonCount = 0;
        private int _largeWagonCount = 0;
        private Configurator _configurator;

        public TrainConstructor(int passagers, Configurator configurator)
        {
            _passagers = passagers;
            _configurator = configurator;
        }

        public void Menu(string table)
        {
            bool exit = false;
            string fix;
            while (!exit)
            {
                Console.Clear();
                _places = _smallWagonCount * 50 + _mediumWagonCount * 100 + _largeWagonCount * 200;
                if (_places >= _passagers)
                {
                    fix = "";
                }
                else
                {
                    fix = "(невозможно, недостаточно мест)";
                }
                Console.WriteLine("Добро пожаловать в конфигуратор пассажирских поездов!\n\n" + table +
                                    "\n\nСейчас в поезде " + _places + " мест" +
                                    "\n\nСписок вагонов:" +
                                    "\nМаленьких (на 50 пассажиров) - " + _smallWagonCount +
                                    "\nСредних (на 100 пассажиров) - " + _mediumWagonCount +
                                    "\nБольших (на 200 пассажиров) - " + _largeWagonCount +
                                    "\n\nВыберите действие:" +
                                    "\n1. Добавить вагоны" +
                                    "\n2. Удалить вагоны" +
                                    "\n3. Сбросить" +
                                    "\n4. Отмена поезда" +
                                    "\n5. Зафиксировать конфигурацию поезда" + fix +
                                    "\n6. Выход");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AddWagon();
                        break;
                    case 2:
                        DeleteWagon();
                        break;
                    case 3:
                        DeleteAllWagons();
                        break;
                    case 4:
                        _configurator.Cancel();
                        _configurator.Menu();
                        break;
                    case 5:
                        if (_places >= _passagers)
                        {
                            exit = true;
                            _configurator.SetDepartTable(_places, _smallWagonCount, _mediumWagonCount, _largeWagonCount);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("\nПассажирам недостаточно мест, добавьте больше вагонов");
                        }
                        break;
                    case 6:
                        exit = true;
                        _configurator.Menu(true);
                        break;
                }
                Console.ReadKey();
            }
        }

        private void AddWagon()
        {
            Console.Write("\nКакой вагон вы хотите добавить?");
            ApplyWagon(1);
        }

        private void DeleteWagon()
        {
            Console.Write("\nКакой вагон вы хотите удалить?");
            ApplyWagon(-1);
        }

        private void ApplyWagon(int count)
        {
            Console.WriteLine(" (1 - маленький, 2 - средний, 3 - большой)");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    _smallWagonCount += count;
                    break;
                case 2:
                    _mediumWagonCount += count;
                    break;
                case 3:
                    _largeWagonCount += count;
                    break;
            }
        }

        private void DeleteAllWagons()
        {
            _smallWagonCount = 0;
            _mediumWagonCount = 0;
            _largeWagonCount = 0;
        }
    }
}
