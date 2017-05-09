﻿namespace NeverGoodEnough.Models.ViewModels.GameVictoryConditions
{
    using System.ComponentModel.DataAnnotations;

    public class EditGameVictoryConditionVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Tags { get; set; }
    }
}
