using LinqForXML.model;

namespace LinqForXML.data
{
    public class StoreData
    {
        public Store[] Stores()
        {
            Store[] stores =
            {
                new Store.Builder()
                    .StoreId("024")
                    .NumberOfFlour(4)
                    .MaxWeight(10000)
                    .Build(),
                new Store.Builder()
                    .StoreId("024")
                    .NumberOfFlour(4)
                    .MaxWeight(10000)
                    .Build(),
                new Store.Builder()
                    .StoreId("017")
                    .NumberOfFlour(6)
                    .MaxWeight(12000)
                    .Build()
            };
            return stores;
        }
    }
}