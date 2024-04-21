namespace FooDrink.Database.Models
{
    public class Menu : BaseEntity
    {
        public string Description { get; set; } = string.Empty;
        public Guid RestaurantId { get; set; }
    }
}
