namespace API_example.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }

        public Customer(int id, string name, string contactInfo)
        {
            Id = id;
            Name = name;
            ContactInfo = contactInfo;
        }
    }
}
