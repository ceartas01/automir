using System;

namespace AutoPartsStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== МАГАЗИН АВТОЗАПЧАСТЕЙ 'АВТОДЕТАЛЬ' ===\n");
            
            StoreMenu menu = new StoreMenu();
            menu.ShowMainMenu();
            
            Console.WriteLine("\nСпасибо за покупку! Удачи на дорогах!");
            Console.ReadKey();
        }
    }
}