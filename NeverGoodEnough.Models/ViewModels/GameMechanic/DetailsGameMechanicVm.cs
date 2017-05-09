namespace NeverGoodEnough.Models.ViewModels.GameMechanic
{
    using System;

    public class DetailsGameMechanicVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Tags { get; set; }

        public DateTime CreationDate { get; set; }

        public int Upvotes { get; set; }
    }
}
