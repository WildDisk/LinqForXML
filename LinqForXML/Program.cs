using System;
using System.Linq;
using LinqForXML.data;
using LinqForXML.format_answer;
using LinqForXML.model;
using LinqForXML.query;
using LinqForXML.query.employee;
using LinqForXML.xml;

namespace LinqForXML
{
    internal static class Program
    {
        static void Main()
        {
            Console.Title = "Выполнение запросов LINQ к массиву обьектнов";
            #region OldLINQ

            // Product[] itemInStock = new InitializeDataProduct().InitializeDataProducts();
            // AcademicDiscipline[] academicDisciplines = new InitializeDataAcademicDiscipline().Disciplines();
//            XDocument xDocument = XDocument.Load("komUslugi.xml");


            

            
//             #region Работа с запросами LINQ
//
//             Console.WriteLine("******* Результаты запросов LINQ *******");
// //            new QueryForGetDataProduct(itemInStock).GetAllProducts();
// //            new QueryForGetDataProduct(itemInStock).GetAllNames();
// //            new QueryForGetDataProduct(itemInStock).GetProductsOver();
// //            new QueryForGetDataProduct(itemInStock).GetAltaiProducts();
// //            new QueryForGetDataProduct(itemInStock).GetNameNumb();
// //            new QueryForGetDataProduct(itemInStock).GetAvgPrice();
// //            new QueryForGetDataProduct(itemInStock).GetSumWeight();
// //            new QueryForGetDataProduct(itemInStock).GetSumPrice();
// //            new QueryForGetDataProduct(itemInStock).GetNameMaker();
// //            new QueryForGetDataProduct(itemInStock).GetProdBaltprom();
//
//             new QueryForGetDataAcademicDiscipline(academicDisciplines).DisciplineInSemester(7);
//             new QueryForGetDataAcademicDiscipline(academicDisciplines).DisciplineWithControllingForm("Экзамен");
//             new QueryForGetDataAcademicDiscipline(academicDisciplines).NumbersOfDisciplineWithCountOfHours(12, 42);
//             new QueryForGetDataAcademicDiscipline(academicDisciplines).TeachersNameAndDisciplineNameAtSemester(5);
//             new QueryForGetDataAcademicDiscipline(academicDisciplines).TotalHoursForTeachersSubjects("Сидоров Сидор Сидорович");
//             new QueryForGetDataAcademicDiscipline(academicDisciplines).AllDisciplinesGroupedBySpecialityId(5);
//             new QueryForGetDataAcademicDiscipline(academicDisciplines).DisciplineSemesterSpecialityFaculty();
//             #endregion
//
// //            
// //            new XmlCreate().XmlConstruct();
// //            new XmlCreate(itemInStock).GenerateXml();
//
// //            new QueryForParseDataXml(xDocument).GetD();
// //            new QueryForParseDataXml(xDocument).PersonalData();
// //            new QueryForParseDataXml(xDocument).WaterAndElectricity();
// //            new QueryForParseDataXml(xDocument).ApartmentsData();
// //            new QueryForParseDataXml(xDocument).NumApartments();
// //            new QueryForParseDataXml(xDocument).Apartments30M();
//
//             #region Работа с запросами LINQ из XML
//             
//             Console.WriteLine("\n******* Результаты запросов LINQ из XML *******\n");
//             
             // new XmlCreateDepartments(employees).GenerateXml();
             // XDocument xDocumentEmployee = XDocument.Load("employee.xml");
//             
//             new QueryForGetEmployee(xDocumentEmployee).All();
             // new QueryForGetEmployee(xDocumentEmployee).FindEmployeeWithBirthday("1986.01.22");
//             new QueryForGetEmployee(xDocumentEmployee).FindEmployeeWithSexAndPosition("Муж.", "Начальник отдела");
//             new QueryForGetEmployee(xDocumentEmployee).FindEmployeeWithMoreSalary(25000);
//             new QueryForGetEmployee(xDocumentEmployee).ListPositionsWithDepartmentName();
//             new QueryForGetEmployee(xDocumentEmployee).FindEmployeeSmallerSalary(30000);
//             #endregion

            // new XmlCreateDepartments(employees).GenerateXml();
            // XDocument xDocumentEmployee = XDocument.Load("employee.xml");
            #endregion

            Employee[] employees = new EmployeeData().Employees();
            Console.WriteLine(
                new EmployeeFormatAnswer(
                    new QrBirthdayEmployee(
                        new QrEmployees(
                            new XmlEmployee(employees)
                        ),
                        // new DateTime(1986, 01, 22)
                        "1981.11.11"
                    ),
                    "Список сотрудников с датой рождения 1986.01.22"
                )
            );
            Console.WriteLine(
                new EmployeeFormatAnswer(
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
                new EmployeeFormatAnswer(
                    new QrEmployees(
                        new XmlEmployee(employees)
                    ).Fetch().Where(it => Convert.ToDouble(it.Element("salary")?.Value) >= 30000),
                    "Список сотрудников с ЗП от 30000 руб."
                )
            );
            Console.WriteLine(
                new EmployeeFormatAnswer(
                    new QrMore(
                        new XmlEmployee(employees),
                        "salary",
                        29999.99
                    ),
                    "Список сотрудников с ЗП от 30000 руб."
                )
            );
        }
    }
}