namespace PizzaAPI.Models
{
    // Order class holds data, posted from front-end
    public class Order
    {
        public string size { get; set; }
        public double toppingsCount { get; set; }
        public List<string> toppingsArr { get; set; } = new List<string>();
        public double price { get; set; }
    }
}
