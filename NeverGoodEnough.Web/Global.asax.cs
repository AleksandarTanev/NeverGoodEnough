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
    using NeverGoodEnough.Models.ViewModels;

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
                expression.CreateMap<GameComponent, AllPersonalGameComponentVm>()
                                    .ForMember(vm => vm.Username, configurationExpression => configurationExpression.MapFrom(g => g.Engineer.User.Name));
                expression.CreateMap<GameComponent, MyAllPersonalGameComponentVm>();
                expression.CreateMap<GameComponent, CreateGameComponentVm>();
                expression.CreateMap<GameComponent, DeleteGameComponentVm>();
                expression.CreateMap<GameComponent, DetailsGameComponentVm>();
                expression.CreateMap<GameComponent, EditGameComponentVm>();

                expression.CreateMap<CreateGameComponentBm, GameComponent>();
                expression.CreateMap<EditGameComponentBm, GameComponent>();

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
                    .ForMember(vm => vm.Name,
                        configurationExpression => configurationExpression.MapFrom(engineer => engineer.User.Name))
                    .ForMember(vm => vm.Games,
                        configurationExpression => configurationExpression.MapFrom(engineer => engineer.Games.Count))
                    .ForMember(vm => vm.GameComponents,
                        configurationExpression =>
                            configurationExpression.MapFrom(engineer => engineer.GameMechanics.Count));
            });
        }
    }
}
