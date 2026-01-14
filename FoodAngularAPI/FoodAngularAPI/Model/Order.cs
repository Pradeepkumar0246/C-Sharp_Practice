namespace FoodAngularAPI.Model
{
    public class Order
    {
        public int Id { get; set; }
        public ICollection<CartItems> Items { get; set; } = new List<CartItems>();
    }
}
