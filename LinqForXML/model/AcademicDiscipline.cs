namespace LinqForXML.model
{
    /// <summary>
    /// Академическая дисциплина
    /// </summary>
    public class AcademicDiscipline
    {
        public long DisciplineId { get; set; }
        public string DisciplineName { get; set; }
        public string TeachersName { get; set; }
        public string ControllingForm { get; set; }
        public int Semester { get; set; }
        public int NumberOfHours { get; set; }
        public long SpecialityId { get; set; }

        public override string ToString()
        {
            return string.Format(
                $"Id дисциплины: {DisciplineId}\n" +
                $"Название дисциплины: {DisciplineName}\n" +
                $"ФИО преподавателя: {TeachersName}\n" +
                $"Форма контроля: {ControllingForm}\n" +
                $"Семестр: {Semester}\n" +
                $"Количество часов: {NumberOfHours}\n" +
                $"Id специальности: {SpecialityId}"
            );
        }
    }
}