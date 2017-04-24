namespace NeverGoodEnough.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NeverGoodEnough.Models.EntityModels;

    public class NeverGoodEnoughContext : IdentityDbContext<ApplicationUser>
    {
        public NeverGoodEnoughContext()
            : base("data source=.;initial catalog=NeverGoodEnough;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", throwIfV1Schema: false)
        {
        }

        public DbSet<GameMechanic> GameMechanics { get; set; }

        public static NeverGoodEnoughContext Create()
        {
            return new NeverGoodEnoughContext();
        }
    }
}