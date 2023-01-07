using LinqForXML.model;

namespace LinqForXML.data
{
    /// <summary>
    /// Данные инициализации по специальностям
    /// </summary>
    public class InitializeDataSpeciality
    {
        public Speciality[] Specialities()
        {
            Speciality[] specialities =
            {
                new Speciality
                {
                    SpecialityId = 5,
                    SpecialityName = "Прикладная информатика",
                    Faculty = "Институт информатики и бизнес систем"
                },
                new Speciality
                {
                    SpecialityId = 12,
                    SpecialityName = "Инфорационные системы",
                    Faculty = "Институт информатики и бизнес систем"
                }
            };
            return specialities;
        }
    }
}