namespace Contract.XmlService.XmlElements
{
    using global::Contract.Core;
    using System.Xml.Serialization;

    public class Money
    {
        [XmlElementAttribute("Value", DataType = "decimal")]
        public decimal Value;

        [XmlElementAttribute("Currency")]
        public Currency? Currency;
    }
}
