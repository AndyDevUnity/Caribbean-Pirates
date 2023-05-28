using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class ServerPause : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _waitingScreen;
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Animator _animator;
    [SerializeField] private TextMeshProUGUI _text;
    public static string _secondNickName;

    private void Start()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            StartCoroutine(LoadingAsync());
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"Player {newPlayer.NickName} entered room");
        _secondNickName = newPlayer.NickName;
        StartCoroutine(LoadingAsync());
    }

    private IEnumerator LoadingAsync()
    {
        _text.text = "Противник найден. В бой!";
        yield return new WaitForSeconds(4.5f);
        _waitingScreen.SetActive(false);
        _loadingScreen.SetActive(true);
        _animator.SetBool("isProgress", true);
        yield return new WaitForSeconds(7.5f);
        SceneManager.LoadScene("Game");

        AsyncOperation asyncLoading = SceneManager.LoadSceneAsync("Game");
        asyncLoading.allowSceneActivation = false;
        if (!asyncLoading.isDone)
        {
            _animator.SetBool("isProgress", true);
            yield return new WaitForSeconds(7.5f);
            asyncLoading.allowSceneActivation = true;
        }
    }
}
