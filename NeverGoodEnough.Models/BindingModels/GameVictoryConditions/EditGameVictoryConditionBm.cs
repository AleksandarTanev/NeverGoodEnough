namespace NeverGoodEnough.Models.BindingModels.GameVictoryConditions
{
    using System.ComponentModel.DataAnnotations;

    public class EditGameVictoryConditionBm
    {
        [Required]
        public int Id { get; set; }

        [MinLength(3), Required]
        public string Name { get; set; }

        [StringLength(3000), Required]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Tags { get; set; }
    }
}
