namespace NeverGoodEnough.Models.BindingModels.GameMechanic
{
    using System.ComponentModel.DataAnnotations;
    using NeverGoodEnough.Models.Enums;

    public class CreateGameComponentBm
    {
        [MinLength(3), Required]
        public string Name { get; set; }

        [StringLength(3000), Required]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Tags { get; set; }

        [Required]
        public ComponentType Type { get; set; }
    }
}
