namespace NeverGoodEnough.Services.Interfaces
{
    using System.Collections.Generic;
    using NeverGoodEnough.Models.BindingModels.GameVictoryConditions;
    using NeverGoodEnough.Models.ViewModels.GameVictoryConditions;

    public interface IGameVictoryConditionsService
    {
        IEnumerable<AllGameVictoryConditionVm> GetAllGameMechanics(string userId);
        DetailsGameVictoryConditionVm GetDetailsGameVictoryCondition(int? gameVConditionId);
        void CreateGameVictoryConditioc(CreateGameVictoryConditionBm bm, string userId);
        EditGameVictoryConditionVm GetEditGameVictoryConditio(int? gameVConditionId);
        void EditGameVictoryConditio(EditGameVictoryConditionBm bm);
        DeleteGameVictoryConditionVm GetDeleteGameVictoryCondition(int? gameVConditionId);
        void DeleteGameVictoryCondition(int? id);
    }
}