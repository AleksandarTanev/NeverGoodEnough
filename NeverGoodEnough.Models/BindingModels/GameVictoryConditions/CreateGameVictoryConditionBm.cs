namespace NeverGoodEnough.Models.BindingModels.GameVictoryConditions
{
    using System.ComponentModel.DataAnnotations;

    public class CreateGameVictoryConditionBm
    {
        [MinLength(3), Required]
        public string Name { get; set; }

        [StringLength(3000), Required]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Tags { get; set; }
    }
}
