namespace NeverGoodEnough.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<NeverGoodEnough.Data.NeverGoodEnoughContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NeverGoodEnough.Data.NeverGoodEnoughContext context)
        {
            if (!context.Roles.Any(role => role.Name == "Engineer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Engineer");
                manager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Admin");
                manager.Create(role);
            }

            /*context.GameMechanics.AddOrUpdate(gm => gm.Name,
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
                });*/
        }
    }
}
