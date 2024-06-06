using System;
using System.Collections.Generic;
using System.Linq;
using LegalContracts.Core.Interfaces;
using LegalContracts.Core.Models;

namespace LegalContracts.Core.Services
{
    public class ContractService : IContractService
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
        
        public IList<LegalContract> GetAllContracts()
        {
            return Contracts
                .OrderBy(contract => contract.Id)
                .ToList();
        }

        public LegalContract GetContractById(int id)
        {
            return Contracts
                .SingleOrDefault(contract => contract.Id == id);
        }

        public LegalContract SaveContract(string authorName, string legalEntityName, string legalEntityDescription)
        {
            var contract = new LegalContract
            {
                Id = Contracts.Count + 1,
                AuthorName = authorName,
                LegalEntityName = legalEntityName,
                LegalEntityDescription = legalEntityDescription,
                CreatedAt = DateTime.UtcNow
            };
            
            Contracts.Add(contract);
            return contract;
        }

        public LegalContract UpdateContract(int id, string authorName, string legalEntityName, string legalEntityDescription)
        {
            var contract = Contracts.SingleOrDefault(contract => contract.Id == id);
            if (contract == null)
            {
                throw new Exception("Contract not found");
            }

            contract.AuthorName = authorName;
            contract.LegalEntityName = legalEntityName;
            contract.LegalEntityDescription = legalEntityDescription;
            contract.UpdatedAt = DateTime.UtcNow;

            return contract;
        }

        public void DeleteContract(int id)
        {
            var contract = Contracts.SingleOrDefault(contract => contract.Id == id);
            if (contract == null)
            {
                throw new Exception("Contract not found");
            }

            Contracts.Remove(contract);
        }
    }
}