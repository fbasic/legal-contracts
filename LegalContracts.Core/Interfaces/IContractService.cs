using System.Collections.Generic;
using LegalContracts.Core.Models;

namespace LegalContracts.Core.Interfaces
{
    public interface IContractService
    {
        IList<LegalContract> GetAllContracts();
        
        LegalContract GetContractById(int id);
        
        LegalContract SaveContract(string authorName, string legalEntityName, string legalEntityDescription);
        
        LegalContract UpdateContract(int id, string authorName, string legalEntityName, string legalEntityDescription);
        
        void DeleteContract(int id);
    }
}