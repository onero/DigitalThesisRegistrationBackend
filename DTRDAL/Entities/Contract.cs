namespace DTRDAL.Entities
{
    public class Contract
    {
        public int GroupId { get; set; }
        public int CompanyId { get; set; }
        public int ProjectId { get; set; }
        public bool IsApproved { get; set; }
    }
}