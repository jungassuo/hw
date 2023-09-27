namespace PizzaAPI.Models.Dtos
{
    public class OrderDto
    {
        public string size { get; set; }
        public double toppingsCount { get; set; }
        public List<string> toppingsArr { get; set; } = new List<string>();
        public double price { get; set; }
    }
}
