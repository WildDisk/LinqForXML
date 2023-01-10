using System;
using System.Xml.Linq;
using LinqForXML.data;
using LinqForXML.model;
using LinqForXML.query.old;
using LinqForXML.xml.old;

namespace LinqForXML
{
    internal static class ProgramOldVersion
    {
        static void MainOld()
        {
            Product[] itemInStock = new ProductData().Products(); // new InitializeDataProduct().InitializeDataProducts();
            AcademicDiscipline[] academicDisciplines = new AcademicDisciplineData().Disciplines();
            XDocument xDocument = XDocument.Load("komUslugi.xml");


            #region Работа с запросами LINQ

            Console.WriteLine("******* Результаты запросов LINQ *******");
            new QueryForGetDataProduct(itemInStock).GetAllProducts();
            new QueryForGetDataProduct(itemInStock).GetAllNames();
            new QueryForGetDataProduct(itemInStock).GetProductsOver();
            new QueryForGetDataProduct(itemInStock).GetAltaiProducts();
            new QueryForGetDataProduct(itemInStock).GetNameNumb();
            new QueryForGetDataProduct(itemInStock).GetAvgPrice();
            new QueryForGetDataProduct(itemInStock).GetSumWeight();
            new QueryForGetDataProduct(itemInStock).GetSumPrice();
            new QueryForGetDataProduct(itemInStock).GetNameMaker();
            new QueryForGetDataProduct(itemInStock).GetProdBaltprom();

            new QueryForGetDataAcademicDiscipline(academicDisciplines).DisciplineInSemester(7);
            new QueryForGetDataAcademicDiscipline(academicDisciplines).DisciplineWithControllingForm("Экзамен");
            new QueryForGetDataAcademicDiscipline(academicDisciplines).NumbersOfDisciplineWithCountOfHours(12, 42);
            new QueryForGetDataAcademicDiscipline(academicDisciplines).TeachersNameAndDisciplineNameAtSemester(5);
            new QueryForGetDataAcademicDiscipline(academicDisciplines).TotalHoursForTeachersSubjects(
                "Сидоров Сидор Сидорович");
            new QueryForGetDataAcademicDiscipline(academicDisciplines).AllDisciplinesGroupedBySpecialityId(5);
            new QueryForGetDataAcademicDiscipline(academicDisciplines).DisciplineSemesterSpecialityFaculty();

            #endregion

//            
            new XmlCreate().XmlConstruct();
            new XmlCreate(itemInStock).GenerateXml();

            new QueryForParseDataXml(xDocument).GetD();
            new QueryForParseDataXml(xDocument).PersonalData();
            new QueryForParseDataXml(xDocument).WaterAndElectricity();
            new QueryForParseDataXml(xDocument).ApartmentsData();
            new QueryForParseDataXml(xDocument).NumApartments();
            new QueryForParseDataXml(xDocument).Apartments30M();

            #region Работа с запросами LINQ из XML

            Console.WriteLine("\n******* Результаты запросов LINQ из XML *******\n");

            new XmlCreateDepartments(new EmployeeData().Employees()).GenerateXml();
            XDocument xDocumentEmployee = XDocument.Load("employee.xml");

            new QueryForGetEmployee(xDocumentEmployee).All();
            new QueryForGetEmployee(xDocumentEmployee).FindEmployeeWithBirthday("1986.01.22");
            new QueryForGetEmployee(xDocumentEmployee).FindEmployeeWithSexAndPosition("Муж.", "Начальник отдела");
            new QueryForGetEmployee(xDocumentEmployee).FindEmployeeWithMoreSalary(25000);
            new QueryForGetEmployee(xDocumentEmployee).ListPositionsWithDepartmentName();
            new QueryForGetEmployee(xDocumentEmployee).FindEmployeeSmallerSalary(30000);

            #endregion
        }
    }
}