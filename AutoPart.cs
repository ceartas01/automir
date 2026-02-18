namespace AutoPartsStore
{
    public class AutoPart
    {
        public int Id { get; set; }                    
        public string Name { get; set; }               
        public string CarBrand { get; set; }           
        public string CarModel { get; set; }           
        public int ProductionYear { get; set; }        
        public decimal Price { get; set; }             
        public int StockQuantity { get; set; }         
        public int WarrantyMonths { get; set; }        

        // TODO 1: Добавлено свойство Category
        public string Category { get; set; }          
        
        public AutoPart(int id, string name, string brand, string model, int year, decimal price, int stock, int warranty, string category)
        {
            Id = id;
            Name = name;
            CarBrand = brand;
            CarModel = model;
            ProductionYear = year;
            
            StockQuantity = stock;
            
            // TODO 1: Сохранение категории
            Category = category;
        }
        
        public override string ToString()
        {
            return Name;
        }
        
        public bool IsCompatible(string brand, string model, int year)
        {
            return CarBrand == brand && CarModel == model && ProductionYear == year;
        }
        
        public bool IsInStock(int quantity = 1)
        {
            return StockQuantity >= quantity;
        }
        
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
