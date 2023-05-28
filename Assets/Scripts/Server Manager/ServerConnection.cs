using UnityEngine;
using Photon.Pun;
using TMPro;

public class ServerConnection : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField _nickName;
    [SerializeField] private TextMeshProUGUI _logText;
    [SerializeField] GameObject _infoPanel;
    [SerializeField] GameObject _loadingPanel;

    private void Start()
    {
        SetOutputText("Никнейм может содержать только буквы (от A до Z) а также символ пробела.");
    }

    public void SetNameToServer(string nickname)
    {
        nickname = _nickName.text;

        if (string.IsNullOrEmpty(nickname))
        {
            _logText.text = null;
            SetOutputText("<color=red>Please enter your nickname");
        }
        else
        {
            _logText.text = null;
            PhotonNetwork.NickName = nickname;
            PlayerPrefs.SetString("NickName", nickname);
            SetOutputText("Player's name is set to: " + nickname);
            _loadingPanel.SetActive(true);
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public void StartGame()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnConnectedToMaster()
    {
        _loadingPanel.SetActive(false);
        SetOutputText("<color=green>Connected to server");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Search Opponent");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        SetOutputText("<color=red>Failed to create room");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 2, CleanupCacheOnLeave = false });
    }

    public void ShowInfoPanel() => _infoPanel.SetActive(true);
    public void CloseInfoPanel() => _infoPanel.SetActive(false);

    private void SetOutputText(string message)
    {
        _logText.text += "\n";
        _logText.text += message;
    }
}
