namespace LegalContracts.Server
{
    public class CreateContractRequest
    {
        public string AuthorName { get; set; }

        public string LegalEntityName { get; set; }

        public string LegalEntityDescription { get; set; }
    }
}