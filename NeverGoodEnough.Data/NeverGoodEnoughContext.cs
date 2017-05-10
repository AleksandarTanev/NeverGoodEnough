namespace NeverGoodEnough.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NeverGoodEnough.Data.Interfaces;
    using NeverGoodEnough.Models.EntityModels;

    public class NeverGoodEnoughContext : IdentityDbContext<ApplicationUser>, INeverGoodEnoughContext
    {
        public NeverGoodEnoughContext()
            : base("NeverGoodEnough", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NeverGoodEnoughContext, NeverGoodEnough.Data.Migrations.Configuration>("NeverGoodEnough"));
        }

        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameComponent> GameComponents { get; set; }

        public static NeverGoodEnoughContext Create()
        {
            return new NeverGoodEnoughContext();
        }

        public string Name { get; }
        public string AuthenticationType { get; }
        public bool IsAuthenticated { get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>()
               .HasMany<GameComponent>(s => s.GameComponents)
               .WithMany(c => c.Games)
               .Map(cs =>
               {
                   cs.MapLeftKey("GameId");
                   cs.MapRightKey("GameComponentId");
                   cs.ToTable("GameGameComponent");
               });
        }
    }
}