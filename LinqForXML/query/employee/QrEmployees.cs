using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LinqForXML.xml;

namespace LinqForXML.query.employee
{
    public class QrEmployees : IQuery
    {
        private readonly IEnumerable<XElement> _xdEmployees;

        public QrEmployees(IXml xml)
        {
            _xdEmployees = xml.Create();
        }

        public QrEmployees(XDocument document)
        {
            _xdEmployees = document.Descendants("employee");
        }

        public QrEmployees(IEnumerable<XElement> xdEmployees)
        {
            _xdEmployees = xdEmployees;
        }

        public IEnumerable<XElement> Fetch()
        {
            return _xdEmployees.Select(employee => employee);
        }

        public override string ToString()
        {
            var str = "";
            Fetch().ToList().ForEach(it => str += $"{it}{Environment.NewLine}");
            return str;
        }
    }
}