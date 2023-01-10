namespace LinqForXML.model
{
    /// <summary>
    /// Описание свойств товара
    /// Наименование, производитель, количество, вес в граммах, цена в рублях, код стиллажа
    /// </summary>
    public class Product
    {
        public string Name { get; }
        public string Manufacturer { get; }
        public int NumberInStock { get; }
        public double Weight { get; }
        public double Price { get; }
        public string StoreId { get; }

        public Product(string name, string manufacturer, int numberInStock, double weight, double price, string storeId)
        {
            Name = name;
            Manufacturer = manufacturer;
            NumberInStock = numberInStock;
            Weight = weight;
            Price = price;
            StoreId = storeId;
        }
        internal class Builder
        {
            private string _name;
            private string _manufacturer;
            private int _numberInStock;
            private double _weight;
            private double _price;
            private string _storeId;
            public Builder Name(string name)
            {
                _name = name;
                return this;
            }

            public Builder Manufacturer(string manufacturer)
            {
                _manufacturer = manufacturer;
                return this;
            }

            public Builder NumberInStock(int numberInStock)
            {
                _numberInStock = numberInStock;
                return this;
            }

            public Builder Weight(double weight)
            {
                _weight = weight;
                return this;
            }

            public Builder Price(double price)
            {
                _price = price;
                return this;
            }

            public Builder StoreId(string storeId)
            {
                _storeId = storeId;
                return this;
            }

            public Product Build()
            {
                return new Product(
                    name: _name,
                    numberInStock: _numberInStock,
                    manufacturer: _manufacturer,
                    weight: _weight,
                    price: _price,
                    storeId: _storeId
                );
            }
        }

        /// <summary>
        /// Переопределение ToString для вывода информации об объектах
        /// </summary>
        /// <returns>string.Format</returns>
        public override string ToString()
        {
            return string.Format(
                $"Наименование: {Name}\n" +
                $"Производитель: {Manufacturer}\n" +
                $"Количество = {NumberInStock} шт.\n" +
                $"Вес = {Weight} гр.\n" +
                $"Цена = {Price:f2} руб.\n" +
                $"Код стеллажа: {StoreId}\n" +
                $"\n"
            );
        }
    }
}