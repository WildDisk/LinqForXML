namespace LinqForXML.model
{
    /// <summary>
    /// Описание свойств магазина
    /// Код стеллажа, число ярусов, макс. грузонесущая способность в кг.
    /// </summary>
    public class Store
    {
        public string StoreId { get; }
        public int NumberOfFlour { get; }
        public double MaxWeight { get; }

        public Store(string storeId, int numberOfFlour, double maxWeight)
        {
            StoreId = storeId;
            NumberOfFlour = numberOfFlour;
            MaxWeight = maxWeight;
        }
        
        internal class Builder
        {
            private string _storeId;
            private int _numberOfFlour;
            private double _maxWeight;

            public Builder StoreId(string storeId)
            {
                _storeId = storeId;
                return this;
            }

            public Builder NumberOfFlour(int numberOfFlour)
            {
                _numberOfFlour = numberOfFlour;
                return this;
            }

            public Builder MaxWeight(double maxWeight)
            {
                _maxWeight = maxWeight;
                return this;
            }

            public Store Build()
            {
                return new Store(
                    storeId: _storeId,
                    numberOfFlour: _numberOfFlour,
                    maxWeight: _maxWeight
                );
            }
        }

        public override string ToString()
        {
            return $"Store(storeId={StoreId}, numberOfFlour={NumberOfFlour}, maxWeight={MaxWeight})";
        }
    }
}