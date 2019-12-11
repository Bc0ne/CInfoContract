namespace Contract.XmlService.XmlElements
{
    using global::Contract.Core.SubjectRole;
    using System.Xml.Serialization;

    public class SubjectRole
    {
        [XmlElementAttribute("CustomerCode")]
        public string CustomerCode;

        [XmlElementAttribute("RoleOfCustomer")]
        public CustomerRole? RoleOfCustomer;

        [XmlElementAttribute("GuaranteeAmount")]
        public Money GuaranteeAmount;
    }
}
