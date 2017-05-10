namespace NeverGoodEnough.Data.Mocks
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NeverGoodEnough.Data.Interfaces;
    using NeverGoodEnough.Models.EntityModels;

    public class FakeNeverGoodEnoughContext : INeverGoodEnoughContext
    {
        public FakeNeverGoodEnoughContext()
        {
            this.Engineers = new FakeEngineersDbSet();
            this.Games = new FakeGamesDbSet();
            this.GameComponents = new FakeGameComponentDbSet();
        }

        public DbSet<Engineer> Engineers { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<GameComponent> GameComponents { get; set; }

        public IDbSet<ApplicationUser> Users { get; set; }

        public IDbSet<IdentityRole> Roles { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public string Name { get; }
        public string AuthenticationType { get; }
        public bool IsAuthenticated { get; }
    }
}
