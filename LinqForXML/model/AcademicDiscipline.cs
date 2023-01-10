namespace LinqForXML.model
{
    /// <summary>
    /// Академическая дисциплина
    /// </summary>
    public class AcademicDiscipline
    {
        public long DisciplineId { get; }
        public string DisciplineName { get; }
        public string TeachersName { get; }
        public string ControllingForm { get; }
        public int Semester { get; }
        public int NumberOfHours { get; }
        public long SpecialityId { get; }

        public AcademicDiscipline(long id, string name, string teacher, string form, int semester, int numberOfHours,
            long specialityId)
        {
            DisciplineId = id;
            DisciplineName = name;
            TeachersName = teacher;
            ControllingForm = form;
            Semester = semester;
            NumberOfHours = numberOfHours;
            SpecialityId = specialityId;
        }

        internal class Builder
        {
            private long _disciplineId;
            private string _disciplineName;
            private string _teachersName;
            private string _controllingForm;
            private int _semester;
            private int _numberOfHours;
            private long _specialityId;

            public Builder DisciplineId(long id)
            {
                _disciplineId = id;
                return this;
            }

            public Builder DisciplineName(string name)
            {
                _disciplineName = name;
                return this;
            }

            public Builder TeachersName(string name)
            {
                _teachersName = name;
                return this;
            }

            public Builder ControllingForm(string form)
            {
                _controllingForm = form;
                return this;
            }

            public Builder Semester(int semester)
            {
                _semester = semester;
                return this;
            }

            public Builder NumberOfHours(int hours)
            {
                _numberOfHours = hours;
                return this;
            }

            public Builder SpecialityId(long id)
            {
                _specialityId = id;
                return this;
            }

            public AcademicDiscipline Build()
            {
                return new AcademicDiscipline(
                    id: _disciplineId,
                    name: _disciplineName,
                    teacher: _teachersName,
                    form: _controllingForm,
                    semester: _semester,
                    numberOfHours: _numberOfHours,
                    specialityId: _specialityId
                );
            }
        }

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