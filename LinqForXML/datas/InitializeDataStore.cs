using LinqForXML.utils;

namespace LinqForXML.datas
{
    public class InitializeDataStore
    {
        public Store[] InitializeDataStores()
        {
            Store[] stores =
            {
                new Store
                {
                    StoreId = "024",
                    NumberOfFlour = 4,
                    MaxWeight = 10000
                },
                new Store
                {
                    StoreId = "024",
                    NumberOfFlour = 4,
                    MaxWeight = 10000
                },
                new Store
                {
                    StoreId = "017",
                    NumberOfFlour = 6,
                    MaxWeight = 12000
                }
            };
            return stores;
        }
    }
}