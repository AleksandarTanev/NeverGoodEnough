namespace NeverGoodEnough.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using NeverGoodEnough.Data.Interfaces;
    using NeverGoodEnough.Models;
    using NeverGoodEnough.Models.BindingModels.GameVictoryConditions;
    using NeverGoodEnough.Models.EntityModels;
    using NeverGoodEnough.Models.ViewModels.GameVictoryConditions;
    using NeverGoodEnough.Services.Interfaces;

    public class GameVictoryConditionsService : Service, IGameVictoryConditionsService
    {
        public GameVictoryConditionsService() : base()
        {

        }

        public GameVictoryConditionsService(INeverGoodEnoughContext context) : base(context)
        {
        }

        public IEnumerable<AllGameVictoryConditionVm> GetAllGameMechanics(string userId)
        {
            var engineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);

            if (engineer == null)
            {
                throw new Exception("Engineer not found!");
            }

            var mechanics = this.Context.GameVictoryConditions.Where(g => g.Engineer.Id == engineer.Id);
            
            return Mapper.Instance.Map<IEnumerable<GameVictoryCondition>, IEnumerable<AllGameVictoryConditionVm>>(mechanics);
        }

        public DetailsGameVictoryConditionVm GetDetailsGameVictoryCondition(int? gameVConditionId)
        {
            GameVictoryCondition gameVCondition = this.Context.GameVictoryConditions.Find(gameVConditionId);
            if (gameVCondition == null)
            {
                throw new Exception("Victory Condition not found!");
            }

            DetailsGameVictoryConditionVm vm = Mapper.Instance.Map<GameVictoryCondition, DetailsGameVictoryConditionVm>(gameVCondition);
            if (string.IsNullOrEmpty(vm.ImageUrl))
            {
                vm.ImageUrl = Constants.DefaultImageUrl;
            }

            return vm;
        }

        public void CreateGameVictoryConditioc(CreateGameVictoryConditionBm bm, string userId)
        {
            var engineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);
            if (engineer == null)
            {
                throw new Exception("Engineer not found!");
            }

            var gameVCondition = Mapper.Instance.Map<CreateGameVictoryConditionBm, GameVictoryCondition>(bm);
            gameVCondition.CreationDate = DateTime.Now;

            engineer.GameVictoryConditions.Add(gameVCondition);

            this.Context.SaveChanges();
        }

        public EditGameVictoryConditionVm GetEditGameVictoryConditio(int? gameVConditionId)
        {
            GameVictoryCondition gameVCondition = this.Context.GameVictoryConditions.Find(gameVConditionId);
            if (gameVCondition == null)
            {
                throw new Exception("Victory Condition not found!");
            }

            return Mapper.Instance.Map<GameVictoryCondition, EditGameVictoryConditionVm>(gameVCondition);
        }

        public void EditGameVictoryConditio(EditGameVictoryConditionBm bm)
        {
            GameVictoryCondition gameVCondition = this.Context.GameVictoryConditions.Find(bm.Id);
            if (gameVCondition == null)
            {
                throw new Exception("Victory Condition not found!");
            }

            gameVCondition.Name = bm.Name;
            gameVCondition.Description = bm.Description;

            if (!string.IsNullOrEmpty(bm.ImageUrl))
            {
                gameVCondition.ImageUrl = bm.ImageUrl;
            }

            if (!string.IsNullOrEmpty(bm.Tags))
            {
                gameVCondition.Tags = bm.Tags;
            }

            this.Context.SaveChanges();
        }

        public DeleteGameVictoryConditionVm GetDeleteGameVictoryCondition(int? gameVConditionId)
        {
            GameVictoryCondition gameVCondition = this.Context.GameVictoryConditions.Find(gameVConditionId);
            if (gameVCondition == null)
            {
                throw new Exception("Victory Condition not found!");
            }

            return Mapper.Instance.Map<GameVictoryCondition, DeleteGameVictoryConditionVm>(gameVCondition);
        }

        public void DeleteGameVictoryCondition(int? id)
        {
            GameVictoryCondition gameVCondition = this.Context.GameVictoryConditions.Find(id);
            if (gameVCondition == null)
            {
                throw new Exception("Victory Condition not found!");
            }

            this.Context.GameVictoryConditions.Remove(gameVCondition);
            this.Context.SaveChanges();
        }
    }
}
