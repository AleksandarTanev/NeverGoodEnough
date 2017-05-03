namespace NeverGoodEnough.Services.Interfaces
{
    using System.Collections.Generic;
    using NeverGoodEnough.Models.ViewModels;

    public interface IEngineersService
    {
        IEnumerable<AllEngineerVm> GetAllEngineers();
    }
}