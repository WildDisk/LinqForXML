﻿using System;
using System.Xml.Linq;
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
//            XDocument xDocument = XDocument.Load("komUslugi.xml");
            Employee[] employees = new InitializeDataEmployee().Employees();

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

//            new QueryForGetDataAcademicDiscipline(academicDisciplines).DisciplineInSemester(7);
//            new QueryForGetDataAcademicDiscipline(academicDisciplines).DisciplineWithControllingForm("Экзамен");
//            new QueryForGetDataAcademicDiscipline(academicDisciplines).NumbersOfDisciplineWithCountOfHours(12, 42);
//            new QueryForGetDataAcademicDiscipline(academicDisciplines).TeachersNameAndDisciplineNameAtSemester(5);
//            new QueryForGetDataAcademicDiscipline(academicDisciplines).TotalHoursForTeachersSubjects("Сидоров Сидор Сидорович");
//            new QueryForGetDataAcademicDiscipline(academicDisciplines).AllDisciplinesGroupedBySpecialityId(5);
//            new QueryForGetDataAcademicDiscipline(academicDisciplines).DisciplineSemesterSpecialityFaculty();
//            
//            new XmlCreate().XmlConstruct();
//            new XmlCreate(itemInStock).GenerateXml();

//            new QueryForParseDataXml(xDocument).GetD();
//            new QueryForParseDataXml(xDocument).PersonalData();
//            new QueryForParseDataXml(xDocument).WaterAndElectricity();
//            new QueryForParseDataXml(xDocument).ApartmentsData();
//            new QueryForParseDataXml(xDocument).NumApartments();
//            new QueryForParseDataXml(xDocument).Apartments30M();
            new XmlCreateDepartments(employees).GenerateXml();
            XDocument xDocumentEmployee = XDocument.Load("employee.xml");
            new QueryForGetEmployee(xDocumentEmployee).All();
            new QueryForGetEmployee(xDocumentEmployee).FindEmployeeWithBirthday("1986.01.22");
            new QueryForGetEmployee(xDocumentEmployee).FindEmployeeWithSexAndPosition("Муж.", "Начальник отдела");
            new QueryForGetEmployee(xDocumentEmployee).FindEmployeeWithMoreSalary(25000);
            new QueryForGetEmployee(xDocumentEmployee).ListPositionsWithDepartmentName();
        }
    }
}