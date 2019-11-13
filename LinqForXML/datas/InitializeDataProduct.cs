using LinqForXML.utils;

namespace LinqForXML.datas
{
    public class InitializeDataProduct
    {
        public Product[] InitializeDataProducts()
        {
            Product[] products =
            {
                new Product
                {
                    Name = "Крупа гречневая",
                    ProducedBy = "ООО Алтайпродукт",
                    NumberInStock = 42,
                    Weight = 350,
                    Price = 72.50,
                    StoreId = "024"
                },
                new Product
                {
                    Name = "Кукуруза консервированная",
                    ProducedBy = "ОАО Балтпром",
                    NumberInStock = 67,
                    Weight = 340,
                    Price = 56.80,
                    StoreId = "017"
                },
                new Product
                {
                    Name = "Крупа рисовая",
                    ProducedBy = "ЗАО Увелка",
                    NumberInStock = 53,
                    Weight = 350,
                    Price = 42.35,
                    StoreId = "024"
                },
                new Product
                {
                    Name = "Говядина тушеная",
                    ProducedBy = "ОАО Балтпром",
                    NumberInStock = 30,
                    Weight = 330,
                    Price = 96.00,
                    StoreId = "017"
                },
                new Product
                {
                    Name = "Макароны",
                    ProducedBy = "ООО Алтайпродукт",
                    NumberInStock = 48,
                    Weight = 500,
                    Price = 56.50,
                    StoreId = "028"
                }
            };
            return products;
        }
    }
}
