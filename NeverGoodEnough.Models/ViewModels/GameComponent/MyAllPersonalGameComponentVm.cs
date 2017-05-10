namespace NeverGoodEnough.Models.ViewModels.GameMechanic
{
    using NeverGoodEnough.Models.Enums;

    public class MyAllPersonalGameComponentVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Upvotes { get; set; }
        public ComponentType Type { get; set; }
    }
}
