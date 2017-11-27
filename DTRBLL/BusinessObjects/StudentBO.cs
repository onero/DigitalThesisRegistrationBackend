using System.ComponentModel.DataAnnotations;

namespace DTRBLL.BusinessObjects
{
    public class StudentBO : PersonBO
    {
        public int GroupId { get; set; }
        public bool IsInGroup { get; set; }
    }
}