using System;
using GooglePlayGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        public ScreenOrientation orientation;
        public string startupSceneName;

        public void Start()
        {
            Screen.orientation = orientation ;
        }

        public void ExitGame()
        {
            PlayGamesPlatform.Instance.SignOut();
            Application.Quit();
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadSceneAsync(startupSceneName);
        }
    }
}

