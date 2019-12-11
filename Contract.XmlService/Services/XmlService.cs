namespace Contract.XmlService.Services
{
    using System;
    using Contract.Core.Contract;
    using Contract.Core.Individual;
    using Contract.Core.SubjectRole;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Contract.Core;
    using System.Xml.Schema;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Collections;

    public class XmlService
    {
        private readonly IContractRepository _contractRepository;
        private readonly XmlConfig _xmlConfig;

        public XmlService(IContractRepository contractRepository,
            XmlConfig xmlConfig)
        {
            _contractRepository = contractRepository ?? throw new ArgumentNullException(nameof(contractRepository));
            _xmlConfig = xmlConfig;
        }

        public void Validate()
        {
            // The XML document to deserialize into the XmlSerializer object.
            XmlReader reader = XmlReader.Create(_xmlConfig.XmlDataUrlLocation,
                new XmlReaderSettings
                {
                    DtdProcessing = DtdProcessing.Parse
                });

            // The XmlSerializer object.
            XmlSerializer serializer = new XmlSerializer(typeof(XmlElements.Batch));
            XmlElements.Batch batch = (XmlElements.Batch)serializer.Deserialize(reader);

            // The XmlSchemaSet object containing the schema used to validate the XML document.
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add(_xmlConfig.SchemaNamespaceUrlLocation, _xmlConfig.SchemaUrlLocation);

            // The XmlNamespaceManager object used to handle namespaces.
            XmlNamespaceManager manager = new XmlNamespaceManager(reader.NameTable);

            // Assign a ValidationEventHandler to handle schema validation warnings and errors.
            XmlSchemaValidator validator = new XmlSchemaValidator(reader.NameTable, schemaSet, manager, XmlSchemaValidationFlags.None);
            validator.ValidationEventHandler += new ValidationEventHandler(SchemaValidationEventHandler);

            // Initialize the XmlSchemaValidator object.
            validator.Initialize();

            // Validate the bookstore element, verify that all required attributes are present
            // and prepare to validate child content.
            validator.ValidateElement("Batch", _xmlConfig.SchemaNamespaceUrlLocation, null);
            validator.GetUnspecifiedDefaultAttributes(new ArrayList());
            validator.ValidateEndOfAttributes(null);

            // Get the next exptected element in the batch context.
            XmlSchemaParticle[] particles = validator.GetExpectedParticles();
            XmlSchemaElement nextElement = particles[0] as XmlSchemaElement;
            Console.WriteLine("Expected Element: '{0}'", nextElement.Name);

            var validContracts = new List<XmlElements.Contract>();
            foreach (XmlElements.Contract contract in batch.Contract)
            {
                Console.WriteLine("New Contract validation");
                bool isValidContract = true;
                // Validate the contract element.
                validator.ValidateElement("Contract", _xmlConfig.SchemaNamespaceUrlLocation, null);
                validator.GetUnspecifiedDefaultAttributes(new ArrayList());
                validator.ValidateEndOfAttributes(null);

                // Validate the contract code element .
                if (contract.ContractCode != null)
                {
                    // Validate the name element and its content.
                    validator.ValidateElement("ContractCode", _xmlConfig.SchemaNamespaceUrlLocation, null);
                    validator.ValidateEndElement(null, contract.ContractCode);
                }
                else
                {
                    isValidContract = false;
                    continue;
                }

                // Validate the contract data element, verify that all required attributes are present
                // and prepare to validate child content.
                validator.ValidateElement("ContractData", _xmlConfig.SchemaNamespaceUrlLocation, null);
                validator.GetUnspecifiedDefaultAttributes(new ArrayList());
                validator.ValidateEndOfAttributes(null);

                if (contract.ContractData.PhaseOfContract != null)
                {
                    // Validate the name element and its content.
                    validator.ValidateElement("PhaseOfContract", _xmlConfig.SchemaNamespaceUrlLocation, null);
                    validator.ValidateEndElement(null, contract.ContractData.PhaseOfContract);
                }
                else
                {
                    isValidContract = false;
                    continue;
                }

                if (contract.ContractData.CurrentBalance != null)
                {
                    // Validate the name element and its content.
                    validator.ValidateElement("CurrentBalance", _xmlConfig.SchemaNamespaceUrlLocation, null);
                    validator.ValidateEndElement(null);
                }
                else
                {
                    isValidContract = false;
                    continue;
                }

                validator.ValidateEndElement(null);


                // Validate the content of the individual element.
                foreach (var individual in contract.Individual)
                {
                    validator.ValidateElement("Individual", _xmlConfig.SchemaNamespaceUrlLocation, null);
                    validator.GetUnspecifiedDefaultAttributes(new ArrayList());
                    validator.ValidateEndOfAttributes(null);

                    if (individual.FirstName != null)
                    {
                        validator.ValidateElement("FirstName", _xmlConfig.SchemaNamespaceUrlLocation, null);
                        validator.ValidateEndElement(null, individual.FirstName);
                    }
                    else
                    {
                        isValidContract = false;
                    }

                    if (individual.LastName != null)
                    {
                        validator.ValidateElement("LastName", _xmlConfig.SchemaNamespaceUrlLocation, null);
                        validator.ValidateEndElement(null, individual.LastName);
                    }
                    else
                    {
                        isValidContract = false;
                    }

                    validator.ValidateEndElement(null);
                }

                //validate the content of subject roles elements
                foreach (var role in contract.SubjectRole)
                {
                    validator.ValidateElement("SubjectRole", _xmlConfig.SchemaNamespaceUrlLocation, null);
                    validator.GetUnspecifiedDefaultAttributes(new ArrayList());
                    validator.ValidateEndOfAttributes(null);

                    if (role.CustomerCode != null)
                    {
                        validator.ValidateElement("CustomerCode", _xmlConfig.SchemaNamespaceUrlLocation, null);
                        validator.ValidateEndElement(null, role.CustomerCode);
                    }
                    else
                    {
                        isValidContract = false;
                    }

                    if (role.RoleOfCustomer != null)
                    {
                        validator.ValidateElement("RoleOfCustomer", _xmlConfig.SchemaNamespaceUrlLocation, null);
                        validator.ValidateEndElement(null, role.CustomerCode);
                    }
                    else
                    {
                        isValidContract = false;
                    }

                    validator.ValidateEndElement(null);
                }

                // Validate the content of the contract element.
                validator.ValidateEndElement(null);

                if (isValidContract)
                {
                    validContracts.Add(contract);
                }
            }

            // Validate the content of the batch element.
            validator.ValidateEndElement(null);

            // Close the XmlReader object.
            reader.Close();

            ExtractAsync(validContracts);
        }

        static XmlSchemaInfo schemaInfo = new XmlSchemaInfo();
        static object dateTimeGetterContent;

        static object dateTimeGetterHandle()
        {
            return dateTimeGetterContent;
        }

        static XmlValueGetter dateTimeGetter(DateTime dateTime)
        {
            dateTimeGetterContent = dateTime;
            return new XmlValueGetter(dateTimeGetterHandle);
        }

        static void DisplaySchemaInfo()
        {
            if (schemaInfo.SchemaElement != null)
            {
                Console.WriteLine("Element '{0}' with type '{1}' is '{2}'",
                    schemaInfo.SchemaElement.Name, schemaInfo.SchemaType, schemaInfo.Validity);
            }
            else if (schemaInfo.SchemaAttribute != null)
            {
                Console.WriteLine("Attribute '{0}' with type '{1}' is '{2}'",
                    schemaInfo.SchemaAttribute.Name, schemaInfo.SchemaType, schemaInfo.Validity);
            }
        }

        static void SchemaValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("\nError: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("\nWarning: {0}", e.Message);
                    break;
            }
        }

        public async Task ExtractAsync(List<XmlElements.Contract> validContracts)
        {
            var contracts = new List<Contract>();
            foreach (var con in validContracts)
            {
                var originalAmount = con.ContractData.OriginalAmount != null ?
                    Money.New(con.ContractData.OriginalAmount.Value,
                    con.ContractData.OriginalAmount.Currency)
                    : new Money();

                var installmentAmount = con.ContractData.InstallmentAmount != null ?
                 Money.New(con.ContractData.InstallmentAmount.Value,
                 con.ContractData.InstallmentAmount.Currency)
                 : new Money();

                var currentBalance = Money.New(con.ContractData.OriginalAmount.Value,
                    con.ContractData.OriginalAmount.Currency);

                var overdueBalance = con.ContractData.OverdueBalance != null ?
               Money.New(con.ContractData.OverdueBalance.Value, con.ContractData.OverdueBalance.Currency)
               : new Money();

                var contractData = ContractData.New(
                    originalAmount,
                    installmentAmount,
                    currentBalance,
                    overdueBalance,
                    con.ContractData.DateOfLastPayment,
                    con.ContractData.NextPaymentDate,
                    con.ContractData.DateAccountOpened,
                    con.ContractData.RealEndDate
                 );

                var individuals = new List<Individual>();
                foreach (var ind in con.Individual)
                {
                    var individual = Individual.New(
                        ind.CustomerCode,
                        ind.FirstName,
                        ind.LastName,
                        ind.Gender,
                        ind.DateOfBirth,
                        ind.IdentificationNumbers.NationalID.FirstOrDefault()
                    );
                    individuals.Add(individual);
                }

                var subjectRoles = new List<SubjectRole>();
                foreach (var role in con.SubjectRole)
                {
                    var guaranteeAmount = role.GuaranteeAmount is null ? new Money()
                    : Money.New(role.GuaranteeAmount.Value,role.GuaranteeAmount.Currency);

                    var subjectRole = SubjectRole.New(role.CustomerCode,
                        role.RoleOfCustomer.Value,
                        guaranteeAmount
                    );

                    subjectRoles.Add(subjectRole);
                }

                var contract = Contract.New(con.ContractCode,
                    contractData,
                    individuals,
                    subjectRoles);

                if (contract.IsValid())
                {
                    contracts.Add(contract);
                }
            }

            await SaveData(contracts);
        }

        public async Task SaveData(List<Contract> contracts)
        {
            try
            {
                await _contractRepository.AddRangeOfContractsAsync(contracts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
