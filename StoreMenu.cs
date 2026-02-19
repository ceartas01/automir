// TODO:
// 1. Реализовать поиск запчастей по автомобилю
// 2. Реализовать оформление заказа на запчасти
// 3. Реализовать консультацию по подбору запчастей для ремонта

// TODO:
// 1. Реализовать поиск запчастей по автомобилю
// 2. Реализовать оформление заказа на запчасти
// 3. Реализовать консультацию по подбору запчастей для ремонта

using System;
using System.Collections.Generic;

namespace AutoPartsStore
{
    public class StoreMenu
    {
        private StoreManager manager;
        
        public StoreMenu()
        {
            manager = new StoreManager();
            InitializeStoreData();
        }
        
        private void InitializeStoreData()
        {
            // Инициализация тестовых данных - запчасти
            manager.AddPart(new AutoPart(1, "Тормозной диск", "Toyota", "Corolla", 2015, 3200, 15, 12, "Тормоза"));
            manager.AddPart(new AutoPart(2, "Свеча зажигания", "Toyota", "Corolla", 2015, 450, 50, 6, "Двигатель"));
            manager.AddPart(new AutoPart(3, "Масляный фильтр", "Toyota", "Corolla", 2010, 350, 30, 12, "Двигатель"));
            manager.AddPart(new AutoPart(4, "Амортизатор", "Volkswagen", "Polo", 2018, 4200, 8, 24, "Подвеска"));
            manager.AddPart(new AutoPart(5, "Генератор", "Lada", "Vesta", 2020, 8500, 5, 12, "Электрика"));
            
            // Инициализация ремонтных комплектов
            RepairKit toyotaServiceKit = new RepairKit(1, "Комплект ТО Toyota Corolla", "Техобслуживание", 
                "Toyota", "Corolla", 2010, 2020, "Простая");
            // TODO: Добавить запчасти в комплект
            manager.AddRepairKit(toyotaServiceKit);
        }
        
        // TODO 1: Поиск запчастей по автомобилю
        public void SearchPartsByCar()
        {
            Console.WriteLine("=== ПОИСК ЗАПЧАСТЕЙ ПО АВТОМОБИЛЮ ===");

            // 1. Запросить марку автомобиля
            Console.Write("Введите марку автомобиля: ");
            string brand = Console.ReadLine();

            // 2. Запросить модель
            Console.Write("Введите модель автомобиля: ");
            string model = Console.ReadLine();

            // 3. Запросить год выпуска
            Console.Write("Введите год выпуска автомобиля: ");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.Write("Некорректный ввод. Введите год выпуска цифрами: ");
            }

            // 4. Найти запчасти через manager.FindPartsForCar()
            List<AutoPart> foundParts = manager.FindPartsForCar(brand, model, year);

            // 5. Сгруппировать найденные запчасти по категориям
            var partsByCategory = new Dictionary<string, List<AutoPart>>();
            foreach (var part in foundParts)
            {
                if (!partsByCategory.ContainsKey(part.Category))
                    partsByCategory[part.Category] = new List<AutoPart>();
                partsByCategory[part.Category].Add(part);
            }

            // 6. Вывести результат поиска
            if (foundParts.Count == 0)
            {
                Console.WriteLine("Подходящие запчасти не найдены.");
                return;
            }

            foreach (var category in partsByCategory.Keys)
            {
                Console.WriteLine($"\n=== Категория: {category} ===");
                foreach (var part in partsByCategory[category])
                {
                    Console.WriteLine(part.ToString());
                }
            }
        }
        
        // TODO 1: Показать ремонтные комплекты
        public void ShowRepairKits()
        {
            Console.WriteLine("=== РЕМОНТНЫЕ КОМПЛЕКТЫ ===");

            // Получить все комплекты через manager.GetAllRepairKits()
            List<RepairKit> kits = manager.GetAllRepairKits();

            // Сгруппировать комплекты по типу ремонта
            var kitsByType = new Dictionary<string, List<RepairKit>>();
            foreach (var kit in kits)
            {
                if (!kitsByType.ContainsKey(kit.RepairType))
                    kitsByType[kit.RepairType] = new List<RepairKit>();
                kitsByType[kit.RepairType].Add(kit);
            }

            // Для каждого комплекта вызвать ShowKitComposition()
            foreach (var type in kitsByType.Keys)
            {
                Console.WriteLine($"\n=== Тип ремонта: {type} ===");
                foreach (var kit in kitsByType[type])
                {
                    kit.ShowKitComposition();
                }
            }
        }
        
