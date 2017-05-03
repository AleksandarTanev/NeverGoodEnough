namespace NeverGoodEnough.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using NeverGoodEnough.Models.EntityModels;
    using NeverGoodEnough.Models.ViewModels;
    using NeverGoodEnough.Services.Interfaces;

    public class EngineersService : Service, IEngineersService
    {
        public IEnumerable<AllEngineerVm> GetAllEngineers()
        {
            var engineers = this.Context.Engineers.ToList();

            return Mapper.Instance.Map<IEnumerable<Engineer>, IEnumerable<AllEngineerVm>>(engineers);
        }
    }
}
