namespace NeverGoodEnough.Models.ViewModels.GameObject
{
    using System.ComponentModel.DataAnnotations;

    public class EditGameObjectVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Tags { get; set; }
    }
}
