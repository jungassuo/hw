namespace PizzaAPI.Models
{
    // Order details class is used to store all toppings, which are related to unique header
    public class OrderDetails
    {
        public int Id { get; set; }
        public int HeaderId { get; set; }
        public string ToppingName { get; set; }
    }
}
