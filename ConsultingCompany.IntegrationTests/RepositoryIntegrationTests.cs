namespace ConsultingCompany.IntegrationTests
{
    using System;

    using ConsultingCompany.DataStore;
    using ConsultingCompany.Lib;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RepositoryIntegrationTests
    {
        private IConsultingCompanyRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new ConsultingCompanyRepository();
        }

        [TestMethod]
        public void ThereShouldBeFourClients()
        {
            Assert.IsTrue(_repository.Clients.Count == 3);
        }

        [TestMethod]
        public void ThereShouldBeTenResources()
        {
            Assert.IsTrue(_repository.Resources.Count == 10);
        }

        [TestMethod]
        public void SuccessFullyAddClient()
        {
            Client newClient =
                new Client() { CompanyName = "Tesla", ContactLastName = "Musk", ContactFirstName = "Elon" };
            this._repository.Clients.Add(newClient);
            Assert.IsTrue(_repository.Clients.Count == 4);

            foreach (var client in this._repository.Clients)
            {
                Console.WriteLine($"CompanyName: {client.CompanyName} Contact Name: {client.ContactFirstName} {client.ContactLastName}");
            }
        }

        [TestMethod]
        public void SuccessFullyAddResouce()
        {
            Resource newResource = new Resource() { FirstName = "Mike", LastName = "Stubbs", Type = ResourceType.QA };
            this._repository.Resources.Add(newResource);
            Assert.IsTrue(_repository.Resources.Count == 11);

            foreach (var resource in this._repository.Resources)
            {
                Console.WriteLine($"Name: {resource.FirstName} {resource.LastName} Type: {resource.Type}");
            }
        }
    }
}