namespace Domain.Entities
{
    public class CarFeature
    {
        public int CarFeatureId { get; set; }
        public bool Available { get; set; }
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public Car Car { get; set; }
        public Feature Feature { get; set; }

    }
}
