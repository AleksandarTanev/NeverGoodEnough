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

    public class GameMechanicService : Service, IGameMechanicService
    {
        public GameMechanicService() : base()
        {

        }

        public GameMechanicService(INeverGoodEnoughContext context) : base(context)
        {
        }

        public IEnumerable<AllPersonalGameMechanicVm> GetAllGameMechanics()
        {
            var mechanics = this.Context.GameMechanics.ToList();

            return Mapper.Instance.Map<IEnumerable<GameMechanic>, IEnumerable<AllPersonalGameMechanicVm>>(mechanics);
        }

        public IEnumerable<MyAllPersonalGameMechanicVm> GetAllGameMechanics(string userId)
        {
            var engineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);

            if (engineer == null)
            {
                throw new Exception("Engineer not found!");
            }

            var mechanics = this.Context.GameMechanics.Where(g => g.Engineer.Id == engineer.Id);

            return Mapper.Instance.Map<IEnumerable<GameMechanic>, IEnumerable<MyAllPersonalGameMechanicVm>>(mechanics);
        }

        public DetailsGameMechanicVm GetDetailGameMechanic(int? gameMechanicId)
        {
            GameMechanic gameMechanic = this.Context.GameMechanics.Find(gameMechanicId);

            if (gameMechanic == null)
            {
                throw new Exception("Mechanic not found!");
            }

            DetailsGameMechanicVm vm = Mapper.Instance.Map<GameMechanic, DetailsGameMechanicVm>(gameMechanic);
            if (string.IsNullOrEmpty(vm.ImageUrl))
            {
                vm.ImageUrl = Constants.DefaultImageUrl;
            }

            return vm;
        }

        public void CreateGameMechanic(CreateGameMechanicBm bm, string userId)
        {
            var engineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);
            if (engineer == null)
            {
                throw new Exception("Engineer not found!");
            }

            var gameMechanic = Mapper.Instance.Map<CreateGameMechanicBm, GameMechanic>(bm);
            gameMechanic.CreationDate = DateTime.Now;

            engineer.GameMechanics.Add(gameMechanic);

            this.Context.SaveChanges();
        }

        public EditGameMechanicVm GetEditGameMechanic(int? gameMechanicId)
        {
            GameMechanic gameMechanic = this.Context.GameMechanics.Find(gameMechanicId);
            if (gameMechanic == null)
            {
                throw new Exception("Mechanic not found!");
            }

            return Mapper.Instance.Map<GameMechanic, EditGameMechanicVm>(gameMechanic);
        }

        public void EditGameMechanic(EditGameMechanicBm bm)
        {
            GameMechanic gameMechanic = this.Context.GameMechanics.Find(bm.Id);
            if (gameMechanic == null)
            {
                throw new Exception("Mechanic not found!");
            }

            gameMechanic.Name = bm.Name;
            gameMechanic.Description = bm.Description;

            if (!string.IsNullOrEmpty(bm.ImageUrl))
            {
                gameMechanic.ImageUrl = bm.ImageUrl;
            }

            if (!string.IsNullOrEmpty(bm.Tags))
            {
                gameMechanic.Tags = bm.Tags;
            }

            this.Context.SaveChanges();
        }

        public DeleteGameMechanicVm GetDeleteGameMechanic(int? gameMechanicId)
        {
            GameMechanic gameMechanic = this.Context.GameMechanics.Find(gameMechanicId);
            if (gameMechanic == null)
            {
                throw new Exception("Mechanic not found!");
            }

            return Mapper.Instance.Map<GameMechanic, DeleteGameMechanicVm>(gameMechanic);
        }

        public void DeleteGameMechanic(int? id)
        {
            GameMechanic gameMechanic = this.Context.GameMechanics.Find(id);
            if (gameMechanic == null)
            {
                throw new Exception("Mechanic not found!");
            }

            this.Context.GameMechanics.Remove(gameMechanic);
            this.Context.SaveChanges();
        }
    }
}