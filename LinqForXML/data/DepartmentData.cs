using LinqForXML.model;

namespace LinqForXML.data
{
    public class DepartmentData
    {
        public Department[] Departments()
        {
            Department[] departments =
            {
                new Department.Builder()
                    .DepartmentId(9)
                    .DepartmentName("Отдел програмного обеспечения")
                    .EmployeePlaces(9)
                    .Build(),
                new Department.Builder()
                    .DepartmentId(5)
                    .DepartmentName("Отдел сбыта")
                    .EmployeePlaces(12)
                    .Build()
            };
            return departments;
        }
    }
}