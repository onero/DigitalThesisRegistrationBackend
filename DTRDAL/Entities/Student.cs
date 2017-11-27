namespace DTRDAL.Entities
{
    public class Student : Person
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public bool IsInGroup { get; set; }
    }
}