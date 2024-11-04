using System.Xml.Serialization;

namespace Task2.Model
{


    [XmlRoot(ElementName = "person")]
    public class Person
    {

        [XmlElement(ElementName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "firstname")]
        public string Firstname { get; set; }

        [XmlElement(ElementName = "lastname")]
        public string Lastname { get; set; }

        [XmlElement(ElementName = "age")]
        public int Age { get; set; }
    }



}
