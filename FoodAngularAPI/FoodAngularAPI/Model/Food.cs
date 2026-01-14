namespace FoodAngularAPI.Model
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Price { get; set; }
        public string Category { get; set; } = "";
        public string ImageUrl { get; set; } = "";
    }
}
