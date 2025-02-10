namespace API_example.Model
{
    public class Staff
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public Staff(string name, string position)
        {
            Id = Guid.NewGuid();
            Name = name;
            Position = position;
        }
    }
}