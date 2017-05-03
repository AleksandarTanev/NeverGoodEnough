namespace NeverGoodEnough.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NeverGoodEnough.Models.EntityModels;

    public class NeverGoodEnoughContext : IdentityDbContext<ApplicationUser>
    {
        public NeverGoodEnoughContext()
            //: base("data source=.;initial catalog=NeverGoodEnough;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", throwIfV1Schema: false)
            : base("Server=06a9b09a-1d8b-4be5-a6e3-a75a00f5fa63.sqlserver.sequelizer.com;Database=db06a9b09a1d8b4be5a6e3a75a00f5fa63;User ID=vhnvawpgprabinwd;Password=hzQMMgVTNgebamERTt3FQ6SRNF24UY73KKXn87ARDUk3XHpyjss8MuAkQ78fn27X", throwIfV1Schema: false)
        {
        }

        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameMechanic> GameMechanics { get; set; }
        public DbSet<GameVictoryCondition> GameVictoryConditions { get; set; }

        public static NeverGoodEnoughContext Create()
        {
            return new NeverGoodEnoughContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>()
               .HasMany<GameMechanic>(s => s.GameMechanics)
               .WithMany(c => c.Games)
               .Map(cs =>
               {
                   cs.MapLeftKey("GameId");
                   cs.MapRightKey("GameMechanicId");
                   cs.ToTable("GameGameMechanic");
               });

            modelBuilder.Entity<Game>()
               .HasMany<GameVictoryCondition>(s => s.GameVictoryConditions)
               .WithMany(c => c.Games)
               .Map(cs =>
               {
                   cs.MapLeftKey("GameId");
                   cs.MapRightKey("GameVictoryConditionId");
                   cs.ToTable("GameGameVictoryCondition");
               });
        }
    }
}