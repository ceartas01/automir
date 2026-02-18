// TODO:
// 1. Реализовать создание комплектов для типовых ремонтов
// 2. Реализовать расчет стоимости комплекта
// 3. Реализовать проверку совместимости комплекта с автомобилем

using System;
using System.Collections.Generic;

namespace AutoPartsStore
{
    public class RepairKit
    {
        public int Id { get; set; }
        public string Name { get; set; }               // Название комплекта
        public string RepairType { get; set; }         // Тип ремонта (ТО, тормоза, подвеска, двигатель)
        public string CarBrand { get; set; }           // Для какой марки авто
        public string CarModel { get; set; }           // Для какой модели
        public int ModelYearsFrom { get; set; }        // Годы выпуска от
        public int ModelYearsTo { get; set; }          // Годы выпуска до
        
        private Dictionary<AutoPart, int> parts = new Dictionary<AutoPart, int>(); // Запчасти и их количество
        
        // TODO 1: Добавить свойство Difficulty (сложность ремонта: простая, средняя, сложная)
        public string Difficulty { get; set; }         // Сложность ремонта
        
        public RepairKit(int id, string name, string repairType, string brand, string model, int yearFrom, int yearTo, string difficulty)
        {
            Id = id;
            Name = name;
            RepairType = repairType;
            CarBrand = brand;
            CarModel = model;
            ModelYearsFrom = yearFrom;
            ModelYearsTo = yearTo;
            
            // TODO 1: Сохранить сложность ремонта
            Difficulty = difficulty;
        }
        
        // TODO 2: Добавить запчасть в комплект
        public void AddPart(AutoPart part, int quantity)
        {
            // Добавить запчасть в словарь parts
            // Если запчасть уже есть - увеличить количество
            if (parts.ContainsKey(part))
            {
                parts[part] += quantity;
            }
            else
            {
                parts[part] = quantity;
            }
        }
        
        // TODO 2: Рассчитать стоимость комплекта
        public decimal CalculateKitPrice()
        {
            decimal total = 0;
            
            // Пройти по всем запчастям в комплекте
            foreach (var item in parts)
            {
                // Суммировать: part.Price * quantity
                total += item.Key.Price * item.Value;
            }
            
            return total;
        }
        
        // TODO 2: Рассчитать стоимость комплекта со скидкой
        public decimal CalculateKitPriceWithDiscount(decimal discountPercent)
        {
            decimal basePrice = CalculateKitPrice();
            return basePrice * (100 - discountPercent) / 100;
        }
        
        // TODO 3: Проверить совместимость с автомобилем
        public bool IsCompatibleWithCar(string brand, string model, int year)
        {
            // Проверить что марка и модель совпадают
            // Проверить что год выпуска в диапазоне ModelYearsFrom - ModelYearsTo
            return false;
        }
        
        // TODO 3: Проверить доступность всех запчастей комплекта
        public bool IsKitAvailable()
        {
            // Проверить для каждой запчасти в комплекте:
            // part.IsInStock(quantity)
            // Вернуть true только если ВСЕ запчасти в наличии
            foreach (var item in parts)
            {
                if (!item.Key.IsInStock(item.Value))
                    return false;
            }
            return true;
        }
        
        // Показать состав комплекта
        public void ShowKitComposition()
        {
            Console.WriteLine($"=== КОМПЛЕКТ: {Name} ===");
            Console.WriteLine($"Тип ремонта: {RepairType}");
            Console.WriteLine($"Для авто: {CarBrand} {CarModel} ({ModelYearsFrom}-{ModelYearsTo})");
            
            Console.WriteLine("\nСостав комплекта:");
            foreach (var item in parts)
            {
                Console.WriteLine($"  {item.Key.Name} x{item.Value} - {item.Key.Price * item.Value} руб.");
            }
            
            Console.WriteLine($"\nОбщая стоимость: {CalculateKitPrice()} руб.");
            Console.WriteLine($"Доступность: {(IsKitAvailable() ? "В наличии" : "Недостаточно запчастей")}");
        }
    }
}
