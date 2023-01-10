namespace LinqForXML.model
{
    public class Speciality
    {
        public long SpecialityId { get; }
        public string SpecialityName { get; }
        public string Faculty { get; }

        public Speciality(long id, string specialityName, string faculty)
        {
            SpecialityId = id;
            SpecialityName = specialityName;
            Faculty = faculty;
        }
        
        internal class Builder
        {
            private long _specialityId;
            private string _specialityName;
            private string _faculty;

            public Builder SpecialityId(long id)
            {
                _specialityId = id;
                return this;
            }

            public Builder SpecialityName(string name)
            {
                _specialityName = name;
                return this;
            }

            public Builder Faculty(string faculty)
            {
                _faculty = faculty;
                return this;
            }

            public Speciality Build()
            {
                return new Speciality(
                    id: _specialityId,
                    specialityName: _specialityName,
                    faculty: _faculty
                );
            }
        }

        public override string ToString()
        {
            return $"Speciality(specialityId={SpecialityId}, specialityName={SpecialityName}, faculty={Faculty})";
        }
    }
}