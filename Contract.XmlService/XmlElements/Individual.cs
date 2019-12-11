namespace Contract.XmlService.XmlElements
{
    using global::Contract.Core.Individual;
    using System;
    using System.Xml.Serialization;

    public class Individual
    {
        [XmlElementAttribute("CustomerCode")]
        public string CustomerCode;

        [XmlElementAttribute("FirstName")]
        public string FirstName;

        [XmlElementAttribute("LastName")]
        public string LastName;

        [XmlElementAttribute("Gender")]
        public Gender? Gender;

        [XmlElementAttribute("DateOfBirth", DataType ="date")]
        public DateTime DateOfBirth;

        [XmlElementAttribute("IdentificationNumbers")]
        public IdentificationNumbers IdentificationNumbers;
    }
}
