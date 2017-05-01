namespace NeverGoodEnough.Models.EntityModels
{
    using System;
    using System.Collections.Generic;

    public class Game
    {
        public Game()
        {
            this.GameMechanics = new HashSet<GameMechanic>();
            this.GameVictoryConditions = new HashSet<GameVictoryCondition>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<GameMechanic> GameMechanics { get; set; }

        public virtual ICollection<GameVictoryCondition> GameVictoryConditions { get; set; }

        public virtual Engineer Engineer { get; set; }
    }
}
