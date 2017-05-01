namespace NeverGoodEnough.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using NeverGoodEnough.Models.BindingModels.GameVictoryConditions;
    using NeverGoodEnough.Models.EntityModels;
    using NeverGoodEnough.Models.ViewModels.GameVictoryConditions;

    public class GameVictoryConditionsService : Service, IGameVictoryConditionsService
    {
        public IEnumerable<AllGameVictoryConditionVm> GetAllGameMechanics(string userId)
        {
            var engineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);

            if (engineer == null)
            {
                throw new Exception();
            }

            var mechanics = this.Context.GameVictoryConditions.Where(g => g.Engineer.Id == engineer.Id);
            
            //var mechanics = this.Context.GameVictoryConditions.ToList();

            return Mapper.Instance.Map<IEnumerable<GameVictoryCondition>, IEnumerable<AllGameVictoryConditionVm>>(mechanics);
        }

        public DetailsGameVictoryConditionVm GetDetailsGameVictoryCondition(int? gameVConditionId)
        {
            GameVictoryCondition gameMechanic = this.Context.GameVictoryConditions.Find(gameVConditionId);

            return Mapper.Instance.Map<GameVictoryCondition, DetailsGameVictoryConditionVm>(gameMechanic);
        }

        public void CreateGameVictoryConditioc(CreateGameVictoryConditionBm bm, string userId)
        {
            var engineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);

            var gameVCondition = Mapper.Instance.Map<CreateGameVictoryConditionBm, GameVictoryCondition>(bm);
            gameVCondition.CreationDate = DateTime.Now;

           // this.Context.GameVictoryConditions.Add(gameVCondition);

           // gameVCondition.Engineer = engineer;
            engineer.GameVictoryConditions.Add(gameVCondition);

            this.Context.SaveChanges();
        }

        public EditGameVictoryConditionVm GetEditGameVictoryConditio(int? gameVConditionId)
        {
            GameVictoryCondition gameMechanic = this.Context.GameVictoryConditions.Find(gameVConditionId);

            return Mapper.Instance.Map<GameVictoryCondition, EditGameVictoryConditionVm>(gameMechanic);
        }

        public void EditGameVictoryConditio(EditGameVictoryConditionBm bm)
        {
            GameVictoryCondition gameVCondition = this.Context.GameVictoryConditions.Find(bm.Id);

            gameVCondition.Name = bm.Name;
            gameVCondition.Description = bm.Description;

            this.Context.SaveChanges();
        }

        public DeleteGameVictoryConditionVm GetDeleteGameVictoryCondition(int? gameVConditionId)
        {
            GameVictoryCondition gameMechanic = this.Context.GameVictoryConditions.Find(gameVConditionId);

            return Mapper.Instance.Map<GameVictoryCondition, DeleteGameVictoryConditionVm>(gameMechanic);
        }

        public void DeleteGameVictoryCondition(int? id)
        {
            GameVictoryCondition gameMechanic = this.Context.GameVictoryConditions.Find(id);
            this.Context.GameVictoryConditions.Remove(gameMechanic);
            this.Context.SaveChanges();
        }
    }
}
