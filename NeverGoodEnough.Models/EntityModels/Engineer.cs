namespace NeverGoodEnough.Models.EntityModels
{
    using System;
    using System.Collections.Generic;

    public class Engineer
    {
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public virtual ICollection<GameMechanic> GameMechanics { get; set; }

        public virtual ICollection<GameVictoryCondition> GameVictoryConditions { get; set; }
    }
}
