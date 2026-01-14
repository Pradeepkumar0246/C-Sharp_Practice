namespace FoodAngularAPI.Model
{
    public class CartItems
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
        public Food? Food { get; set; }
    }
}
