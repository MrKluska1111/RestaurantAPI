namespace RestaurantAPI.Entities
{
    public class Address
    {
        public int ID { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
