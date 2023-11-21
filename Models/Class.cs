namespace BECapstone.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string image {  get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Events> Events { get; set; }
    }
}
