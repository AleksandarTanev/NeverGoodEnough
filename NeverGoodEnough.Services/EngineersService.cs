namespace NeverGoodEnough.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using NeverGoodEnough.Data.Interfaces;
    using NeverGoodEnough.Models.EntityModels;
    using NeverGoodEnough.Models.ViewModels;
    using NeverGoodEnough.Services.Interfaces;

    public class EngineersService : Service, IEngineersService
    {
        public EngineersService() : base()
        {

        }

        public EngineersService(INeverGoodEnoughContext context) : base(context)
        {
        }

        public IEnumerable<AllEngineerVm> GetAllEngineers()
        {
            var engineers = this.Context.Engineers.ToList();

            return Mapper.Instance.Map<IEnumerable<Engineer>, IEnumerable<AllEngineerVm>>(engineers);
        }
    }
}
