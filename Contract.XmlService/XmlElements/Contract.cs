namespace Contract.XmlService.XmlElements
{
    using System.Xml.Serialization;

    public class Contract
    {
        [XmlElementAttribute("ContractCode")]
        public string ContractCode;

        [XmlElementAttribute("ContractData")]
        public ContractData ContractData;

        [XmlElementAttribute("Individual")]
        public Individual[] Individual;

        [XmlElementAttribute("SubjectRole")]
        public SubjectRole[] SubjectRole;
    }
}
