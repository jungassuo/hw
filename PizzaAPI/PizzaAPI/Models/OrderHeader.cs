namespace PizzaAPI.Models
{
    // Order header is main order object, which holds price, size, and topping count values
    public class OrderHeader
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public string Size { get; set; }
        public double ToppingsCount { get; set; }
    }
}
