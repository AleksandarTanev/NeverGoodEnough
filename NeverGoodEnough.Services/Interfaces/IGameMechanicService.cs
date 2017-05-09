namespace NeverGoodEnough.Services.Interfaces
{
    using System.Collections.Generic;
    using NeverGoodEnough.Models.BindingModels.GameMechanic;
    using NeverGoodEnough.Models.ViewModels.GameMechanic;

    public interface IGameMechanicService
    {
        IEnumerable<AllPersonalGameMechanicVm> GetAllGameMechanics(string userId);
        DetailsGameMechanicVm GetDetailGameMechanic(int? gameMechanicId);
        void CreateGameMechanic(CreateGameMechanicBm bm, string userId);
        EditGameMechanicVm GetEditGameMechanic(int? gameMechanicId);
        void EditGameMechanic(EditGameMechanicBm bm);
        DeleteGameMechanicVm GetDeleteGameMechanic(int? gameMechanicId);
        void DeleteGameMechanic(int? id);
    }
}