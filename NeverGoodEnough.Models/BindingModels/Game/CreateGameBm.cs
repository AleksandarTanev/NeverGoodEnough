namespace NeverGoodEnough.Models.BindingModels.Game
{
    using System.ComponentModel.DataAnnotations;

    public class CreateGameBm
    {
        [MinLength(3), Required]
        public string Name { get; set; }

        [StringLength(3000), Required]
        public string Description { get; set; }
    }
}