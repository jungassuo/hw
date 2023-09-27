namespace PizzaAPI.Models.Dtos
{
    public class OrderHeaderDto
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public string Size { get; set; }
        public double ToppingsCount { get; set; }
    }
}
