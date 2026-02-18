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
            
            customers.Add(customer);
            nextCustomerId++;
            return customer;
        }
        
        // TODO 2: Найти клиента по номеру телефона
        public Customer FindCustomerByPhone(string phone)
        {
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
            
            foreach (var part in parts)
            {
                if (!part.IsCompatible(brand, model, year))
                    continue;
                if (category != null && part.Category != category)
                    continue;
                result.Add(part);
            }
            
            return result;
        }
        
        // TODO 3: Найти ремонтные комплекты для автомобиля
        public List<RepairKit> FindKitsForCar(string brand, string model, int year)
        {
            List<RepairKit> result = new List<RepairKit>();
            
            foreach (var kit in repairKits)
            {
                if (kit.IsCompatibleWithCar(brand, model, year))
                    result.Add(kit);
            }
            
            return result;
        }
        
        // TODO 3: Создать номер заказа
        public int GetNextOrderNumber()
        {
            return nextOrderNumber++;
        }
        
        // TODO 3: Зафиксировать продажу
        public void RecordSale(decimal amount)
        {
            totalRevenue += amount;
        }
        
        // Готовые методы для добавления запчастей и комплектов
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
