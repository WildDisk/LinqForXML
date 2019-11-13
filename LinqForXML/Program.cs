using System;
using LinqForXML.datas;
using LinqForXML.queries;
using LinqForXML.utils;
using LinqForXML.xmlcreates;

namespace LinqForXML
{
    internal static class Program
    {
        static void Main()
        {
            Console.Title = "Выполнение запросов LINQ к массиву обьектнов";
            
            Product[] itemInStock = new InitializeDataProduct().InitializeDataProducts();
            AcademicDiscipline[] academicDisciplines = new InitializeDataAcademicDiscipline().Disciplines();
            
            Console.WriteLine("******* Результаты запросов LINQ *******");
//            new QueryForGetDataProduct(itemInStock).GetAllProducts();
//            new QueryForGetDataProduct(itemInStock).GetAllNames();
//            new QueryForGetDataProduct(itemInStock).GetProductsOver();
//            new QueryForGetDataProduct(itemInStock).GetAltaiProducts();
//            new QueryForGetDataProduct(itemInStock).GetNameNumb();
//            new QueryForGetDataProduct(itemInStock).GetAvgPrice();
//            new QueryForGetDataProduct(itemInStock).GetSumWeight();
//            new QueryForGetDataProduct(itemInStock).GetSumPrice();
//            new QueryForGetDataProduct(itemInStock).GetNameMaker();
//            new QueryForGetDataProduct(itemInStock).GetProdBaltprom();
            
            new QueryForGetDataAcademicDiscipline(academicDisciplines).DisciplineInSemester(7);
            new QueryForGetDataAcademicDiscipline(academicDisciplines).DisciplineWithControllingForm("Экзамен");
            new QueryForGetDataAcademicDiscipline(academicDisciplines).NumbersOfDisciplineWithCountOfHours(12, 42);
            new QueryForGetDataAcademicDiscipline(academicDisciplines).TeachersNameAndDisciplineNameAtSemester(5);
            new QueryForGetDataAcademicDiscipline(academicDisciplines).TotalHoursForTeachersSubjects("Сидоров Сидор Сидорович");
            new QueryForGetDataAcademicDiscipline(academicDisciplines).AllDisciplinesGroupedBySpecialityId(5);
            new QueryForGetDataAcademicDiscipline(academicDisciplines).DisciplineSemesterSpecialityFaculty();
            
            new XmlCreate().XmlConstruct();
            new XmlCreate(itemInStock).GenerateXml();
        }
    }
}