namespace NeverGoodEnough.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Models.ViewModels.Games;
    using NeverGoodEnough.Data.Interfaces;
    using NeverGoodEnough.Models.BindingModels.Game;
    using NeverGoodEnough.Models.EntityModels;
    using NeverGoodEnough.Models.ViewModels.GameMechanic;
    using NeverGoodEnough.Models.ViewModels.GameVictoryConditions;
    using NeverGoodEnough.Services.Interfaces;

    public class GamesService : Service, IGamesService
    {
        public GamesService() : base()
        {

        }

        public GamesService(INeverGoodEnoughContext context) : base(context)
        {
        }

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

        public DetailsGameVm GetDetailGame(int? gameId)
        {
            Game game = this.Context.Games.Find(gameId);
            if (game == null)
            {
                throw new Exception("Game not found!");
            }

            DetailsGameVm vm = new DetailsGameVm()
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                CreationDate = game.CreationDate
            };

            vm.GameMechanics = Mapper.Instance.Map<ICollection<GameMechanic>, ICollection<DetailsGameMechanicVm>>(game.GameMechanics);
            vm.GameVictoryConditions = Mapper.Instance.Map<ICollection<GameVictoryCondition>, ICollection<DetailsGameVictoryConditionVm>>(game.GameVictoryConditions);

            return vm;
        }

        public void CreateGame(CreateGameBm bm, string userId)
        {
            var engineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);
            if (engineer == null)
            {
                throw new Exception("Engineer not found!");
            }

            var game = Mapper.Instance.Map<CreateGameBm, Game>(bm);
            game.CreationDate = DateTime.Now;

            engineer.Games.Add(game);

            this.Context.SaveChanges();
        }

        public EditGameVm GetEditGame(int? Id)
        {
            Game game = this.Context.Games.Find(Id);
            if (game == null)
            {
                throw new Exception("Game not found!");
            }

            EditGameVm vm = new EditGameVm()
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                CreationDate = game.CreationDate
            };

            vm.GameMechanics = Mapper.Instance.Map<ICollection<GameMechanic>, ICollection<DetailsGameMechanicVm>>(game.GameMechanics);
            vm.GameVictoryConditions = Mapper.Instance.Map<ICollection<GameVictoryCondition>, ICollection<DetailsGameVictoryConditionVm>>(game.GameVictoryConditions);

            return vm;
        }

        public void EditGame(EditGameBm bm)
        {
            Game game = this.Context.Games.Find(bm.Id);
            if (game == null)
            {
                throw new Exception("Game not found!");
            }

            game.Name = bm.Name;
            game.Description = bm.Description;

            this.Context.SaveChanges();
        }

        public DeleteGameVm GetDeleteGame(int? id)
        {
            Game game = this.Context.Games.Find(id);
            if (game == null)
            {
                throw new Exception("Game not found!");
            }

            return Mapper.Instance.Map<Game, DeleteGameVm>(game);
        }

        public void DeleteGame(int? id)
        {
            Game game = this.Context.Games.Find(id);
            if (game == null)
            {
                throw new Exception("Game not found!");
            }

            this.Context.Games.Remove(game);
            this.Context.SaveChanges();
        }

        public void AddMechanicToGame(int gameId, int mechanicId, string userId)
        {
            var currentEngineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);
            if (currentEngineer == null)
            {
                throw new Exception("Engineer not found!");
            }

            Game game = this.Context.Games.Find(gameId);
            if (game == null)
            {
                throw new Exception("Game not found!");
            }

            GameMechanic gameMechanic = this.Context.GameMechanics.Find(mechanicId);
            if (gameMechanic == null)
            {
                throw new Exception("Mechanic not found!");
            }

            if (game.Engineer.Id != currentEngineer.Id || gameMechanic.Engineer.Id != currentEngineer.Id)
            {
                throw new Exception("Incorrect engineer!");
            }

            game.GameMechanics.Add(gameMechanic);
            this.Context.SaveChanges();
        }

        public void AddVictoryConditionToGame(int gameId, int victoryConditionId, string userId)
        {
            var currentEngineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);
            if (currentEngineer == null)
            {
                throw new Exception("Engineer not found!");
            }

            Game game = this.Context.Games.Find(gameId);
            if (game == null)
            {
                throw new Exception("Game not found!");
            }

            GameVictoryCondition gameVictoryCondition = this.Context.GameVictoryConditions.Find(victoryConditionId);
            if (gameVictoryCondition == null)
            {
                throw new Exception("Victory Condition not found!");
            }

            if (game.Engineer.Id != currentEngineer.Id || gameVictoryCondition.Engineer.Id != currentEngineer.Id)
            {
                throw new Exception("Incorrect engineer!");
            }

            game.GameVictoryConditions.Add(gameVictoryCondition);
            this.Context.SaveChanges();
        }

        public void RemoveMechanicFromGame(int gameId, int mechanicId, string userId)
        {
            var currentEngineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);
            if (currentEngineer == null)
            {
                throw new Exception("Engineer not found!");
            }

            Game game = this.Context.Games.Find(gameId);
            if (game == null)
            {
                throw new Exception("Game not found!");
            }

            GameMechanic gameMechanic = this.Context.GameMechanics.Find(mechanicId);
            if (gameMechanic == null)
            {
                throw new Exception("Mechanic not found!");
            }

            if (game.Engineer.Id != currentEngineer.Id || gameMechanic.Engineer.Id != currentEngineer.Id)
            {
                throw new Exception("Incorrect engineer!");
            }

            if (game.GameMechanics.Contains(gameMechanic))
            {
                game.GameMechanics.Remove(gameMechanic);
                this.Context.SaveChanges();
            }
        }

        public void RemoveVictoryConditionFromGame(int gameId, int victoryConditionId, string userId)
        {
            var currentEngineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);
            if (currentEngineer == null)
            {
                throw new Exception("Engineer not found!");
            }

            Game game = this.Context.Games.Find(gameId);
            if (game == null)
            {
                throw new Exception("Game not found!");
            }

            GameVictoryCondition gameVictoryCondition = this.Context.GameVictoryConditions.Find(victoryConditionId);
            if (gameVictoryCondition == null)
            {
                throw new Exception("Victory Condition not found!");
            }


            if (game.Engineer.Id != currentEngineer.Id || gameVictoryCondition.Engineer.Id != currentEngineer.Id)
            {
                throw new Exception("Incorrect engineer!");
            }

            if (game.GameVictoryConditions.Contains(gameVictoryCondition))
            {
                game.GameVictoryConditions.Remove(gameVictoryCondition);
                this.Context.SaveChanges();
            }
        }
    }
}
