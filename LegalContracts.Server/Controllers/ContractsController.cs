using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace LegalContracts.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractsController : ControllerBase
    {
        private static readonly List<LegalContract> Contracts = new List<LegalContract>
        {
            new LegalContract
            {
                Id = 1,
                AuthorName = "John Doe",
                LegalEntityName = "XY Corp",
                LegalEntityDescription = "A multinational company",
                CreatedAt = new DateTime(2020, 1, 1),
                UpdatedAt = new DateTime(2023, 6, 1)
            }
        };

        [HttpGet]
        public IEnumerable<LegalContract> Get()
        {
            return Contracts;
        }
        
        [HttpPost]
        public void Post([FromBody] CreateContractRequest createContractRequest)
        {
            var contract = new LegalContract
            {
                Id = Contracts.Count + 1,
                AuthorName = createContractRequest.AuthorName,
                LegalEntityName = createContractRequest.LegalEntityName,
                LegalEntityDescription = createContractRequest.LegalEntityDescription,
                CreatedAt = DateTime.UtcNow
            };
            
            Contracts.Add(contract);
        }
    }
}
