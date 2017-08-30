using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi.Multiplayer;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Common
{
    public class QuickMatchManager : IQuickMatchManager
    {
        private RealTimeMultiplayerListener _listener;
        private IGameManager _gameManager;
        private bool _searchingForMatch = false;
        private bool _matchInProgress = false;

        public string matchSceneName;

        [Inject]
        public QuickMatchManager(RealTimeMultiplayerListener listener, IGameManager gameManager)
        {
            _listener = listener;
            _gameManager = gameManager;
        }

        public void BeginQuickMatch()
        {
            if (PlayGamesPlatform.Instance.RealTime.IsRoomConnected())
            {
                _searchingForMatch = false;
                _matchInProgress = true;
                SceneManager.LoadSceneAsync(matchSceneName);
            }
            else
            {
                _searchingForMatch = false;
                _matchInProgress = false;
                throw new UnityException("Quick Match room not connected.");
            }
        }

        public void EndQuickMatch()
        {
            _searchingForMatch = false;
            _matchInProgress = false;
            _gameManager.GoToMainMenu();
        }

        public void QueueForQuickMatch()
        {
            if (!_searchingForMatch && !_matchInProgress)
            {
                _searchingForMatch = true;
                PlayGamesPlatform.Instance.RealTime.CreateQuickGame(1, 1, 0, _listener);
            }
        }

        public void QueueQuickMatchWithInvitation()
        {
            PlayGamesPlatform.Instance.RealTime.CreateWithInvitationScreen(1, 1, 0, _listener);
        }

        
    }
}
