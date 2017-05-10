namespace NeverGoodEnough.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using NeverGoodEnough.Data.Interfaces;
    using NeverGoodEnough.Models;
    using NeverGoodEnough.Models.BindingModels.GameMechanic;
    using NeverGoodEnough.Models.EntityModels;
    using NeverGoodEnough.Models.ViewModels.GameMechanic;
    using NeverGoodEnough.Services.Interfaces;

    public class GameComponentService : Service, IGameComponentService
    {
        public GameComponentService() : base()
        {

        }

        public GameComponentService(INeverGoodEnoughContext context) : base(context)
        {
        }

        public IEnumerable<AllPersonalGameComponentVm> GetAllGameComponents()
        {
            var component = this.Context.GameComponents.ToList();

            return Mapper.Instance.Map<IEnumerable<GameComponent>, IEnumerable<AllPersonalGameComponentVm>>(component);
        }

        public IEnumerable<MyAllPersonalGameComponentVm> GetAllGameComponents(string userId)
        {
            var engineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);

            if (engineer == null)
            {
                throw new Exception("Engineer not found!");
            }

            var mechanics = this.Context.GameComponents.Where(g => g.Engineer.Id == engineer.Id);

            return Mapper.Instance.Map<IEnumerable<GameComponent>, IEnumerable<MyAllPersonalGameComponentVm>>(mechanics);
        }

        public DetailsGameComponentVm GetDetailGameComponent(int? gameMechanicId)
        {
            GameComponent gameComponent = this.Context.GameComponents.Find(gameMechanicId);

            if (gameComponent == null)
            {
                throw new Exception("Mechanic not found!");
            }

            DetailsGameComponentVm vm = Mapper.Instance.Map<GameComponent, DetailsGameComponentVm>(gameComponent);
            if (string.IsNullOrEmpty(vm.ImageUrl))
            {
                vm.ImageUrl = Constants.DefaultImageUrl;
            }

            return vm;
        }

        public void CreateGameComponent(CreateGameComponentBm bm, string userId)
        {
            var engineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);
            if (engineer == null)
            {
                throw new Exception("Engineer not found!");
            }

            var gameMechanic = Mapper.Instance.Map<CreateGameComponentBm, GameComponent>(bm);
            gameMechanic.CreationDate = DateTime.Now;

            if (string.IsNullOrEmpty(gameMechanic.ImageUrl))
            {
                gameMechanic.ImageUrl = Constants.DefaultImageUrl;
            }

            engineer.GameMechanics.Add(gameMechanic);

            this.Context.SaveChanges();
        }

        public EditGameComponentVm GetEditGameComponent(int? gameMechanicId)
        {
            GameComponent gameComponent = this.Context.GameComponents.Find(gameMechanicId);
            if (gameComponent == null)
            {
                throw new Exception("Mechanic not found!");
            }

            return Mapper.Instance.Map<GameComponent, EditGameComponentVm>(gameComponent);
        }

        public void EditGameComponent(EditGameComponentBm bm)
        {
            GameComponent gameComponent = this.Context.GameComponents.Find(bm.Id);
            if (gameComponent == null)
            {
                throw new Exception("Mechanic not found!");
            }

            gameComponent.Name = bm.Name;
            gameComponent.Description = bm.Description;
            gameComponent.Type = bm.Type;

            if (!string.IsNullOrEmpty(bm.ImageUrl))
            {
                gameComponent.ImageUrl = bm.ImageUrl;
            }

            if (!string.IsNullOrEmpty(bm.Tags))
            {
                gameComponent.Tags = bm.Tags;
            }

            this.Context.SaveChanges();
        }

        public DeleteGameComponentVm GetDeleteGameComponent(int? gameMechanicId)
        {
            GameComponent gameComponent = this.Context.GameComponents.Find(gameMechanicId);
            if (gameComponent == null)
            {
                throw new Exception("Mechanic not found!");
            }

            return Mapper.Instance.Map<GameComponent, DeleteGameComponentVm>(gameComponent);
        }

        public void DeleteGameComponent(int? id)
        {
            GameComponent gameComponent = this.Context.GameComponents.Find(id);
            if (gameComponent == null)
            {
                throw new Exception("Mechanic not found!");
            }

            this.Context.GameComponents.Remove(gameComponent);
            this.Context.SaveChanges();
        }

        public void AddToGame(int componentId, int gameId)
        {
            Game game = this.Context.Games.Find(gameId);
            if (game == null)
            {
                throw new Exception("Game not found!");
            }

            GameComponent gameComponent = this.Context.GameComponents.Find(componentId);
            if (gameComponent == null)
            {
                throw new Exception("Component not found!");
            }

            if (!game.GameComponents.Contains(gameComponent))
            {
                game.GameComponents.Add(gameComponent);
                this.Context.SaveChanges();
            }
        }
    }
}