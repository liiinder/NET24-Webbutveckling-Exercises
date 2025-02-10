namespace API_example.Model
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public Staff(int id, string name, string position)
        {
            Id = id;
            Name = name;
            Position = position;
        }
    }
}
