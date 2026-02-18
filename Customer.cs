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
        public string VIN { get; set; }                // VIN-код автомобиля
        
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
            Order order = new Order();
            
            // Установить текущую дату
            order.OrderDate = DateTime.Now;
            
            // Установить начальный статус
            order.Status = "Оформлен";
            
            // Добавить заказ в историю orders
            orders.Add(order);
            
            // Вернуть созданный заказ
            return order;
        }
        
        // TODO 2: Добавить запчасть в заказ
        public bool AddToOrder(Order order, AutoPart part, int quantity, string purpose)
        {
            // Проверить совместимость запчасти с автомобилем клиента (part.IsCompatible)
            if (!part.IsCompatible(CarBrand, CarModel, CarYear))
                return false;
            
            // Проверить наличие на складе (part.IsInStock)
            if (!part.IsInStock(quantity))
                return false;
            
            // Если все условия выполнены:
            //   - Создать OrderItem с указанием назначения
            OrderItem item = new OrderItem
            {
                Part = part,
                Quantity = quantity,
                Purpose = purpose
            };
            
            //   - Добавить в Items заказа
            order.Items.Add(item);
            
            //   - Вернуть true
            return true;
        }
        
        // TODO 3: Рассчитать стоимость заказа
        public decimal CalculateOrderTotal(Order order)
        {
            decimal total = 0;
            
            // Пройти по всем запчастям в заказе
            foreach (var item in order.Items)
            {
                // Суммировать: part.Price * quantity
                total += item.Part.Price * item.Quantity;
            }
            
            return total;
        }
        
        // TODO 1: Обновить данные автомобиля
        public void UpdateCarInfo(string brand, string model, int year, string vin)
        {
            // Обновить свойства CarBrand, CarModel, CarYear, VIN
            CarBrand = brand;
            CarModel = model;
            CarYear = year;
            VIN = vin;
        }
        
        // Показать информацию о клиенте
        public void ShowCustomerInfo()
        {
            Console.WriteLine($"Клиент: {FullName}");
            Console.WriteLine($"Телефон: {Phone}");
            Console.WriteLine($"Автомобиль: {CarBrand} {CarModel} {CarYear} г.");
            Console.WriteLine($"Гос. номер: {LicensePlate}");
            // TODO 1: Вывести VIN-код
            Console.WriteLine($"VIN: {VIN}");
            Console.WriteLine($"Всего заказов: {orders.Count}");
        }
    }
}
