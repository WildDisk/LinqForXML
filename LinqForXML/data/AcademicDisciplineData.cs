using LinqForXML.model;

namespace LinqForXML.data
{
    /// <summary>
    /// Данные инициализации по дисциплинам
    /// </summary>
    public class AcademicDisciplineData
    {
        public AcademicDiscipline[] Disciplines()
        {
            AcademicDiscipline[] disciplines =
            {
                new AcademicDiscipline.Builder()
                    .DisciplineId(24)
                    .DisciplineName("Архитектура ИС")
                    .TeachersName("Иванов Иван Иванович")
                    .ControllingForm("Экзамен")
                    .Semester(7)
                    .NumberOfHours(36)
                    .SpecialityId(12)
                    .Build(),
                new AcademicDiscipline.Builder()
                    .DisciplineId(24)
                    .DisciplineName("Архитектура ИС")
                    .TeachersName("Иванов Иван Иванович")
                    .ControllingForm("Экзамен")
                    .Semester(7)
                    .NumberOfHours(36)
                    .SpecialityId(12)
                    .Build(),
                new AcademicDiscipline.Builder()
                    .DisciplineId(8)
                    .DisciplineName("Базы данных")
                    .TeachersName("Семёнов Семён Семёнович")
                    .ControllingForm("Экзамен")
                    .Semester(4)
                    .NumberOfHours(48)
                    .SpecialityId(5)
                    .Build()
            };
            return disciplines;
        }
    }
}