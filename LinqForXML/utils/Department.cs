namespace LinqForXML.utils
{
    public class Department
    {
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int EmployeePlaces { get; set; }

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