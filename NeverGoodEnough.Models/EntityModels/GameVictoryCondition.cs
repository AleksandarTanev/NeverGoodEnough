namespace NeverGoodEnough.Models.EntityModels
{
    using System.Collections.Generic;

    public class GameVictoryCondition
    {
        public GameVictoryCondition()
        {
            this.Games = new HashSet<Game>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public virtual Engineer Engineer { get; set; }
    }
}
