using LinqForXML.model;

namespace LinqForXML.data
{
    public class InitializeDataDepartment
    {
        public Department[] Departments()
        {
            Department[] departments =
            {
                new Department
                {
                    DepartmentId = 9,
                    DepartmentName = "Отдел програмного обеспечения",
                    EmployeePlaces = 9
                },
                new Department
                {
                    DepartmentId = 5,
                    DepartmentName = "Отдел сбыта",
                    EmployeePlaces = 12
                }
            };
            return departments;
        }
    }
}