namespace CoffeeShop.Models
{
    public class OrderModel<TOrder> where TOrder : class
    {
        public List<Order> OrderItem { get; set; }
    }

    public class Order
    {
        public string? OrderItem { get; set; }
        public int OrderItemId { get; set; }
        public int Count { get; set; }
    }
}
