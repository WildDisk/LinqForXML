namespace LinqForXML.model
{
    /// <summary>
    /// Описание свойств товара
    /// Наименование, производитель, количество, вес в граммах, цена в рублях, код стиллажа
    /// </summary>
    public class Product
    {
        public string Name { get; set; }
        public string ProducedBy { get; set; }
        public int NumberInStock { get; set; }
        public int Weight { get; set; }
        public double Price { get; set; }
        public string StoreId { get; set; }

        /// <summary>
        /// Переопределение ToString для вывода информации об объектах
        /// </summary>
        /// <returns>string.Format</returns>
        public override string ToString()
        {
            return string.Format(
                $"Наименование: {Name}\n" +
                $"Производитель: {ProducedBy}\n" +
                $"Количество = {NumberInStock} шт.\n" +
                $"Вес = {Weight} гр.\n" +
                $"Цена = {Price:f2} руб.\n" +
                $"Код стеллажа: {StoreId}\n" +
                $"\n"
            );
        }
    }
}