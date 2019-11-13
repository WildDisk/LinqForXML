using System;
using System.Linq;
using LinqForXML.datas;
using LinqForXML.utils;

namespace LinqForXML.queries
{
    public class QueryForGetDataAcademicDiscipline
    {
        private readonly AcademicDiscipline[] _discipline;

        internal QueryForGetDataAcademicDiscipline(AcademicDiscipline[] discipline)
        {
            _discipline = discipline;
        }

        /// <summary>
        /// Получение данных по дисциплинам за semester
        /// </summary>
        /// <param name="semester">Семестр</param>
        public void DisciplineInSemester(int semester)
        {
            Console.WriteLine($"\n1. Дисциплины по семестрам: семестр {semester}");
            if (_discipline != null)
            {
                var all = _discipline
                    .Where(discipline => discipline.Semester == semester)
                    .Select(discipline => discipline);
                foreach (var a in all)
                {
                    Console.WriteLine($"- {a}");
                }
            }
        }

        /// <summary>
        /// Названия дисциплин с controllingForm
        /// </summary>
        /// <param name="controllingForm">Формоа контроля</param>
        public void DisciplineWithControllingForm(string controllingForm)
        {
            Console.WriteLine($"\n2. Дисциплины с формой контроля: {controllingForm}");
            if (_discipline != null)
            {
                var disciplineName = _discipline
                    .Where(discipline => discipline.ControllingForm == controllingForm)
                    .Select(discipline => discipline.DisciplineName);
                foreach (var dn in disciplineName)
                {
                    Console.WriteLine($"- {dn}");
                }
            }
        }

        /// <summary>
        /// Число дисциплин с количеством часов от countStartHours до countEndHours
        /// </summary>
        /// <param name="countStartHours">Минимаольно заданное количество часов</param>
        /// <param name="countEndHours">Максимально заданное количество часов</param>
        public void NumbersOfDisciplineWithCountOfHours(int countStartHours, int countEndHours)
        {
            Console.WriteLine($"\n3. Число дисциплин с количеством часов от {countStartHours} до {countEndHours}");
            if (_discipline != null)
            {
                var disciplineName = _discipline
                    .Where(discipline => discipline.NumberOfHours >= countStartHours
                                         && discipline.NumberOfHours <= countEndHours)
                    .Select(discipline => discipline.DisciplineName);
                var disciplineCount = disciplineName.Count();
                Console.WriteLine($"Всего {disciplineCount} дисциплин от {countStartHours} до {countEndHours} часов.");
            }
        }

        /// <summary>
        /// ФИО преподавателя и название дисциплины в semester
        /// </summary>
        /// <param name="semester">Семестр</param>
        public void TeachersNameAndDisciplineNameAtSemester(int semester)
        {
            Console.WriteLine($"\n4. ФИО преподавателя и название дисциплин за {semester}");
            if (_discipline != null)
            {
                var teachersName = _discipline
                    .Where(d => d.Semester == semester)
                    .Select(d => new {d.TeachersName, d.DisciplineName});
                foreach (var tn in teachersName)
                {
                    Console.WriteLine($"- ФИО: {tn.TeachersName}, дисциплина: {tn.DisciplineName}");
                }
            }
        }

        /// <summary>
        /// Общее количество часов по дисциплинам teacherName
        /// </summary>
        /// <param name="teacherName">ФИО преподавателя</param>
        public void TotalHoursForTeachersSubjects(string teacherName)
        {
            Console.WriteLine($"\n5. Общее количество часов по дисциплинам {teacherName}");
            if (_discipline != null)
            {
                var all = _discipline
                    .Where(discipline => discipline.TeachersName == teacherName)
                    .Select(discipline => discipline);
                var sumHours = 0;
                foreach (var a in all)
                {
                    sumHours += a.NumberOfHours;
                }

                Console.WriteLine($"- {sumHours} часов.");
            }
        }

        /// <summary>
        /// Все дисциплины сгруппированные по specialityId
        /// </summary>
        /// <param name="specialityId">Код специальности</param>
        public void AllDisciplinesGroupedBySpecialityId(long specialityId)
        {
            Console.WriteLine($"\n6. Все дисциплины сгруппированные по коду специальности: {specialityId}");
            var all = _discipline
                .Where(discipline => discipline.SpecialityId == specialityId)
                .GroupBy(discipline => discipline.DisciplineName);
            foreach (var a in all)
            {
                Console.WriteLine($"- {a.Key}");
            }
        }

        /// <summary>
        /// Дисциплины и семестры по специальностям у факультетов
        /// </summary>
        public void DisciplineSemesterSpecialityFaculty()
        {
            Speciality[] specialities = new InitializeDataSpeciality().Specialities();
            Console.WriteLine($"\n7. Названия дисциплин и семестров по специальностям в факультетах");
            var result = _discipline
                .Join(
                    specialities,
                    discipline => discipline.SpecialityId,
                    speciality => speciality.SpecialityId,
                    (discipline, speciality) => new
                    {
                        disciplineName = discipline.DisciplineName,
                        disciplineSemester = discipline.Semester,
                        disciplineSpecialityId = discipline.SpecialityId,
                        specialityName = speciality.SpecialityName,
                        specialityFaculty = speciality.Faculty
                    }
                );
            Console.WriteLine(
                $"|{"Дисциплина",25}" +
                $"|{"Семестр",10}" +
                $"|{"Специальность",25}" +
                $"|{"Факультет",40}|"
            );
            foreach (var r in result)
            {
                Console.WriteLine(
                    $"|{r.disciplineName,25}" +
                    $"|{r.disciplineSemester,10}" +
                    $"|{r.specialityName,25}" +
                    $"|{r.specialityFaculty,40}|"
                );
            }
        }
    }
}