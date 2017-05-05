namespace NeverGoodEnough.Data.Interfaces
{
    using System.Data.Entity;
    using System.Security.Principal;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NeverGoodEnough.Models.EntityModels;

    public interface INeverGoodEnoughContext : IIdentity
    {
        DbSet<Engineer> Engineers { get; set; }
        DbSet<Game> Games { get; set; }
        DbSet<GameMechanic> GameMechanics { get; set; }
        DbSet<GameVictoryCondition> GameVictoryConditions { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
        IDbSet<IdentityRole> Roles { get; set; }
        int SaveChanges();
    }
}
