namespace NeverGoodEnough.Services
{
    using System.Collections.Generic;
    using NeverGoodEnough.Models.BindingModels.Game;
    using NeverGoodEnough.Models.ViewModels.Games;

    public interface IGamesService
    {
        IEnumerable<AllGameVm> GetAllGames(string userId);
        DetailsGameVm GetDetailGame(int? gameId);
        void CreateGame(CreateGameBm bm, string userId);
        EditGameVm GetEditGame(int? gameId);
        void EditGame(EditGameBm bm);
        DeleteGameVm GetDeleteGame(int? id);
        void DeleteGame(int? id);
    }
}