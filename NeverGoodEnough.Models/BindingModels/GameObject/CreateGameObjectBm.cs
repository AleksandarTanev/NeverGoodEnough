﻿namespace NeverGoodEnough.Models.BindingModels.GameObject
{
    using System.ComponentModel.DataAnnotations;

    public class CreateGameObjectBm
    {
        [MinLength(3), Required]
        public string Name { get; set; }

        [StringLength(3000), Required]
        public string Description { get; set; }
    }
}