        // TODO 2: Оформить заказ на запчасти
        public void ProcessOrder()
        {
            Console.WriteLine("=== ОФОРМЛЕНИЕ ЗАКАЗА НА ЗАПЧАСТИ ===");

            // 1. Найти клиента по телефону
            Console.Write("Введите номер телефона клиента: ");
            string phone = Console.ReadLine();

            Customer customer = manager.FindCustomerByPhone(phone);

            // 2. Если клиент не найден - зарегистрировать нового
            if (customer == null)
            {
                Console.WriteLine("Клиент не найден. Регистрация нового клиента.");

                Console.Write("ФИО: ");
                string name = Console.ReadLine();

                Console.Write("Марка авто: ");
                string brand = Console.ReadLine();

                Console.Write("Модель авто: ");
                string model = Console.ReadLine();

                Console.Write("Год выпуска: ");
                int year = int.Parse(Console.ReadLine());

                Console.Write("Госномер: ");
                string license = Console.ReadLine();

                Console.Write("VIN: ");
                string vin = Console.ReadLine();

                customer = manager.RegisterCustomer(name, phone, brand, model, year, license, vin);
            }

            // 3. Создать заказ
            var order = customer.CreateOrder();
            order.OrderNumber = manager.GetNextOrderNumber();

            // 4. Найти запчасти для автомобиля клиента
            List<AutoPart> parts = manager.FindPartsForCar(customer.CarBrand, customer.CarModel, customer.CarYear);

            if (parts.Count == 0)
            {
                Console.WriteLine("Нет доступных запчастей.");
                return;
            }

            Console.WriteLine("Доступные запчасти:");
            for (int i = 0; i < parts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {parts[i]}");
            }

            // 5. Добавление запчастей в заказ
            Console.Write("Выберите номер запчасти: ");
            int choice = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Количество: ");
            int quantity = int.Parse(Console.ReadLine());

            if (customer.AddToOrder(order, parts[choice], quantity, "Ремонт"))
            {
                parts[choice].Sell(quantity);
                Console.WriteLine("Запчасть добавлена в заказ.");
            }
            else
            {
                Console.WriteLine("Не удалось добавить запчасть.");
            }

            // 6. Рассчитать стоимость заказа
            decimal total = customer.CalculateOrderTotal(order);
            order.TotalAmount = total;

            // 7. Зафиксировать продажу
            manager.RecordSale(total);

            Console.WriteLine($"Заказ оформлен. Номер заказа: {order.OrderNumber}");
            Console.WriteLine($"Сумма к оплате: {total} руб.");
        }   
        
        // TODO 3: Консультация по ремонту
        public void ProvideRepairConsultation()
        {
            Console.WriteLine("=== КОНСУЛЬТАЦИЯ ПО РЕМОНТУ ===");

            // 1. Запросить данные автомобиля
            Console.Write("Марка автомобиля: ");
            string brand = Console.ReadLine();

            Console.Write("Модель автомобиля: ");
            string model = Console.ReadLine();

            Console.Write("Год выпуска: ");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.Write("Введите корректный год: ");
            }

            // 2. Запросить тип проблемы
            Console.Write("Опишите проблему (например: стук, течь масла, не заводится): ");
            string problem = Console.ReadLine().ToLower();

            // 3. Найти подходящие запчасти
            List<AutoPart> parts = manager.FindPartsForCar(brand, model, year);

            if (parts.Count == 0)
            {
                Console.WriteLine("Подходящих запчастей не найдено.");
                return;
            }

            Console.WriteLine("\nРекомендуемые запчасти:");
            foreach (var part in parts)
            {
                Console.WriteLine(part);
            }

            // 4. Рассчитать примерную стоимость (средняя по найденным)
            decimal approxTotal = 0;
            foreach (var part in parts)
            {
                approxTotal += part.Price;
            }

            Console.WriteLine($"\nПримерная стоимость ремонта (если менять всё): {approxTotal} руб.");
        }
        
        // TODO 3: Показать статистику магазина
        public void ShowStoreStats()
        {
            Console.WriteLine("=== СТАТИСТИКА МАГАЗИНА ===");

            // Общая выручка
            Console.WriteLine($"Общая выручка: {manager.GetTotalRevenue()} руб.");

            // Количество клиентов
            Console.WriteLine($"Количество клиентов: {manager.GetCustomerCount()}");

            // Запчасти с низким остатком
            Console.WriteLine("\nЗапчасти с низким остатком (< 3 шт.):");

            var parts = manager.GetAllParts();
            foreach (var part in parts)
            {
                if (part.StockQuantity < 3)
                {
                    Console.WriteLine(part);
                }
            }
        }

        
        // Готовый метод - главное меню
        public void ShowMainMenu()
        {
            bool running = true;
            
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== МАГАЗИН АВТОЗАПЧАСТЕЙ 'АВТОДЕТАЛЬ' ===");
                Console.WriteLine("1. Поиск запчастей по автомобилю");
                Console.WriteLine("2. Ремонтные комплекты");
                Console.WriteLine("3. Оформить заказ");
                Console.WriteLine("4. Консультация по ремонту");
                Console.WriteLine("5. Статистика магазина");
                Console.WriteLine("6. Поиск клиента");
                Console.WriteLine("7. Выход");
                Console.Write("Выберите: ");
                
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        SearchPartsByCar();
                        break;
                    case "2":
                        ShowRepairKits();
                        break;
                    case "3":
                        ProcessOrder();
                        break;
                    case "4":
                        ProvideRepairConsultation();
                        break;
                    case "5":
                        ShowStoreStats();
                        break;
                    case "6":
                        SearchCustomer();
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
                
                if (running)
                {
                    Console.WriteLine("\nНажмите Enter...");
                    Console.ReadLine();
                }
            }
        }
        
        // Метод поиска клиента
        private void SearchCustomer()
        {
            Console.WriteLine("Поиск клиента:");
            Console.WriteLine("1. По номеру телефона");
            Console.WriteLine("2. По госномеру автомобиля");
            Console.Write("Выберите способ: ");
            
            string choice = Console.ReadLine();
            
            if (choice == "1")
            {
                Console.Write("Введите номер телефона: ");
                string phone = Console.ReadLine();
                Customer customer = manager.FindCustomerByPhone(phone);
                if (customer != null) customer.ShowCustomerInfo();
                else Console.WriteLine("Клиент не найден");
            }
            else if (choice == "2")
            {
                Console.Write("Введите госномер: ");
                string licensePlate = Console.ReadLine();
                Customer customer = manager.FindCustomerByLicensePlate(licensePlate);
                if (customer != null) customer.ShowCustomerInfo();
                else Console.WriteLine("Клиент не найден");
            }
        }
    }
}
