namespace NeverGoodEnough.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using NeverGoodEnough.Models.EntityModels;

    public class NeverGoodEnoughContext : IdentityDbContext<ApplicationUser>
    {
        public NeverGoodEnoughContext()
            : base("data source=(LocalDb)\\MSSQLLocalDB;initial catalog=NeverGoodEnough;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", throwIfV1Schema: false)
        {
        }

        public static NeverGoodEnoughContext Create()
        {
            return new NeverGoodEnoughContext();
        }
    }
}