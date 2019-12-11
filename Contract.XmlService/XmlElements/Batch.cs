namespace Contract.XmlService.XmlElements
{
    using System.Xml;
    using System.Xml.Serialization;

    [XmlRootAttribute("Batch", Namespace = "http://creditinfo.com/schemas/Sample/Data", IsNullable = false)]
    public class Batch
    {
        [XmlElementAttribute("Contract")]
        public Contract[] Contract;
    }
}
