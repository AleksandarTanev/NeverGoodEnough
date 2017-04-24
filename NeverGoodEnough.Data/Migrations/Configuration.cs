namespace NeverGoodEnough.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using NeverGoodEnough.Models.EntityModels;

    internal sealed class Configuration : DbMigrationsConfiguration<NeverGoodEnough.Data.NeverGoodEnoughContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NeverGoodEnough.Data.NeverGoodEnoughContext context)
        {
            context.GameMechanics.AddOrUpdate(gm => gm.Name,
                new GameMechanic()
                {
                    Name = "First",
                    Description = "Play first person"
                },
                new GameMechanic()
                {
                    Name = "Second",
                    Description = "Play second person"
                },
                new GameMechanic()
                {
                    Name = "Third",
                    Description = "Play third person"
                });
        }
    }
}
