namespace API_example.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public Booking(int id, int customerId, int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            Id = id;
            CustomerId = customerId;
            RoomId = roomId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }
    }
}