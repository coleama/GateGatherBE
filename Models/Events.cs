using System.ComponentModel.DataAnnotations.Schema;

namespace BECapstone.Models
{
    public class Events
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string uid { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Class> Class { get; set; }
        [ForeignKey("StartTime")]
        public int StartTimeId { get; set; }
        [ForeignKey("EndTime")]
        public int EndTimeId { get; set;}
        public TimeSlots StartTime { get; set; }
        public TimeSlots EndTime { get; set; }
        public int PlayTypeId { get; set; }
        public PlayType PlayType { get; set; }
    }
}
