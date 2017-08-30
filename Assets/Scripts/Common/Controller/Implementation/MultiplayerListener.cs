using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using Zenject;

namespace Common
{
    public class MultiplayerListener : RealTimeMultiplayerListener
    {
        private InvitationReceivedDelegate _invitationReceivedCallback;
        private bool _showingWaitingRoom = false;
        private IQuickMatchManager _quickMatchManager;

        [Inject]
        public MultiplayerListener(IQuickMatchManager quickMatchManager)
        {
            _quickMatchManager = quickMatchManager;
            _invitationReceivedCallback = new InvitationReceivedDelegate(InvitationReceived);
        }

        private void InvitationReceived(Invitation invite, bool autoJoin)
        {
            PlayGamesPlatform.Instance.RealTime.AcceptFromInbox(this);
        }
        
        public void OnLeftRoom()
        {
            _quickMatchManager.EndQuickMatch();
        }

        public void OnParticipantLeft(Participant participant)
        {
            PlayGamesPlatform.Instance.RealTime.LeaveRoom();
            _quickMatchManager.EndQuickMatch();
        }

        public void OnPeersConnected(string[] participantIds)
        {
        }

        public void OnPeersDisconnected(string[] participantIds)
        {
            PlayGamesPlatform.Instance.RealTime.LeaveRoom();
            _quickMatchManager.EndQuickMatch();
        }

        public void OnRealTimeMessageReceived(bool isReliable, string senderId, byte[] data)
        {
        }

        public void OnRoomConnected(bool success)
        {
            _quickMatchManager.BeginQuickMatch();
        }

        public void OnRoomSetupProgress(float percent)
        {
            if (!_showingWaitingRoom)
            {
                _showingWaitingRoom = true;
                PlayGamesPlatform.Instance.RealTime.ShowWaitingRoomUI();
            }
        }
    }
}

