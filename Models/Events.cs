namespace BECapstone.Models
{
    public class Events
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string uid { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Class> Class { get; set; }
        public int StartTimeId { get; set; }
        public int EndTimeId { get; set;}
        public int PlayTypeId { get; set; }
    }
}
