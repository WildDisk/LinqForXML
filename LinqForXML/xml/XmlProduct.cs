using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LinqForXML.model;

namespace LinqForXML.xml
{
    public class XmlProduct : IXml
    {
        private readonly Product[] _products;

        public XmlProduct(Product[] products)
        {
            _products = products;
        }
        public IEnumerable<XElement> Create()
        {
            var products = _products.Select(p => 
                new XElement("product",
                    new XAttribute("id", p.Id),
                    new XAttribute("numberInStock", p.NumberInStock),
                    new XElement("name", p.Name),
                    new XElement("manufacturer", p.Manufacturer),
                    new XElement("weight", p.Weight,
                        new XAttribute("unit", "г.")
                    ),
                    new XElement("price", p.Price,
                        new XAttribute("unit", "руб.")
                    )
                )
            );
            XDocument xDocument = new XDocument();
            xDocument.Add(new XElement("products", products));
            xDocument.Save("product.xml");
            return XDocument.Load("product.xml").Descendants("product");
        }
    }
}