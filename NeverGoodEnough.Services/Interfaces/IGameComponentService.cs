namespace NeverGoodEnough.Services.Interfaces
{
    using System.Collections.Generic;
    using NeverGoodEnough.Models.BindingModels.GameMechanic;
    using NeverGoodEnough.Models.ViewModels.GameMechanic;

    public interface IGameComponentService
    {
        IEnumerable<AllPersonalGameComponentVm> GetAllGameComponents();
        IEnumerable<MyAllPersonalGameComponentVm> GetAllGameComponents(string userId);
        DetailsGameComponentVm GetDetailGameComponent(int? gameMechanicId);
        void CreateGameComponent(CreateGameComponentBm bm, string userId);
        EditGameComponentVm GetEditGameComponent(int? gameMechanicId);
        void EditGameComponent(EditGameComponentBm bm);
        DeleteGameComponentVm GetDeleteGameComponent(int? gameMechanicId);
        void DeleteGameComponent(int? id);
        void AddToGame(int componentId, int gameId);
    }
}