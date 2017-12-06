namespace DTRBLL.BusinessObjects
{
    public class ContractGridBO
    {
        public ContractBO Contract { get; set; }
        public ProjectBO Project { get; set; }
        public SupervisorBO WantedSupervisor { get; set; }
        public SupervisorBO AssignedSupervisor { get; set; }
        public CompanyBO Company { get; set; }
    }
}