namespace Contract.XmlService.XmlElements
{
    using System.Xml.Serialization;

    public class IdentificationNumbers
    {
        [XmlElementAttribute("NationalID")]
        public string[] NationalID;
    }
}
