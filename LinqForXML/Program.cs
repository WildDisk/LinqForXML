using System;
using System.Linq;
using LinqForXML.data;
using LinqForXML.format_answer;
using LinqForXML.model;
using LinqForXML.query;
using LinqForXML.query.department;
using LinqForXML.query.employee;
using LinqForXML.query.product;
using LinqForXML.xml;
using LinqForXML.xml.xdoc;

namespace LinqForXML
{
    internal static class Program
    {
        static void Main()
        {
            Employee[] employees = new EmployeeData().Employees();
            Department[] departments = new DepartmentData().Departments();
            Product[] products = new ProductData().Products();
            Console.WriteLine(
                new FAEmployee(
                    new QrBirthdayEmployee(
                        new QrEmployees(
                            new XmlEmployee(employees)
                        ),
                        new DateTime(1986, 01, 22)
                        // "1981.11.11"
                    ),
                    "Список сотрудников с датой рождения 1986.01.22"
                )
            );
            Console.WriteLine(
                new FAEmployee(
                    new QrSexEmployee(
                        new QrPositionEmployee(
                            new QrEmployees(
                                new XmlEmployee(employees)
                            ),
                            "Начальник отдела"
                        ),
                        "Муж."
                    ),
                    "Список начальников отдела мужского пола"
                )
            );
            Console.WriteLine(
                new FAEmployee(
                    new QrEmployees(
                        new XmlEmployee(employees)
                    ).Fetch().Where(it => Convert.ToDouble(it.Element("salary")?.Value) >= 30000),
                    "Список сотрудников с ЗП от 30000 руб."
                )
            );
            Console.WriteLine(
                new FAEmployee(
                    new QrMoreOrEqual(
                        new XmlEmployee(employees),
                        "salary",
                        30000
                    ),
                    "Список сотрудников с ЗП от 30000 руб."
                )
            );
            Console.WriteLine(
                new FAEmployee(
                    new QrLess(
                        new XmlEmployee(employees),
                        "salary",
                        30000.01
                    ),
                    "Список сотрудников с ЗП до 30000 руб."
                )
            );
            Console.WriteLine(
                new FADepartment(
                    new QrDepartment(
                        new XmlDepartment(departments)
                    ),
                    "Количество мест в отделах"
                )
            );
            Console.WriteLine(
                new FaProduct(
                    new QrOrderBy(
                        new XmlProduct(products),
                        "name"
                    ),
                    "Список продуктов отсортированный по наименованию"
                )
            );
            Console.WriteLine(
                new FaProduct(
                    new QrMoreOrEqual(
                        new QrLessOrEqual(
                            new QrProducts(
                                new XmlProduct(products)
                            ),
                            "weight",
                            500
                        ),
                        "weight",
                        350
                    ),
                    "Продукты с весом от 350 до 500"
                )
            );
            Console.WriteLine(
                new XmlXDocument(
                    new XmlProduct(products),
                    "product.xml",
                    "products"
                ).Create()
            );
        }
    }
}