using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LinqForXML.xml;

namespace LinqForXML.query.department
{
    public class QrDepartment : IQuery
    {
        private readonly IEnumerable<XElement> _xdDepartment;
        
        public QrDepartment(IXml xml)
        {
            _xdDepartment = xml.Create();
        }

        public QrDepartment(XDocument document)
        {
            _xdDepartment = document.Descendants("department");
        }

        public QrDepartment(IEnumerable<XElement> xdEmployees)
        {
            _xdDepartment = xdEmployees;
        }
        public IEnumerable<XElement> Fetch()
        {
            return _xdDepartment;
        }

        public override string ToString()
        {
            var str = "";
            Fetch().ToList().ForEach(it => str += $"{it}{Environment.NewLine}");
            return str;
        }
    }
}