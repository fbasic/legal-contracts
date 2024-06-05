using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace LegalContracts.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractsController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<LegalContract> Get()
        {
            return new List<LegalContract>
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
        }
    }
}
