namespace NeverGoodEnough.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Models.ViewModels.Games;
    using NeverGoodEnough.Models.BindingModels.Game;
    using NeverGoodEnough.Models.EntityModels;
    using NeverGoodEnough.Models.ViewModels.GameMechanic;
    using NeverGoodEnough.Models.ViewModels.GameVictoryConditions;

    public class GamesService : Service, IGamesService
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

        public DetailsGameVm GetDetailGame(int? gameId)
        {
            Game game = this.Context.Games.Find(gameId);

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
            var game = Mapper.Instance.Map<CreateGameBm, Game>(bm);
            game.CreationDate = DateTime.Now;

            engineer.Games.Add(game);

            this.Context.SaveChanges();
        }

        public EditGameVm GetEditGame(int? Id)
        {
            Game game = this.Context.Games.Find(Id);

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

            game.Name = bm.Name;
            game.Description = bm.Description;

            this.Context.SaveChanges();
        }

        public DeleteGameVm GetDeleteGame(int? id)
        {
            Game game = this.Context.Games.Find(id);

            return Mapper.Instance.Map<Game, DeleteGameVm>(game);
        }

        public void DeleteGame(int? id)
        {
            Game game = this.Context.Games.Find(id);
            this.Context.Games.Remove(game);
            this.Context.SaveChanges();
        }

        public void AddMechanicToGame(int gameId, int mechanicId, string userId)
        {
            var currentEngineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);

            Game game = this.Context.Games.Find(gameId);
            GameMechanic gameMechanic = this.Context.GameMechanics.Find(mechanicId);

            if (game == null)
            {
                throw new Exception();
            }
            else if (gameMechanic == null)
            {
                throw new Exception();
            }

            if (game.Engineer.Id != currentEngineer.Id || gameMechanic.Engineer.Id != currentEngineer.Id)
            {
                throw new Exception();
            }

            game.GameMechanics.Add(gameMechanic);
            this.Context.SaveChanges();
        }

        public void AddVictoryConditionToGame(int gameId, int victoryConditionId, string userId)
        {
            var currentEngineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);

            Game game = this.Context.Games.Find(gameId);
            GameVictoryCondition gameVictoryCondition = this.Context.GameVictoryConditions.Find(victoryConditionId);

            if (game == null)
            {
                throw new Exception();
            }
            else if (gameVictoryCondition == null)
            {
                throw new Exception();
            }

            if (game.Engineer.Id != currentEngineer.Id || gameVictoryCondition.Engineer.Id != currentEngineer.Id)
            {
                throw new Exception();
            }

            game.GameVictoryConditions.Add(gameVictoryCondition);
            this.Context.SaveChanges();
        }

        public void RemoveMechanicFromGame(int gameId, int mechanicId, string userId)
        {
            var currentEngineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);

            Game game = this.Context.Games.Find(gameId);
            GameMechanic gameMechanic = this.Context.GameMechanics.Find(mechanicId);

            if (game == null)
            {
                throw new Exception();
            }
            else if (gameMechanic == null)
            {
                throw new Exception();
            }

            if (game.Engineer.Id != currentEngineer.Id || gameMechanic.Engineer.Id != currentEngineer.Id)
            {
                throw new Exception();
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

            Game game = this.Context.Games.Find(gameId);
            GameVictoryCondition gameVictoryCondition = this.Context.GameVictoryConditions.Find(victoryConditionId);

            if (game == null)
            {
                throw new Exception();
            }
            else if (gameVictoryCondition == null)
            {
                throw new Exception();
            }

            if (game.Engineer.Id != currentEngineer.Id || gameVictoryCondition.Engineer.Id != currentEngineer.Id)
            {
                throw new Exception();
            }

            if (game.GameVictoryConditions.Contains(gameVictoryCondition))
            {
                game.GameVictoryConditions.Remove(gameVictoryCondition);
                this.Context.SaveChanges();
            }
        }
    }
}
