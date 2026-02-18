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
            // 2. Запросить модель
            // 3. Запросить год выпуска
            // 4. Найти запчасти через manager.FindPartsForCar()
            // 5. Сгруппировать найденные запчасти по категориям
            // 6. Вывести результат поиска
        }
        
        // TODO 1: Показать ремонтные комплекты
        public void ShowRepairKits()
        {
            Console.WriteLine("=== РЕМОНТНЫЕ КОМПЛЕКТЫ ===");
            
            // Получить все комплекты через manager.GetAllRepairKits()
            // Сгруппировать комплекты по типу ремонта
            // Для каждого комплекта вызвать ShowKitComposition()
        }
        
        // TODO 2: Оформить заказ на запчасти
        public void ProcessOrder()
        {
            Console.WriteLine("=== ОФОРМЛЕНИЕ ЗАКАЗА НА ЗАПЧАСТИ ===");
            
            // 1. Найти клиента по телефону или госномеру
            // 2. Если клиент не найден - зарегистрировать нового
            // 3. Спросить: покупать отдельные запчасти или ремонтный комплект
            // 4. Если отдельные запчасти:
            //    - Найти запчасти для автомобиля клиента
            //    - В цикле добавлять запчасти в заказ с указанием назначения
            // 5. Если ремонтный комплект:
            //    - Найти комплекты для автомобиля клиента
            //    - Выбрать комплект
            //    - Проверить совместимость и доступность
            //    - Добавить все запчасти из комплекта в заказ
            // 6. Рассчитать стоимость заказа
            // 7. Зафиксировать продажу через manager.RecordSale()
            // 8. Обновить остатки запчастей на складе
            // 9. Выдать номер заказа и дату готовности
        }
        
        // TODO 3: Консультация по ремонту
        public void ProvideRepairConsultation()
        {
            Console.WriteLine("=== КОНСУЛЬТАЦИЯ ПО РЕМОНТУ ===");
            
            // 1. Запросить данные автомобиля (марка, модель, год)
            // 2. Запросить тип проблемы (стук, течь, не заводится и т.д.)
            // 3. На основе проблемы предложить возможные ремонтные комплекты
            // 4. Показать необходимые запчасти
            // 5. Предложить альтернативные варианты (оригинал/аналог)
            // 6. Рассчитать примерную стоимость ремонта
        }
        
        // TODO 3: Показать статистику магазина
        public void ShowStoreStats()
        {
            Console.WriteLine("=== СТАТИСТИКА МАГАЗИНА ===");
            
            // Вывести общую выручку через manager.GetTotalRevenue()
            // Вывести количество зарегистрированных клиентов
            // Вывести самые популярные марки автомобилей
            // Вывести самые продаваемые категории запчастей
            // Вывести запчасти с низким остатком на складе (< 3 шт.)
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