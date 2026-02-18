// TODO:
// 1. Добавить свойство для категории запчасти (двигатель, ходовая, электрика)
// 2. Реализовать проверку корректности данных (цена, срок гарантии)
// 3. Реализовать информативное строковое представление запчасти

namespace AutoPartsStore
{
    public class AutoPart
    {
        public int Id { get; set; }                    // Артикул
        public string Name { get; set; }               // Название
        public string CarBrand { get; set; }           // Марка авто (Toyota, Volkswagen, Lada)
        public string CarModel { get; set; }           // Модель авто
        public int ProductionYear { get; set; }        // Год выпуска авто
        public decimal Price { get; set; }             // Цена
        public int StockQuantity { get; set; }         // Количество на складе
        public int WarrantyMonths { get; set; }        // Гарантия в месяцах
        
        // TODO 1: Добавить свойство Category (категория: двигатель, тормоза, подвеска, электрика, кузов)
        
        public AutoPart(int id, string name, string brand, string model, int year, decimal price, int stock, int warranty, string category)
        {
            Id = id;
            Name = name;
            CarBrand = brand;
            CarModel = model;
            ProductionYear = year;
            
            // TODO 2: Проверить что цена не отрицательная
            // Если цена < 0, установить минимальную цену 100
            
            StockQuantity = stock;
            
            // TODO 2: Проверить что гарантия не отрицательная
            // Если warranty < 0, установить 0
            
            // TODO 1: Сохранить категорию запчасти
        }
        
        public override string ToString()
        {
            // TODO 3: Вернуть строку в формате "Тормозной диск Toyota Corolla 2015 (тормоза) - 3200 руб. (12 мес гарантии)"
            return Name;
        }
        
        // Проверить совместимость с автомобилем
        public bool IsCompatible(string brand, string model, int year)
        {
            return CarBrand == brand && CarModel == model && ProductionYear == year;
        }
        
        // Проверить наличие на складе
        public bool IsInStock(int quantity = 1)
        {
            return StockQuantity >= quantity;
        }
        
        // Продать запчасть (уменьшить остаток)
        public bool Sell(int quantity)
        {
            if (StockQuantity >= quantity)
            {
                StockQuantity -= quantity;
                return true;
            }
            return false;
        }
    }
}