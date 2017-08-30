using GooglePlayGames.BasicApi.Multiplayer;
using UnityEngine;
using Zenject;

namespace Common
{
    public class CommonInstaller : MonoInstaller<CommonInstaller>
    {
        public GameObject modalWindowManagerPrefab;
        public GameObject gameManagerPrefab;

        public override void InstallBindings()
        {
            Container.Bind<IModalWindowManager>().To<IModalWindowManager>().FromInstance(modalWindowManagerPrefab.GetComponent<IModalWindowManager>());
            Container.Bind<RealTimeMultiplayerListener>().To<MultiplayerListener>().AsSingle();
            Container.Bind<IGameManager>().FromComponentInNewPrefab(gameManagerPrefab).AsSingle();
            Container.Bind<IQuickMatchManager>().To<QuickMatchManager>().AsSingle();
        }
    }
}