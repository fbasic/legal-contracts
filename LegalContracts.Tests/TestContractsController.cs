using System.Collections.Generic;
using System.Linq;
using LegalContracts.API;
using LegalContracts.API.Controllers;
using LegalContracts.Core.Models;
using LegalContracts.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LegalContracts.Tests
{
    [TestClass]
    public class TestContractsController
    {
        private ContractsController _controller;
        private ContractService _service;
        
        [TestInitialize]
        public void Initialize()
        {
            _service = new ContractService();
            _controller = new ContractsController(_service);
        }
        
        [TestCleanup]
        public void Cleanup()
        {
            _service = new ContractService();
        }
        
        [TestMethod]
        public void GetAllContracts_ShouldReturnAllContracts()
        {
            var result = _controller.GetAll() as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, (result.Value as List<LegalContract>).Count);
        }
        
        [TestMethod]
        public void PostContract_ShouldReturnCreatedContract()
        {
            var testContractRequest = new ContractRequest
            {
                AuthorName = "Joe Jones",
                LegalEntityName = "Test Corp",
                LegalEntityDescription = "Test Corp Description"
            };
            var result = _controller.Post(testContractRequest) as OkObjectResult;

            Assert.IsNotNull(result);

            var contract = result.Value as LegalContract;
            
            Assert.IsNotNull(contract);
            Assert.AreEqual(contract.AuthorName, testContractRequest.AuthorName);
            Assert.AreEqual(contract.LegalEntityName, testContractRequest.LegalEntityName);
            Assert.AreEqual(contract.LegalEntityDescription, testContractRequest.LegalEntityDescription);
        }
        
        [TestMethod]
        public void PutContract_ShouldReturnUpdatedContract()
        {
            const int existingContractId = 1;
            var testContractRequest = new ContractRequest
            {
                AuthorName = "Joe Jones",
                LegalEntityName = "Test Corp",
                LegalEntityDescription = "Test Corp Description"
            };
            var result = _controller.Put(existingContractId, testContractRequest) as OkObjectResult;

            Assert.IsNotNull(result);

            var contract = result.Value as LegalContract;
            
            Assert.IsNotNull(contract);
            Assert.AreEqual(contract.AuthorName, testContractRequest.AuthorName);
            Assert.AreEqual(contract.LegalEntityName, testContractRequest.LegalEntityName);
            Assert.AreEqual(contract.LegalEntityDescription, testContractRequest.LegalEntityDescription);
        }
        
        [TestMethod]
        public void DeleteContract_ShouldRemoveContract()
        {
            const int existingContractId = 1;
            _controller.Delete(existingContractId);
            
             var deletedContract = _service
                 .GetAllContracts()
                 .SingleOrDefault(contract => contract.Id == existingContractId);
            
            Assert.IsNull(deletedContract);
        }
    }
}