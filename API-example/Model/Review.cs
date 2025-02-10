namespace API_example.Model
{
    public class Review
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }

        public Review(Guid customerId, string comment, double rating)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            Comment = comment;
            Rating = rating;
        }
    }
}
