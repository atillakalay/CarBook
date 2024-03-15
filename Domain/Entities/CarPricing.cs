namespace Domain.Entities
{
    public class CarPricing
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int CarId { get; set; }
        public int PricingId { get; set; }
        public Car Car { get; set; }
        public Pricing Pricing { get; set; }

    }
}
