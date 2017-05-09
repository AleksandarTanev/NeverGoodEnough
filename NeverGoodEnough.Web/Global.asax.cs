namespace NeverGoodEnough.Web
{
    using AutoMapper;
    using NeverGoodEnough.Models.EntityModels;
    using NeverGoodEnough.Models.ViewModels.GameMechanic;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Models.ViewModels.Games;
    using NeverGoodEnough.Models.BindingModels.Game;
    using NeverGoodEnough.Models.BindingModels.GameMechanic;
    using NeverGoodEnough.Models.BindingModels.GameObject;
    using NeverGoodEnough.Models.BindingModels.GameVictoryConditions;
    using NeverGoodEnough.Models.ViewModels;
    using NeverGoodEnough.Models.ViewModels.GameObject;
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
                // GameMechanic
                expression.CreateMap<GameMechanic, AllPersonalGameMechanicVm>()
                                    .ForMember(vm => vm.Username, configurationExpression => configurationExpression.MapFrom(g => g.Engineer.User.Name));
                expression.CreateMap<GameMechanic, MyAllPersonalGameMechanicVm>();
                expression.CreateMap<GameMechanic, CreateGameMechanicVm>();
                expression.CreateMap<GameMechanic, DeleteGameMechanicVm>();
                expression.CreateMap<GameMechanic, DetailsGameMechanicVm>();
                expression.CreateMap<GameMechanic, EditGameMechanicVm>();

                expression.CreateMap<CreateGameMechanicBm, GameMechanic>();
                expression.CreateMap<EditGameMechanicBm, GameMechanic>();

                // GameVictoryCondition
                expression.CreateMap<GameVictoryCondition, AllGameVictoryConditionVm>()
                    .ForMember(vm => vm.Username, configurationExpression => configurationExpression.MapFrom(g => g.Engineer.User.Name));
                expression.CreateMap<GameVictoryCondition, MyAllGameVictoryConditionVm>();
                expression.CreateMap<GameVictoryCondition, CreateGameVictoryConditionVm>();
                expression.CreateMap<GameVictoryCondition, DeleteGameVictoryConditionVm>();
                expression.CreateMap<GameVictoryCondition, DetailsGameVictoryConditionVm>();
                expression.CreateMap<GameVictoryCondition, EditGameVictoryConditionVm>();

                expression.CreateMap<CreateGameVictoryConditionBm, GameVictoryCondition>();
                expression.CreateMap<EditGameVictoryConditionBm, GameVictoryCondition>();

                // GameVictoryCondition
                expression.CreateMap<GameObject, AllGameObjectVm>()
                    .ForMember(vm => vm.Username, configurationExpression => configurationExpression.MapFrom(g => g.Engineer.User.Name));
                expression.CreateMap<GameObject, MyAllGameObjectVm>();
                expression.CreateMap<GameObject, CreateGameObjectVm>();
                expression.CreateMap<GameObject, DeleteGameObjectVm>();
                expression.CreateMap<GameObject, DetailsGameObjectVm>();
                expression.CreateMap<GameObject, EditGameObjectVm>();

                expression.CreateMap<CreateGameObjectBm, GameObject>();
                expression.CreateMap<EditGameObjectBm, GameObject>();

                // Game
                expression.CreateMap<Game, AllGameVm>()
                    .ForMember(vm => vm.Username, configurationExpression => configurationExpression.MapFrom(g => g.Engineer.User.Name));
                expression.CreateMap<Game, MyAllGameVm>();
                expression.CreateMap<Game, DeleteGameVm>();
                expression.CreateMap<Game, EditGameVm>();
                expression.CreateMap<Game, GreateGameVm>();

                expression.CreateMap<CreateGameBm, Game>();
                expression.CreateMap<EditGameBm, Game>();

                // Engineer
                expression.CreateMap<Engineer, AllEngineerVm>()
                    .ForMember(vm => vm.Name, configurationExpression => configurationExpression.MapFrom(engineer => engineer.User.Name))
                    .ForMember(vm => vm.Games, configurationExpression => configurationExpression.MapFrom(engineer => engineer.Games.Count))
                    .ForMember(vm => vm.GameMechanics, configurationExpression => configurationExpression.MapFrom(engineer => engineer.GameMechanics.Count))
                    .ForMember(vm => vm.GameVictoryConditions, configurationExpression => configurationExpression.MapFrom(engineer => engineer.GameVictoryConditions.Count));
            });
        }
    }
}
