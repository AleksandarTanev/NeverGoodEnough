namespace NeverGoodEnough.Models.ViewModels.Games
{
    using System;
    using System.Collections.Generic;
    using NeverGoodEnough.Models.ViewModels.GameMechanic;

    public class DetailsGameVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<DetailsGameComponentVm> GameMechanics { get; set; }

    }
}
