using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LinqForXML.query;
using LinqForXML.xml;

namespace LinqForXML.format_answer
{
    public class DepartmentFormatAnswer
    {
        private readonly IEnumerable<XElement> _xElements;
        private readonly string _comment;

        public DepartmentFormatAnswer(IQuery query, string comment)
        {
            _xElements = query.Fetch();
            _comment = comment;
        }
        
        public DepartmentFormatAnswer(IXml xml, string comment)
        {
            _xElements = xml.Create();
            _comment = comment;
        }
        
        public DepartmentFormatAnswer(IEnumerable<XElement> elements, string comment)
        {
            _xElements = elements;
            _comment = comment;
        }

        public override string ToString()
        {
            var str = $"***** {_comment} *****{Environment.NewLine}";
            for (int i = 0; i < 94; i++)
            {
                str += "-";
            }
            str += Environment.NewLine;
            str += $"|{"Должность",25}" +
                   $"|{"Название отдела",40}" +
                   $"|{"Количество мест в отделе",25}" +
                   $"|{Environment.NewLine}";
            for (int i = 0; i < 94; i++)
            {
                str += "-";
            }
            str += Environment.NewLine;
            _xElements
                .ToList()
                .ForEach(it =>
                {
                    str += $"|{it.Attribute("id")?.Value, 25}" +
                           $"|{it.Element("department_name")?.Value, 40}" +
                           $"|{it.Element("employee_places")?.Value, 25}" +
                           $"|{Environment.NewLine}";
                });
            for (int i = 0; i < 94; i++)
            {
                str += "-";
            }
            str += Environment.NewLine;
            return str;
        }
    }
}