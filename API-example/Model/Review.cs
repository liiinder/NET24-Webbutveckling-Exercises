namespace API_example.Model
{
    public class Review
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }

        public Review(int id, int customerId, string comment, double rating)
        {
            Id = id;
            CustomerId = customerId;
            Comment = comment;
            Rating = rating;
        }
    }
}
