namespace NeverGoodEnough.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using NeverGoodEnough.Data.Interfaces;
    using NeverGoodEnough.Models.BindingModels.GameObject;
    using NeverGoodEnough.Models.EntityModels;
    using NeverGoodEnough.Models.ViewModels.GameObject;
    using NeverGoodEnough.Services.Interfaces;
    public class GameObjectService : Service, IGameObjectService
    {
        public GameObjectService() : base()
        {

        }

        public GameObjectService(INeverGoodEnoughContext context) : base(context)
        {
        }

        public IEnumerable<AllGameObjectVm> GetAllGameObject(string userId)
        {
            var engineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);

            if (engineer == null)
            {
                throw new Exception("Engineer not found!");
            }

            var Objects = this.Context.GameObjects.Where(g => g.Engineer.Id == engineer.Id);

            return Mapper.Instance.Map<IEnumerable<GameObject>, IEnumerable<AllGameObjectVm>>(Objects);
        }

        public DetailsGameObjectVm GetDetailGameObject(int? gameObjectId)
        {
            GameObject gameObject = this.Context.GameObjects.Find(gameObjectId);

            if (gameObject == null)
            {
                throw new Exception("Object not found!");
            }

            return Mapper.Instance.Map<GameObject, DetailsGameObjectVm>(gameObject);
        }

        public void CreateGameObject(CreateGameObjectBm bm, string userId)
        {
            var engineer = this.Context.Engineers.FirstOrDefault(e => e.User.Id == userId);
            if (engineer == null)
            {
                throw new Exception("Engineer not found!");
            }

            var gameObject = Mapper.Instance.Map<CreateGameObjectBm, GameObject>(bm);
            gameObject.CreationDate = DateTime.Now;

            engineer.GameObjects.Add(gameObject);

            this.Context.SaveChanges();
        }

        public EditGameObjectVm GetEditGameObject(int? gameObjectId)
        {
            GameObject gameObject = this.Context.GameObjects.Find(gameObjectId);
            if (gameObject == null)
            {
                throw new Exception("Object not found!");
            }

            return Mapper.Instance.Map<GameObject, EditGameObjectVm>(gameObject);
        }

        public void EditGameObject(EditGameObjectBm bm)
        {
            GameObject gameObject = this.Context.GameObjects.Find(bm.Id);
            if (gameObject == null)
            {
                throw new Exception("Object not found!");
            }

            gameObject.Name = bm.Name;
            gameObject.Description = bm.Description;

            this.Context.SaveChanges();
        }

        public DeleteGameObjectVm GetDeleteGameObject(int? gameObjectId)
        {
            GameObject gameObject = this.Context.GameObjects.Find(gameObjectId);
            if (gameObject == null)
            {
                throw new Exception("Object not found!");
            }

            return Mapper.Instance.Map<GameObject, DeleteGameObjectVm>(gameObject);
        }

        public void DeleteGameObject(int? id)
        {
            GameObject gameObject = this.Context.GameObjects.Find(id);
            if (gameObject == null)
            {
                throw new Exception("Object not found!");
            }

            this.Context.GameObjects.Remove(gameObject);
            this.Context.SaveChanges();
        }
    }
}

