namespace API_example.Model
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public Booking(Guid customerId, Guid roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            RoomId = roomId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }
    }
}