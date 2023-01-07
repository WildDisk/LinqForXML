namespace LinqForXML.model
{
    public class Department
    {
        public long DepartmentId { get; }
        public string DepartmentName { get; }
        public int EmployeePlaces { get; }

        public Department(long id, string departmentName, int employeePlaces)
        {
            DepartmentId = id;
            DepartmentName = departmentName;
            EmployeePlaces = employeePlaces;
        }
        
        public class Builder
        {
            private long _departmentId;
            private string _departmentName;
            private int _employeePlaces;

            public Builder DepartmentId(long departmentId)
            {
                _departmentId = departmentId;
                return this;
            }

            public Builder DepartmentName(string departmentName)
            {
                _departmentName = departmentName;
                return this;
            }

            public Builder EmployeePlaces(int employeePlaces)
            {
                _employeePlaces = employeePlaces;
                return this;
            }

            public Department Build()
            {
                return new Department(
                    id: _departmentId,
                    departmentName: _departmentName,
                    employeePlaces: _employeePlaces
                );
            }
        }

        public override string ToString()
        {
            return string.Format(
                $"Id отдела: {DepartmentId}\n" +
                $"Название отдела: {DepartmentName}\n" +
                $"Количество рабочих мест: {EmployeePlaces}"
            );
        }
    }
}