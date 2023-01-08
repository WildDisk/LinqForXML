using System;
using System.Linq;
using LinqForXML.data;
using LinqForXML.model;

namespace LinqForXML.queries
{
    /// <summary>
    /// Описание методов для получение данных по товарам
    /// </summary>
    public class QueryForGetDataProduct
    {
        private readonly Product[] _product;

        internal QueryForGetDataProduct(Product[] product)
        {
            _product = product;
        }

        /// <summary>
        /// Получение всех данных о товарах
        /// </summary>
        public void GetAllProducts()
        {
            Console.WriteLine("\n1. Все данные о товарах на складе: ");
            if (_product != null)
            {
                var all = _product.Select(product => product);
                foreach (var a in all)
                {
                    Console.WriteLine(a.ToString());
                }
            }
        }

        /// <summary>
        /// Получение всех наименований товаров
        /// </summary>
        public void GetAllNames()
        {
            Console.WriteLine("\n2. Все наименования товаров на складе (по алфавиту): ");
            if (_product != null)
            {
                var names = _product
                    .OrderBy(product => product.Name)
                    .Select(product => product.Name);
                foreach (var n in names)
                {
                    Console.WriteLine($"- {n}");
                }
            }
        }

        /// <summary>
        /// Получение товаров которых больше 50 едениц на складе
        /// </summary>
        public void GetProductsOver()
        {
            Console.WriteLine("\n3. Все товары с количеством более 50: ");
            if (_product != null)
            {
                var overStock = _product.Where(product => product.NumberInStock > 25);
                foreach (var os in overStock)
                {
                    Console.WriteLine(os.ToString());
                }
            }
        }

        /// <summary>
        /// Получение товаров марки Алтайпродукт с ценой менее 80 рублей
        /// </summary>
        public void GetAltaiProducts()
        {
            Console.WriteLine("\n4. Все товары Алтай продукт с ценой менее 80 руб.: ");
            if (_product != null)
            {
                var altaiNames = _product
                    .Where(product => product.Manufacturer == "ООО Алтайпродукт" && product.Price < 80)
                    .Select(product => product.Name);
                foreach (var an in altaiNames)
                {
                    Console.WriteLine($"- {an}");
                }
            }
        }

        /// <summary>
        /// Количество товаров с весом от 250 до 500 гр.
        /// </summary>
        public void GetNumProducts()
        {
            Console.WriteLine("\n5. Число наименований товаров с весом от 250 до 500 гр.");
            if (_product != null)
            {
                var nameProduct = _product
                    .Where(product => product.Weight > 250 && product.Weight < 500)
                    .Select(product => product.Name);
                var numProducts = nameProduct.Count();
                Console.WriteLine($"Всего {numProducts} наименований.");
            }
        }

        /// <summary>
        /// Получение наименований и количества товаров (по убыванию)
        /// </summary>
        public void GetNameNumb()
        {
            Console.WriteLine("\n6. Наименование и количество товара (по убыванию): ");
            if (_product != null)
            {
                var nameNumb = _product.OrderByDescending(product => product.NumberInStock);
                foreach (var nn in nameNumb)
                {
                    Console.WriteLine($"- {nn.Name}, {nn.NumberInStock} шт.;");
                }
            }
        }

        /// <summary>
        /// Получение наибольшей, средней и наименьшей цен на товары Алтайпродукт
        /// </summary>
        public void GetAvgPrice()
        {
            Console.WriteLine("\n7. Средняя, наибольшая и наименьшая цены товаров Алтайпродукт: ");
            if (_product != null)
            {
                var prAltaiPrice = _product
                    .Where(product => product.Manufacturer == "ООО Алтайпродукт")
                    .Select(product => product.Price);
                var altaiPrice = prAltaiPrice.ToList();
                Console.WriteLine(
                    $"- наименьшая цена: {altaiPrice.Min():f2} руб.;\n" +
                    $"- средняя цена: {altaiPrice.Average():f2} руб.;\n" +
                    $"- наибольшая цена: {altaiPrice.Max():f2} руб."
                );
            }
        }

        /// <summary>
        /// Общий вес по товарам
        /// </summary>
        public void GetSumWeight()
        {
            Console.WriteLine("\n8. Суммарный вес всех товаров: ");
            if (_product != null)
            {
                var all = _product.Select(product => product);
                double sumWeight = 0;
                foreach (var a in all)
                {
                    sumWeight += a.NumberInStock * a.Weight;
                }

                Console.WriteLine($"Всего {sumWeight / 1000:f2} кг.");
            }
        }

        /// <summary>
        /// Общая стоимость товаров каждого наименования
        /// </summary>
        public void GetSumPrice()
        {
            Console.WriteLine("\n9. Общая стоимость товаров каждого наименования: ");
            var all = _product.OrderBy(product => product.Name);
            foreach (var a in all)
            {
                Console.WriteLine($"- {a.Name}, {a.NumberInStock * a.Price:f2} руб.");
            }
        }

        /// <summary>
        /// Получение наименований товаров, сгруппированных по производителям
        /// </summary>
        public void GetNameMaker()
        {
            Console.WriteLine("\n10. Наименования товаров, сгруппированные по производителям: ");
            var groups = _product.GroupBy(product => product.Manufacturer);
            foreach (var group in groups)
            {
                Console.WriteLine($"Товары фирмы {group.Key}: ");
                foreach (var product in group)
                {
                    Console.WriteLine($"- {product.Name}");
                }
            }
        }

        public void GetProdBaltprom()
        {
            Store[] stores = new InitializeDataStore().InitializeDataStores();
            Console.WriteLine("\n11. Наименования и количество товаров фирм ОАО Балтпром\n" +
                              "или ЗАО Увелка с указанием данных по стелажам, на которых они хранятся: ");
            var result = _product
                .Where(product => product.Manufacturer == "ОАО Балтпром" || product.Manufacturer == "ЗАО Увелка")
                .Join(stores, product => product.StoreId, store => store.StoreId,
                    (product, store) => new
                    {
                        name = product.Name,
                        numb = product.NumberInStock,
                        stId = product.StoreId,
                        numF = store.NumberOfFlour,
                        maxW = store.MaxWeight
                    });
            Console.WriteLine(
                $"|{"Наименование",25}" +
                $"|{"Количество",10}" +
                $"|{"Код стелажа",10}" +
                $"|{"Число ярусов",12}" +
                $"|{"Макс. груз, кг",15}|"
            );
            foreach (var r in result)
            {
                Console.WriteLine(
                    $"|{r.name,25}" +
                    $"|{r.numb,10}" +
                    $"|{r.stId,10}" +
                    $"|{r.numF,12}" +
                    $"|{r.maxW,15}|"
                );
            }
        }
    }
}