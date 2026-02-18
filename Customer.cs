// TODO:
// 1. Реализовать учет данных автовладельца
// 2. Реализовать оформление заказа на запчасти
// 3. Реализовать историю ремонтов и покупок

using System;
using System.Collections.Generic;

namespace AutoPartsStore
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string CarBrand { get; set; }           // Марка автомобиля клиента
        public string CarModel { get; set; }           // Модель автомобиля
        public int CarYear { get; set; }               // Год выпуска автомобиля
        public string LicensePlate { get; set; }       // Номерной знак
        
        // TODO 1: Добавить свойство VIN (VIN-код автомобиля)
        
        private List<Order> orders = new List<Order>(); // История заказов
        
        public class OrderItem
        {
            public AutoPart Part { get; set; }
            public int Quantity { get; set; }
            public string Purpose { get; set; }        // Для какого ремонта (замена тормозов, ТО и т.д.)
        }
        
        public class Order
        {
            public int OrderNumber { get; set; }
            public DateTime OrderDate { get; set; }
            public List<OrderItem> Items { get; set; } = new List<OrderItem>();
            public decimal TotalAmount { get; set; }
            public string Status { get; set; } = "Оформлен"; // Оформлен, Собран, Выдан
            public DateTime? PickupDate { get; set; }  // Дата выдачи
        }
        
        // TODO 2: Создать новый заказ
        public Order CreateOrder()
        {
            // Создать новый объект Order
            // Установить текущую дату
            // Установить начальный статус
            // Добавить заказ в историю orders
            // Вернуть созданный заказ
            return null;
        }
        
        // TODO 2: Добавить запчасть в заказ
        public bool AddToOrder(Order order, AutoPart part, int quantity, string purpose)
        {
            // Проверить совместимость запчасти с автомобилем клиента (part.IsCompatible)
            // Проверить наличие на складе (part.IsInStock)
            // Если все условия выполнены:
            //   - Создать OrderItem с указанием назначения
            //   - Добавить в Items заказа
            //   - Вернуть true
            // Если условия не выполнены:
            //   - Вернуть false
            return false;
        }
        
        // TODO 3: Рассчитать стоимость заказа
        public decimal CalculateOrderTotal(Order order)
        {
            decimal total = 0;
            
            // Пройти по всем запчастям в заказе
            // Суммировать: part.Price * quantity
            return total;
        }
        
        // TODO 1: Обновить данные автомобиля
        public void UpdateCarInfo(string brand, string model, int year, string vin)
        {
            // Обновить свойства CarBrand, CarModel, CarYear, VIN
        }
        
        // Показать информацию о клиенте
        public void ShowCustomerInfo()
        {
            Console.WriteLine($"Клиент: {FullName}");
            Console.WriteLine($"Телефон: {Phone}");
            Console.WriteLine($"Автомобиль: {CarBrand} {CarModel} {CarYear} г.");
            Console.WriteLine($"Гос. номер: {LicensePlate}");
            // TODO 1: Вывести VIN-код
            Console.WriteLine($"Всего заказов: {orders.Count}");
        }
    }
}