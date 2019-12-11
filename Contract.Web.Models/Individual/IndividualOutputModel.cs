using System;
using System.Collections.Generic;
using System.Text;

namespace Contract.Web.Models.Individual
{
    public class IndividualOutputModel
    {
        public string NationalId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
