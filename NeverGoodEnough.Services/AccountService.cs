namespace NeverGoodEnough.Services
{
    using NeverGoodEnough.Models.EntityModels;

    public class AccountService : Service
    {
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
