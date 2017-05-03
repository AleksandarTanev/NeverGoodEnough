namespace NeverGoodEnough.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using NeverGoodEnough.Models.BindingModels.GameMechanic;
    using NeverGoodEnough.Models.EntityModels;
    using NeverGoodEnough.Models.ViewModels.GameMechanic;
    using NeverGoodEnough.Services.Interfaces;

    public class GameMechanicService : Service, IGameMechanicService
    {
        public IEnumerable<AllGameMechanicVm> GetAllGameMechanics(string userId)
        {
            var engineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);

            if (engineer == null)
            {
                throw new Exception();
            }

            var mechanics = this.Context.GameMechanics.Where(g => g.Engineer.Id == engineer.Id);
            
            return Mapper.Instance.Map<IEnumerable<GameMechanic>, IEnumerable<AllGameMechanicVm>>(mechanics);
        }

        public DetailsGameMechanicVm GetDetailGameMechanic(int? gameMechanicId)
        {
            GameMechanic gameMechanic = this.Context.GameMechanics.Find(gameMechanicId);

            return Mapper.Instance.Map<GameMechanic, DetailsGameMechanicVm>(gameMechanic);
        }

        public void CreateGameMechanic(CreateGameMechanicBm bm, string userId)
        {
            var engineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);
            var gameMechanic = Mapper.Instance.Map<CreateGameMechanicBm, GameMechanic>(bm);
            gameMechanic.CreationDate = DateTime.Now;

            engineer.GameMechanics.Add(gameMechanic);

            this.Context.SaveChanges();
        }

        public EditGameMechanicVm GetEditGameMechanic(int? gameMechanicId)
        {
            GameMechanic gameMechanic = this.Context.GameMechanics.Find(gameMechanicId);

            return Mapper.Instance.Map<GameMechanic, EditGameMechanicVm>(gameMechanic);
        }

        public void EditGameMechanic(EditGameMechanicBm bm)
        {
            GameMechanic gameMechanic = this.Context.GameMechanics.Find(bm.Id);

            gameMechanic.Name = bm.Name;
            gameMechanic.Description = bm.Description;

            this.Context.SaveChanges();
        }

        public DeleteGameMechanicVm GetDeleteGameMechanic(int? gameMechanicId)
        {
            GameMechanic gameMechanic = this.Context.GameMechanics.Find(gameMechanicId);

            return Mapper.Instance.Map<GameMechanic, DeleteGameMechanicVm>(gameMechanic);
        }

        public void DeleteGameMechanic(int? id)
        {
            GameMechanic gameMechanic = this.Context.GameMechanics.Find(id);
            this.Context.GameMechanics.Remove(gameMechanic);
            this.Context.SaveChanges();
        }
    }
}
