namespace NeverGoodEnough.Services
{
    using NeverGoodEnough.Data.Interfaces;
    using NeverGoodEnough.Models.EntityModels;
    using NeverGoodEnough.Services.Interfaces;

    public class AccountService : Service, IAccountService
    {
        public AccountService() : base()
        {

        }

        public AccountService(INeverGoodEnoughContext context) : base(context)
        {
        }

        public void CreateEngineer(ApplicationUser user)
        {
            var newEngineer = new Engineer();
            ApplicationUser appUser = this.Context.Users.Find(user.Id);

            newEngineer.User = appUser;

            this.Context.Engineers.Add(newEngineer);
            this.Context.SaveChanges();
        }
    }
}
