using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace LegalContracts.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public IActionResult GetAll()
        {
            var contracts = Contracts
                .OrderBy(contract => contract.Id)
                .ToList();
            
            return Ok(contracts);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            var contract = Contracts
                .SingleOrDefault(contract => contract.Id == id);
            
            if (contract == null)
            {
                return BadRequest("Contract not found");
            }

            return Ok(contract);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] ContractRequest contractRequest)
        {
            var contract = new LegalContract
            {
                Id = Contracts.Count + 1,
                AuthorName = contractRequest.AuthorName,
                LegalEntityName = contractRequest.LegalEntityName,
                LegalEntityDescription = contractRequest.LegalEntityDescription,
                CreatedAt = DateTime.UtcNow
            };
            
            Contracts.Add(contract);
            return Ok(contract);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] ContractRequest contractRequest)
        {
            var contract = Contracts.SingleOrDefault(contract => contract.Id == id);
            if (contract == null)
            {
                return BadRequest("Contract not found");
            }

            contract.AuthorName = contractRequest.AuthorName;
            contract.LegalEntityName = contractRequest.LegalEntityName;
            contract.LegalEntityDescription = contractRequest.LegalEntityDescription;
            contract.UpdatedAt = DateTime.UtcNow;

            return Ok(contract);
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var contract = Contracts.SingleOrDefault(contract => contract.Id == id);
            if (contract == null)
            {
                return BadRequest("Contract not found");
            }

            Contracts.Remove(contract);
            return Ok(contract);
        }
    }
}
