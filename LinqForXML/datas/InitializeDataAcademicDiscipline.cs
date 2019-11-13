using LinqForXML.utils;

namespace LinqForXML.datas
{
    /// <summary>
    /// Данные инициализации по дисциплинам
    /// </summary>
    public class InitializeDataAcademicDiscipline
    {
        public AcademicDiscipline[] Disciplines()
        {
            AcademicDiscipline[] disciplines =
            {
                new AcademicDiscipline
                {
                    DisciplineId = 24,
                    DisciplineName = "Архитектура ИС",
                    TeachersName = "Иванов Иван Иванович",
                    ControllingForm = "Экзамен",
                    Semester = 7,
                    NumberOfHours = 36,
                    SpecialityId = 12
                },
                new AcademicDiscipline
                {
                    DisciplineId = 24,
                    DisciplineName = "Архитектура ИС",
                    TeachersName = "Сидоров Сидор Сидорович",
                    ControllingForm = "Диференцированный зачет",
                    Semester = 5,
                    NumberOfHours = 22,
                    SpecialityId = 5
                },
                new AcademicDiscipline
                {
                    DisciplineId = 8,
                    DisciplineName = "Базы данных",
                    TeachersName = "Семёнов Семён Семёнович",
                    ControllingForm = "Экзамен",
                    Semester = 4,
                    NumberOfHours = 48,
                    SpecialityId = 5
                }
            };
            return disciplines;
        }
    }
}