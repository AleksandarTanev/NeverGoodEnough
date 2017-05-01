﻿namespace NeverGoodEnough.Web
{
    using AutoMapper;
    using NeverGoodEnough.Models.EntityModels;
    using NeverGoodEnough.Models.ViewModels.GameMechanic;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using NeverGoodEnough.Models.BindingModels.GameMechanic;
    using NeverGoodEnough.Models.BindingModels.GameVictoryConditions;
    using NeverGoodEnough.Models.ViewModels.GameVictoryConditions;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.RegisterMaps();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMaps()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<GameMechanic, AllGameMechanicVm>();
                expression.CreateMap<GameMechanic, CreateGameMechanicVm>();
                expression.CreateMap<GameMechanic, DeleteGameMechanicVm>();
                expression.CreateMap<GameMechanic, DetailsGameMechanicVm>();
                expression.CreateMap<GameMechanic, EditGameMechanicVm>();

                expression.CreateMap<CreateGameMechanicBm, GameMechanic>();
                expression.CreateMap<EditGameMechanicBm, GameMechanic>();

                expression.CreateMap<GameVictoryCondition, AllGameVictoryConditionVm>();
                expression.CreateMap<GameVictoryCondition, CreateGameVictoryConditionVm>();
                expression.CreateMap<GameVictoryCondition, DeleteGameVictoryConditionVm>();
                expression.CreateMap<GameVictoryCondition, DetailsGameVictoryConditionVm>();
                expression.CreateMap<GameVictoryCondition, EditGameVictoryConditionVm>();

                expression.CreateMap<CreateGameVictoryConditionBm, GameVictoryCondition>();
                expression.CreateMap<EditGameVictoryConditionBm, GameVictoryCondition>();
            });
        }
    }
}
