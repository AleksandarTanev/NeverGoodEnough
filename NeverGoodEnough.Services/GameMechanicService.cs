namespace NeverGoodEnough.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using NeverGoodEnough.Models.EntityModels;
    using NeverGoodEnough.Models.ViewModels.GameMechanic;

    public class GameMechanicService : Service
    {
        public IEnumerable<AllGameMechanicVm> GetAllGameMechanics(int userId)
        {

            var mechanics = this.Context.GameMechanics.ToList();

            return Mapper.Instance.Map<IEnumerable<GameMechanic>, IEnumerable<AllGameMechanicVm>>(mechanics);
        }

        public AllGameMechanicVm GetGameMechanicDetailes(int gameMechanicId)
        {
            return null;
        }
    }
}
