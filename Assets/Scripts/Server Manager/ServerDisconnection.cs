using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class ServerDisconnection : MonoBehaviourPunCallbacks
{
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log($"Player {otherPlayer.NickName} left from room");
        SceneManager.LoadScene("Battle Winner");
    }

    public override void OnLeftRoom() => SceneManager.LoadScene("Battle Losing");

    public static void LeaveRoom() => PhotonNetwork.LeaveRoom();
}
