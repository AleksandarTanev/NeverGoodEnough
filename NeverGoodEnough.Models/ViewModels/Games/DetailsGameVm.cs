namespace NeverGoodEnough.Models.ViewModels.Games
{
    using System;
    using System.Collections.Generic;
    using NeverGoodEnough.Models.ViewModels.GameMechanic;
    using NeverGoodEnough.Models.ViewModels.GameVictoryConditions;

    public class DetailsGameVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<DetailsGameMechanicVm> GameMechanics { get; set; }

        public virtual ICollection<DetailsGameVictoryConditionVm> GameVictoryConditions { get; set; }
    }
}
