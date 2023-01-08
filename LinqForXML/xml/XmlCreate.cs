using System;
using System.Linq;
using System.Xml.Linq;
using LinqForXML.model;

namespace LinqForXML.xmlcreates
{
    public class XmlCreate
    {
        private readonly Product[] _products;

        internal XmlCreate() {}

        internal XmlCreate(Product[] products)
        {
            _products = products;
        }
        public void XmlConstruct()
        {
            XDocument xDocument =
                new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment("Данные о предоставляемых услугах и их оплате"),
                    new XElement("комунальные_услуги",
                        new XElement("дом",
                            new XAttribute("код", "h18"),
                            new XElement("адрес",
                                new XElement("улица", "Волгоградская"),
                                new XElement("номер", "8")
                            ),
                            new XElement("квартира",
                                new XAttribute("код", "a238"),
                                new XAttribute("номер", "57"),
                                new XElement("площадь", "28"),
                                new XElement("жилец",
                                    new XAttribute("код", "с11568"),
                                    new XElement("фио", "Костенко Игорь Сергеевич"),
                                    new XElement("дата_рождения", "10.11.1978")
                                ),
                                new XElement("показания_приборов",
                                    new XAttribute("дата", "02.05.2013"),
                                    new XElement("холодная_вода", "19.04",
                                        new XAttribute("ед_изм", "м3")
                                    ),
                                    new XElement("горячая_вода", "6.89",
                                        new XAttribute("ед_изм", "м3")
                                    ),
                                    new XElement("эл_энергия", "39.27",
                                        new XAttribute("ед_изм", "м3")
                                    )
                                ),
                                new XElement("плата",
                                    new XAttribute("дата", "04.05.2013"),
                                    new XElement("всего", "1896.45"),
                                    new XElement("пеня", "0")
                                )
                            )
                        )
                    )
                );
            xDocument.Save("komUslugi.xml");
        }

        /// <summary>
        /// Пример генерации xml по запросу
        /// </summary>
        public void GenerateXml()
        {
            Random random = new Random();
            var xmlData = from p in _products
                select
                    new XElement("product",
                        new XAttribute("id", random.Next()),
                        new XAttribute("numberInStock", p.NumberInStock),
                        new XElement("name", p.Name),
                        new XElement("make", p.Manufacturer),
                        new XElement("weight", p.Weight,
                            new XAttribute("unit", "г.")
                        ),
                        new XElement("price", p.Price,
                            new XAttribute("unit", "руб.")
                        )
                    );
            //Корневой элемент
            XElement rootElement = new XElement("productStock", xmlData);
            //Документ xml
            XDocument xDocument = new XDocument();
            xDocument.Add(rootElement);
            xDocument.Save("product.xml");
        }
    }
}