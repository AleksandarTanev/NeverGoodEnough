namespace NeverGoodEnough.Models.BindingModels.GameMechanic
{
    using System.ComponentModel.DataAnnotations;

    public class CreateGameMechanicBm
    {
        [MinLength(3), Required]
        public string Name { get; set; }

        [StringLength(3000), Required]
        public string Description { get; set; }
    }
}
