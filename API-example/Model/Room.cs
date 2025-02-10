namespace API_example.Model
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public double PricePerNight { get; set; }
        public bool IsAvailable { get; set; }

        public Room(string type, double pricePerNight, bool isAvailable)
        {
            Id = Guid.NewGuid();
            Type = type;
            PricePerNight = pricePerNight;
            IsAvailable = isAvailable;
        }
    }
}