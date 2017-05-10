namespace NeverGoodEnough.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using NeverGoodEnough.Models.Enums;

    public class GameComponent
    {
        public GameComponent()
        {
            this.Games = new HashSet<Game>();
        }

        public int Id { get; set; }

        [MinLength(3), Required]
        public string Name { get; set; }

        [StringLength(3000), Required]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsPrivate { get; set; }

        public string Tags { get; set; }

        public int Upvotes { get; set; }

        [Required]
        public ComponentType Type { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public virtual Engineer Engineer { get; set; }
    }
}
