namespace NeverGoodEnough.Services.Interfaces
{
    using System.Collections.Generic;
    using NeverGoodEnough.Models.BindingModels.GameObject;
    using NeverGoodEnough.Models.ViewModels.GameObject;

    public interface IGameObjectService
    {
        IEnumerable<AllGameObjectVm> GetAllGameObject();
        IEnumerable<MyAllGameObjectVm> GetAllGameObject(string userId);
        DetailsGameObjectVm GetDetailGameObject(int? gameMechanicId);
        void CreateGameObject(CreateGameObjectBm bm, string userId);
        EditGameObjectVm GetEditGameObject(int? gameMechanicId);
        void EditGameObject(EditGameObjectBm bm);
        DeleteGameObjectVm GetDeleteGameObject(int? gameMechanicId);
        void DeleteGameObject(int? id);
    }
}
