using System;
using System.Linq;
using LinqForXML.query;

namespace LinqForXML.format_answer
{
    public class EmployeeFormatAnswer
    {
        private readonly IQuery _query;
        private readonly string _comment;
        public EmployeeFormatAnswer(IQuery query, string comment)
        {
            _query = query;
            _comment = comment;
        }
        
        public override string ToString()
        {
            try
            {
                var str = $"***** {_comment} *****{Environment.NewLine}";
                _query.Fetch()
                    .ToList()
                    .ForEach(it =>
                    {
                        str += "- " +
                               $"{it.Element("personal")?.Element("last_name")?.Value} " +
                               $"{it.Element("personal")?.Element("first_name")?.Value} " +
                               $"{it.Element("personal")?.Element("patronymic")?.Value} " +
                               $"{it.Element("personal")?.Element("sex")?.Value} " +
                               $"{it.Element("birthday")?.Value} " +
                               $"{it.Element("salary")?.Value} " +
                               $"{it.Element("salary")?.Attribute("unit")?.Value} " +
                               $"{it.Element("department")?.Element("position")?.Value} " +
                               $"{Environment.NewLine}";
                    });
                return str;
            }
            catch (ArgumentException e)
            {
                return $"{e.Message}{Environment.NewLine}{e.StackTrace}";
            }
        }
    }
}