namespace NeverGoodEnough.Test.Controllers
{
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NeverGoodEnough.Data.Interfaces;
    using NeverGoodEnough.Data.Mocks;
    using NeverGoodEnough.Models.EntityModels;
    using NeverGoodEnough.Models.ViewModels.GameMechanic;
    using NeverGoodEnough.Services;
    using NeverGoodEnough.Services.Interfaces;
    using NeverGoodEnough.Web.Controllers;

    [TestClass]
    public class TestGameMechanicsController
    {
        private GameMechanicsController _controller;
        private IGameMechanicService _service;
        private INeverGoodEnoughContext _context;
        private List<GameMechanic> gameMechanics;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<GameMechanic, AllPersonalGameMechanicVm>();
            });
        }

        [TestInitialize]
        public void Init()
        {
            this.ConfigureMapper();
            this.gameMechanics = new List<GameMechanic>()
            {
                new GameMechanic()
                {
                    Id = 1,
                    Name = "Running",
                    Description = "Fast travel"
                },
                new GameMechanic()
                {
                    Id = 2,
                    Name = "Walking",
                    Description = "Slow travel"
                }
            };

            this._context = new FakeNeverGoodEnoughContext();
            foreach (var gameMechanic in this.gameMechanics)
            {
                this._context.GameMechanics.Add(gameMechanic);
            }

            this._service = new GameMechanicService(this._context);
            this._controller = new GameMechanicsController(this._service);
        }

        /*
        [TestMethod]
        public void ListAllCars_ShouldReturnOk()
        {
            var result = this._controller.All() as HttpStatusCodeResult;

            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void ListAllCars_ShouldReturnGivenCars()
        {
            var data = this._controller.Get() as OkNegotiatedContentResult<IEnumerable<CarVm>>;
            Assert.AreEqual(2, data.Content.Count());
        }

        [TestMethod]
        public void GetValidCarById_ShouldReturnOk()
        {
            var data = this._controller.Get(1) as OkNegotiatedContentResult<CarVm>;
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void GetValidCarById_ShouldReturnGivenCar()
        {
            var data = this._controller.Get(1) as OkNegotiatedContentResult<CarVm>;
            Assert.AreEqual(20, data.Content.Price);
            Assert.AreEqual("Volga", data.Content.Name);
        }

        [TestMethod]
        public void GetInValidCarById_ShouldNotFound()
        {
            var data = this._controller.Get(3) as NotFoundResult;
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void PostValidCar_ShouldReturnCreated()
        {
            CarBm testCar = new CarBm() { Name = "Trabant", Price = 15 };
            var data = this._controller.Post(testCar) as StatusCodeResult;
            Assert.AreEqual(HttpStatusCode.Created, data.StatusCode);
        }

        [TestMethod]
        public void PostValidCar_ShouldAddToRepo()
        {
            CarBm testCar = new CarBm() { Name = "Trabant", Price = 15 };
            var data = this._controller.Post(testCar) as StatusCodeResult;
            Assert.AreEqual(3, this._context.Cars.Count());
        }

        [TestMethod]
        public void PostInValidCar_ShouldReturnBadRequest()
        {
            CarBm testCar = new CarBm() { Name = "Ta", Price = 15 };
            this._controller.Validate(testCar);
            var data = this._controller.Post(testCar) as StatusCodeResult;
            Assert.AreEqual(HttpStatusCode.BadRequest, data.StatusCode);
        }

        [TestMethod]
        public void PutValidCar_ShouldReturnNoContent()
        {
            CarBm testCar = new CarBm() { Name = "Trabant", Price = 15 };
            var data = this._controller.Put(1, testCar) as StatusCodeResult;
            Assert.AreEqual(HttpStatusCode.NoContent, data.StatusCode);
        }

        [TestMethod]
        public void PutValidCar_ShouldModifyCar()
        {
            CarBm testCar = new CarBm() { Name = "Trabant", Price = 15 };
            var data = this._controller.Put(1, testCar) as StatusCodeResult;
            Assert.AreEqual("Trabant", this.cars[0].Name);
            Assert.AreEqual(15, this.cars[0].Price);
        }

        [TestMethod]
        public void PutInvalidCar_ShouldReturnBadRequest()
        {
            CarBm testCar = new CarBm() { Name = "Go", Price = 15 };
            this._controller.Validate(testCar);
            var data = this._controller.Put(1, testCar) as StatusCodeResult;
            Assert.AreEqual(HttpStatusCode.BadRequest, data.StatusCode);
        }

        [TestMethod]
        public void PutValidCarOnInvalidId_ShouldReturnNotFound()
        {
            CarBm testCar = new CarBm() { Name = "BMW", Price = 15 };
            var data = this._controller.Put(3, testCar) as StatusCodeResult;
            Assert.AreEqual(HttpStatusCode.NotFound, data.StatusCode);
        }

        [TestMethod]
        public void DeleteExistingCar_ShouldReturnOk()
        {
            var data = this._controller.Delete(2) as OkResult;
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void DeleteExistingCar_ShouldDeleteCarFromRepo()
        {
            var data = this._controller.Delete(2) as OkResult;
            Assert.AreEqual(1, this._context.Cars.Count());
        }

        [TestMethod]
        public void DeleteNonExistingCar_ShouldReturnNoFound()
        {
            var data = this._controller.Delete(3) as StatusCodeResult;
            Assert.AreEqual(HttpStatusCode.NotFound, data.StatusCode);
        }
        */
    }
}
