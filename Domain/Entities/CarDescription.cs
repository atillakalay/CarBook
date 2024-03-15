namespace Domain.Entities
{
    public class CarDescription
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
