using System.Xml.Serialization;

namespace Task2.Model
{
    [XmlRoot(ElementName = "persons")]
    public class Persons
    {

        [XmlElement(ElementName = "person")]
        public List<Person> Person { get; set; }
    }



}
