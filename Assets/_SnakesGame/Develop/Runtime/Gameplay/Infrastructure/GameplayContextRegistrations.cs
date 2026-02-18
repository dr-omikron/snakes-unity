using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore;
using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using _SnakesGame.Develop.Runtime.Gameplay.Features.InputFeatures;
using _SnakesGame.Develop.Runtime.Infrastructure.DI;
using _SnakesGame.Develop.Runtime.Utilities.AssetsManagement;

namespace _SnakesGame.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayContextRegistrations
    {
        public static void Process(DIContainer container, GameplayInputArgs args)
        {
            container.RegisterAsSingle(CreateEntitiesFactory);
            container.RegisterAsSingle(CreateEntitiesLifeContext);
            container.RegisterAsSingle(CreateMonoEntityFactory).NonLazy();
            container.RegisterAsSingle(CreateGameplayInputService).NonLazy();
        }

        private static EntitiesFactory CreateEntitiesFactory(DIContainer c)
            => new EntitiesFactory(c);

        private static EntitiesLifeContext CreateEntitiesLifeContext(DIContainer c)
            => new EntitiesLifeContext();

        private static MonoEntityFactory CreateMonoEntityFactory(DIContainer c)
        {
            return new MonoEntityFactory(
                c.Resolve<ResourcesAssetsLoader>(), 
                c.Resolve<EntitiesLifeContext>());
        }

        private static GameplayInputService CreateGameplayInputService(DIContainer c)
            => new GameplayInputService();
    }
}
