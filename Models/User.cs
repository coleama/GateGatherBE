namespace BECapstone.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string uid { get; set; }
        public ICollection<Events> Events { get; set; }
        public ICollection<Class> Class { get; set; }
    }
}
