// TODO:
// 1. Реализовать регистрацию новых клиентов-автовладельцев
// 2. Реализовать поиск клиента по номеру телефона или госномеру
// 3. Реализовать подбор запчастей по автомобилю

using System;
using System.Collections.Generic;

namespace AutoPartsStore
{
    public class StoreManager
    {
        private List<Customer> customers = new List<Customer>();
        private List<AutoPart> parts = new List<AutoPart>();
        private List<RepairKit> repairKits = new List<RepairKit>();
        
        private int nextCustomerId = 1;
        private int nextOrderNumber = 1000;
        private decimal totalRevenue = 0;
        
        // TODO 1: Зарегистрировать нового клиента
        public Customer RegisterCustomer(string fullName, string phone, string brand, string model, int year, string licensePlate, string vin)
        {
            // Создать нового клиента с уникальным ID
            Customer customer = new Customer
            {
                Id = nextCustomerId,
                FullName = fullName,
                Phone = phone,
                CarBrand = brand,
                CarModel = model,
                CarYear = year,
                LicensePlate = licensePlate,
                VIN = vin
            };
            
            // Добавить клиента в список customers
            customers.Add(customer);
            
            // Увеличить nextCustomerId
            nextCustomerId++;
            
            // Вернуть созданного клиента
            return customer;
        }
        
        // TODO 2: Найти клиента по номеру телефона
        public Customer FindCustomerByPhone(string phone)
        {
            // Пройти по всем клиентам в списке customers
            // Если телефон совпадает - вернуть клиента
            // Если не найден - вернуть null
            foreach (var customer in customers)
            {
                if (customer.Phone == phone)
                    return customer;
            }
            return null;
        }
        
        // TODO 2: Найти клиента по госномеру
        public Customer FindCustomerByLicensePlate(string licensePlate)
        {
            // Пройти по всем клиентам в списке customers
            // Если госномер совпадает - вернуть клиента
            // Если не найден - вернуть null
            foreach (var customer in customers)
            {
                if (customer.LicensePlate == licensePlate)
                    return customer;
            }
            return null;
        }
        
        // TODO 3: Найти запчасти для автомобиля
        public List<AutoPart> FindPartsForCar(string brand, string model, int year, string category = null)
        {
            List<AutoPart> result = new List<AutoPart>();
            
            // Пройти по всем запчастям
            foreach (var part in parts)
            {
                // Проверить совместимость с автомобилем (IsCompatible)
                if (!part.IsCompatible(brand, model, year))
                    continue;
                
                // Если категория указана - проверить соответствие
                if (category != null && part.Category != category)
                    continue;
                
                // Добавить подходящие запчасти в результат
                result.Add(part);
            }
            
            return result;
        }
        
        // TODO 3: Найти ремонтные комплекты для автомобиля
        public List<RepairKit> FindKitsForCar(string brand, string model, int year)
        {
            List<RepairKit> result = new List<RepairKit>();
            
            // Пройти по всем ремонтным комплектам
            foreach (var kit in repairKits)
            {
                // Проверить совместимость с автомобилем (IsCompatibleWithCar)
                if (kit.IsCompatibleWithCar(brand, model, year))
                {
                    // Добавить подходящие комплекты в результат
                    result.Add(kit);
                }
            }
            
            return result;
        }
        
        // TODO 3: Создать номер заказа
        public int GetNextOrderNumber()
        {
            // Вернуть nextOrderNumber и увеличить его на 1
            return nextOrderNumber++;
        }
        
        // TODO 3: Зафиксировать продажу
        public void RecordSale(decimal amount)
        {
            // Увеличить totalRevenue на amount
            totalRevenue += amount;
        }
        
        // Готовые методы:
        public void AddPart(AutoPart part)
        {
            parts.Add(part);
        }
        
        public void AddRepairKit(RepairKit kit)
        {
            repairKits.Add(kit);
        }
        
        public List<AutoPart> GetAllParts()
        {
            return parts;
        }
        
        public List<RepairKit> GetAllRepairKits()
        {
            return repairKits;
        }
        
        public decimal GetTotalRevenue()
        {
            return totalRevenue;
        }
        
        public int GetCustomerCount()
        {
            return customers.Count;
        }
    }
}
