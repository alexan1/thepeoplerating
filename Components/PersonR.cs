using WikiDataLib;

namespace thepeoplerating.Components
{
    public class PersonR
    {
        public PersonR(WikiPerson person, double? rating)
        {
            Person = person;
            Rating = rating;
        }
        public WikiPerson Person { get; set; }
        public double? Rating { get; set; }
    }
}