using LegalContracts.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LegalContracts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractsController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var contracts = _contractService
                .GetAllContracts();
            
            return Ok(contracts);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            var contract = _contractService.GetContractById(id);

            return Ok(contract);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] ContractRequest contractRequest)
        {
            var contract = _contractService
                .SaveContract(contractRequest.AuthorName, contractRequest.LegalEntityName, contractRequest.LegalEntityDescription);
            
            return Ok(contract);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] ContractRequest contractRequest)
        {
            var contract = _contractService
                .UpdateContract(id, contractRequest.AuthorName, contractRequest.LegalEntityName, contractRequest.LegalEntityDescription);

            return Ok(contract);
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _contractService.DeleteContract(id);
            return Ok();
        }
    }
}
