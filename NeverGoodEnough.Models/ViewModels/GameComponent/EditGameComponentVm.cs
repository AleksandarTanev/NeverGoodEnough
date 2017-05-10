namespace NeverGoodEnough.Models.ViewModels.GameMechanic
{
    using System.ComponentModel.DataAnnotations;
    using NeverGoodEnough.Models.Enums;

    public class EditGameComponentVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Tags { get; set; }

        public ComponentType Type { get; set; }

    }
}
