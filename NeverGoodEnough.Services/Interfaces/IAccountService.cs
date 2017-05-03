namespace NeverGoodEnough.Services
{
    using NeverGoodEnough.Models.EntityModels;

    public interface IAccountService
    {
        void CreateEngineer(ApplicationUser user);
    }
}