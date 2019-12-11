namespace Contract.XmlService.XmlElements
{
    using System;
    using System.Xml.Serialization;

    public class ContractData
    {
        [XmlElementAttribute("PhaseOfContract")]
        public string PhaseOfContract;

        [XmlElementAttribute("OriginalAmount")]
        public Money OriginalAmount;

        [XmlElementAttribute("InstallmentAmount")]
        public Money InstallmentAmount;

        [XmlElementAttribute("CurrentBalance")]
        public Money CurrentBalance;

        [XmlElementAttribute("OverdueBalance")]
        public Money OverdueBalance;

        [XmlElementAttribute("DateOfLastPayment", DataType = "date")]
        public DateTime DateOfLastPayment;

        [XmlElementAttribute("NextPaymentDate", DataType = "date")]
        public DateTime NextPaymentDate;

        [XmlElementAttribute("DateAccountOpened", DataType = "date")]
        public DateTime DateAccountOpened;

        [XmlElementAttribute("RealEndDate", DataType = "date")]
        public DateTime RealEndDate;
    }
}
