namespace NeverGoodEnough.Models.EntityModels
{
    using System.Collections.Generic;

    public class Engineer
    {
        public Engineer()
        {
            this.Games = new HashSet<Game>();
            this.GameMechanics = new HashSet<GameMechanic>();
            this.GameVictoryConditions = new HashSet<GameVictoryCondition>();
        }

        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public virtual ICollection<GameMechanic> GameMechanics { get; set; }

        public virtual ICollection<GameVictoryCondition> GameVictoryConditions { get; set; }
    }
}
