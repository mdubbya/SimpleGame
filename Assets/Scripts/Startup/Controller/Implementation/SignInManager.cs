using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using Common;
using Zenject;
using GooglePlayGames.BasicApi.Multiplayer;

namespace Startup
{
    public class SignInManager : MonoBehaviour
    {
        [Inject]
        private RealTimeMultiplayerListener listener;
        [Inject]
        private IModalWindowManager _modalWindowManager;
        private IModalWindow _signInInfoWindow;
        
        private void Start()
        {
            _signInInfoWindow =_modalWindowManager.DisplayInfoWindow("Connecting...",
                                                  "Connecting to google play services...");
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .EnableSavedGames()
            .RequestEmail()
            .RequestServerAuthCode(false)
            .RequestIdToken()
            .Build();

            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();

            Social.localUser.Authenticate(AuthenticatedCallback);
        }

        private void AuthenticatedCallback(bool authenticated)
        {
            if(authenticated)
            {
                _signInInfoWindow.Close();
            }
            else
            {
                _modalWindowManager.DisplayOkWindow("Error",
                    "Could not connect to google play.  Please check your internet connection and try again.",
                    new System.Action<DialogResult>(p => { Application.Quit(); }));
            }
        }

        
    }
}
