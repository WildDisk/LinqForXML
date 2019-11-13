namespace LinqForXML.utils
{
    /// <summary>
    /// Описание свойств магазина
    /// Код стеллажа, число ярусов, макс. грузонесущая способность в кг.
    /// </summary>
    public class Store
    {
        public string StoreId { get; set; }
        public int NumberOfFlour { get; set; }
        public int MaxWeight { get; set; }
    }
}