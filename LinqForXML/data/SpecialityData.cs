using LinqForXML.model;

namespace LinqForXML.data
{
    /// <summary>
    /// Данные инициализации по специальностям
    /// </summary>
    public class SpecialityData
    {
        public Speciality[] Specialities()
        {
            Speciality[] specialities =
            {
                new Speciality.Builder()
                    .SpecialityId(5)
                    .SpecialityName("Прикладная информатика")
                    .Faculty("Институт информатики и бизнес систем")
                    .Build(),
                new Speciality.Builder()
                    .SpecialityId(12)
                    .SpecialityName("Инфорационные системы")
                    .Faculty("Институт информатики и бизнес систем")
                    .Build()
            };
            return specialities;
        }
    }
}