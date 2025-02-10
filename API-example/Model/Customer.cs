namespace API_example.Model
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }

        public Customer(string name, string contactInfo)
        {
            Id = Guid.NewGuid();
            Name = name;
            ContactInfo = contactInfo;
        }
    }
}
