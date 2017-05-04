namespace NeverGoodEnough.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        public Game()
        {
            this.GameMechanics = new HashSet<GameMechanic>();
            this.GameVictoryConditions = new HashSet<GameVictoryCondition>();
        }

        public int Id { get; set; }

        [MinLength(3), Required]
        public string Name { get; set; }

        [StringLength(3000), Required]
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<GameMechanic> GameMechanics { get; set; }

        public virtual ICollection<GameVictoryCondition> GameVictoryConditions { get; set; }

        public virtual Engineer Engineer { get; set; }
    }
}
