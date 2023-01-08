using LinqForXML.model;

namespace LinqForXML.data
{
    public class ProductData
    {
        public Product[] Products()
        {
            Product[] products =
            {
                new Product.Builder()
                    .Name("Крупа гречневая")
                    .Manufacturer("ООО Алтайпродукт")
                    .NumberInStock(42)
                    .Weight(350)
                    .Price(72.50)
                    .StoreId("024")
                    .Build(),
                new Product.Builder()
                    .Name("Кукуруза консервированная")
                    .Manufacturer("ОАО Балтпром")
                    .NumberInStock(67)
                    .Weight(340)
                    .Price(56.80)
                    .StoreId("017")
                    .Build(),
                new Product.Builder()
                    .Name("Крупа рисовая")
                    .Manufacturer("ЗАО Увелка")
                    .NumberInStock(53)
                    .Weight(350)
                    .Price(42.35)
                    .StoreId("024")
                    .Build(),
                new Product.Builder()
                    .Name("Говядина тушеная")
                    .Manufacturer("ОАО Балтпром")
                    .NumberInStock(30)
                    .Weight(330)
                    .Price(96.00)
                    .StoreId("017")
                    .Build(),
                new Product.Builder()
                    .Name("Макароны")
                    .Manufacturer("ООО Алтайпродукт")
                    .NumberInStock(48)
                    .Weight(500)
                    .Price(56.50)
                    .StoreId("028")
                    .Build()
            };
            return products;
        }
    }
}
