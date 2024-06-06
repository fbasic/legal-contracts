using System;

namespace LegalContracts.Core.Models
{
    public class LegalContract
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }

        public string LegalEntityName { get; set; }

        public string LegalEntityDescription { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime? UpdatedAt { get; set; }
    }
}
