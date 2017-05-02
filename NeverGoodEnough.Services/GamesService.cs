namespace NeverGoodEnough.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Models.ViewModels.Games;
    using NeverGoodEnough.Models.EntityModels;

    public class GamesService : Service
    {
        public IEnumerable<AllGameVm> GetAllGames(string userId)
        {
            var engineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);

            if (engineer == null)
            {
                throw new Exception();
            }

            var game = this.Context.Games.Where(g => g.Engineer.Id == engineer.Id);

            return Mapper.Instance.Map<IEnumerable<Game>, IEnumerable<AllGameVm>>(game);
        }
    }
}
