namespace API_example.Model
{
    public class Room
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double PricePerNight { get; set; }
        public bool IsAvailable { get; set; }

        public Room(int id, string type, double pricePerNight, bool isAvailable)
        {
            Id = id;
            Type = type;
            PricePerNight = pricePerNight;
            IsAvailable = isAvailable;
        }
    }
}