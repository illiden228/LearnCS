using System;

namespace AutoService
{
    class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service(new Store(), new Storage(), new RandomClientGenerator());
            ServiceMenu serviceMenu = new ServiceMenu(service);
            serviceMenu.MainMenu();
        }
    }

    class ServiceMenu
    {
        private Service _service;

        public ServiceMenu(Service service)
        {
            _service = service;
        }

        public void MainMenu()
        {
            bool work = true;

            while (work)
            {
                Console.Clear();
                Console.WriteLine("Автосервис ПочиниМошинку");
                Console.WriteLine("\nПриехал клиент, ему нужно починить " + _service.GetClient());
                Console.WriteLine("\nВыберите вариант действия: " +
                                    "\n1. Зайти в магазин" +
                                    "\n2. Зайти на склад" +
                                    "\n3. Обслужить клиента " +
                                    "\n4. Отказаться от клиента" +
                                    "\n5. Выход");

                string result = Console.ReadLine();
                switch (result)
                {
                    case "1":
                        StoreMenu();
                        break;
                    case "2":
                        Console.WriteLine("У вас на складе лежат " + _service.Wallet + " и следующие детали:");
                        Console.WriteLine(_service.GetStorage());
                        break;
                    case "3":
                        ServeMenu();
                        break;
                    case "4":
                        _service.RefuseClient();
                        _service.NextClient();
                        Console.WriteLine("Вы отказались обслуживать клиента и получаете штраф! Ваш баланс " + _service.Wallet);
                        break;
                    case "5":
                        work = false;
                        Console.WriteLine("Приходи на работу завтра в то же время! И не опаздывай, бездельник!");
                        break;
                    default:
                        Console.WriteLine("Такой команды не существует");
                        break;
                }
                Console.ReadKey();
            }
        }

        public void StoreMenu()
        {
            bool storeWork = true;

            while (storeWork)
            {
                Console.Clear();
                Console.WriteLine("Вы в магазине, ваш баланс - " + _service.Wallet + ". \nВыберите, что вы хотите сделать: " +
                               "\n1. Открыть список товаров" +
                               "\n2. Купить деталь по номеру из списка" +
                               "\n3. Выход");
                string storeResult = Console.ReadLine();
                switch (storeResult)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Список доступных товаров: \n" + _service.GetStore());
                        break;
                    case "2":
                        Console.Write("Введите номер покупаемой детали: ");
                        if (_service.SellDetail(Convert.ToInt32(Console.ReadLine())))
                        {
                            Console.WriteLine("Поздравляем с новым приобретением!");
                        }
                        else
                        {
                            Console.WriteLine("Покупка не удалась! Проверьте баланс и номер детали");
                        }
                        break;
                    case "3":
                        storeWork = false;
                        break;
                }
                Console.ReadKey();
            }
        }

        public void ServeMenu()
        {
            Console.Clear();
            Console.WriteLine(_service.GetStorage());
            Console.Write("Выедите номер детали: ");
            Detail detail = _service.TakeDetailToStorage(Convert.ToInt32(Console.ReadLine()));
            if(detail != null)
            {
                if (_service.ServeClient(detail))
                {
                    Console.WriteLine("Клиент обслужен! Ваш баланс: " + _service.Wallet);
                }
                else
                {
                    Console.WriteLine("Клиент обслужен неверно, вы платите ущерб! Ваш баланс: " + _service.Wallet);
                }
            }
            else
            {
                Console.WriteLine("Вы ввели неверный номер, что расценивается как отказ от клиента!");
                _service.RefuseClient();
                Console.WriteLine("Вы отказались обслуживать клиента и получаете штраф! Ваш баланс " + _service.Wallet);
            }
            _service.NextClient();
        }
    }

    class Service
    {
        private Store _store;
        private Storage _storage;
        private RandomClientGenerator _randomClientGenerator;
        private CheckList _currentClient;
        private int _penalty = 1000;

        public int Wallet { get; private set; }

        public Service(Store store, Storage storage, RandomClientGenerator randomClientGenerator, int wallet = 20000)
        {
            _store = store;
            _storage = storage;
            _randomClientGenerator = randomClientGenerator;
            _currentClient = randomClientGenerator.CreateClient();
            Wallet = wallet;
        }

        public string GetClient()
        {
            return _currentClient.GetBrokenDetail() + ", за починку заплятят " + _currentClient.GetRepairCost();
        }

        public bool ServeClient(Detail detail)
        {
            _storage.RemoveDetail(detail);
            if (detail.Name == _currentClient.GetBrokenDetail())
            {
                Wallet += _currentClient.GetRepairCost();
                _currentClient = null;
                return true;
            }
            else
            {
                Wallet -= _currentClient.GetDamage(detail);
                _currentClient = null;
                return false;
            }
        }

        public void RefuseClient()
        {
            _currentClient = null;
            Wallet -= _penalty;
        }

        public void NextClient()
        {
            _currentClient = _randomClientGenerator.CreateClient();
        }

        public string GetStore()
        {
            return _store.GetStoreList();
        }

        public bool SellDetail(int index)
        {
            if(_store.CheckIndex(index))
            {
                Detail sellDetail = _store.SellDetail(index);
                if (Wallet < sellDetail.Price)
                {
                    return false;
                }
                else
                {
                    Wallet -= sellDetail.Price;
                    _storage.AddDetail(sellDetail);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public string GetStorage()
        {
            return _storage.GetStorageList();
        }

        public Detail TakeDetailToStorage(int index)
        {
            return index < _storage.StorageDetails.Length ? _storage.StorageDetails[index - 1] : null;
        }
    }

    class Store
    {
        private Detail[] _storeDetails = { new Wheel(), new Brakes(), new Engine(),
                                      new Glass(), new HeadLight(), new SteeringWheel(),
                                      new Door(), new Tire(), new CarGrip()};

        public string GetStoreList()
        {
            string detailsList = "";
            for (int i = 0; i < _storeDetails.Length; i++)
            {
                detailsList += (i + 1) + ". " + _storeDetails[i].Name + " - " + _storeDetails[i].Price + "\n";
            }
            return detailsList;
        }

        public bool CheckIndex(int index)
        {
            return index < _storeDetails.Length ? true : false;
        }

        public Detail SellDetail(int index)
        {
            return _storeDetails[index - 1];
        }
    }

    class Storage
    {
        public Detail[] StorageDetails { get; private set; } = { new Wheel(), new Brakes(), new Engine(),
                                                                 new Glass(), new HeadLight(), new SteeringWheel(),
                                                                 new Door(), new Tire(), new CarGrip(),
                                                                 new Wheel(), new Brakes(), new Engine(),
                                                                 new Glass(), new HeadLight(), new SteeringWheel(),
                                                                 new Door(), new Tire(), new CarGrip() };

        public void AddDetail(Detail newDetail)
        {
            Detail[] newStorageDetails = new Detail[StorageDetails.Length + 1];
            for (int i = 0; i < StorageDetails.Length; i++)
            {
                newStorageDetails[i] = StorageDetails[i];
            }
            newStorageDetails[StorageDetails.Length] = newDetail;
            StorageDetails = newStorageDetails;
        }

        public void RemoveDetail(Detail removeDetail)
        {
            Detail[] newStorageDetails = new Detail[StorageDetails.Length - 1];
            int removeDetailIndex = 0;
            for (int i = 0; i < StorageDetails.Length; i++)
            {
                if(StorageDetails[i].Name == removeDetail.Name)
                {
                    removeDetailIndex = i;
                    break;
                }
            }
            int index = 0;
            for (int i = 0; i < newStorageDetails.Length; i++)
            {
                if(index == removeDetailIndex)
                {
                    index++;
                }
                newStorageDetails[i] = StorageDetails[index];
                index++;
            }
            StorageDetails = newStorageDetails;
        }

        public string GetStorageList()
        {
            string detailList = "";
            for (int i = 0; i < StorageDetails.Length; i++)
            {
                detailList += (i + 1) + ". " + StorageDetails[i].Name + "\n";
            }
            return detailList;
        }
    }

    class RandomClientGenerator
    {
        private Detail[] _details = { new Wheel(), new Brakes(), new Engine(), 
                                      new Glass(), new HeadLight(), new SteeringWheel(), 
                                      new Door(), new Tire(), new CarGrip()};
        private Random _random = new Random();

        public CheckList CreateClient()
        {
            return new CheckList(_details[_random.Next(0, _details.Length)]);
        }
    }

    class CheckList
    {
        private Detail _brokenDetail;

        public CheckList(Detail brokenDeatil)
        {
            _brokenDetail = brokenDeatil;
        }

        public string GetBrokenDetail()
        {
            return _brokenDetail.Name;
        }

        public int GetRepairCost()
        {
            return _brokenDetail.Price + _brokenDetail.PriceForWork;
        }

        public int GetDamage(Detail replacementDetail)
        {
            return replacementDetail.PriceForDamage + _brokenDetail.Price;
        }
    }

    class CarGrip : Detail
    {
        public CarGrip()
        {
            Name = "Сцепление";
            Price = 3000;
            PriceForWork = 1500;
            PriceForDamage = 300;
        }
    }

    class Tire : Detail
    {
        public Tire()
        {
            Name = "Покрышка";
            Price = 3000;
            PriceForWork = 1500;
            PriceForDamage = 700;
        }
    }

    class Door : Detail
    {
        public Door()
        {
            Name = "Дверь";
            Price = 6000;
            PriceForWork = 1500;
            PriceForDamage = 800;
        }
    }

    class SteeringWheel : Detail
    {
        public SteeringWheel()
        {
            Name = "Руль";
            Price = 7500;
            PriceForWork = 2000;
            PriceForDamage = 1000;
        }
    }

    class HeadLight : Detail
    {
        public HeadLight()
        {
            Name = "Фары";
            Price = 1500;
            PriceForWork = 1000;
            PriceForDamage = 500;
        }
    }

    class Glass : Detail
    {
        public Glass()
        {
            Name = "Стекло";
            Price = 1000;
            PriceForWork = 5000;
            PriceForDamage = 2000;
        }
    }

    class Engine : Detail
    {
        public Engine()
        {
            Name = "Двигатель";
            Price = 30000;
            PriceForWork = 10000;
            PriceForDamage = 5000;
        }
    }

    class Brakes : Detail
    {
        public Brakes()
        {
            Name = "Тормоза";
            Price = 4000;
            PriceForWork = 1000;
            PriceForDamage = 500;
        }
    }

    class Wheel : Detail
    {
        public Wheel()
        {
            Name = "Колесо";
            Price = 2000;
            PriceForWork = 500;
            PriceForDamage = 200;
        }
    }

    abstract class Detail
    {
        public string Name { get; protected set; }
        public int Price { get; protected set; }
        public int PriceForWork { get; protected set; }
        public int PriceForDamage { get; protected set; }
    }
}
