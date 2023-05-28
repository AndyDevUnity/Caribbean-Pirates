using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class PlayerUI : MonoBehaviourPunCallbacks
{
    [Header("MainInfo")]
    [SerializeField] private TextMeshProUGUI _firstPlayerName;
    [SerializeField] private Slider _firstPlayerHealthBar;
    [SerializeField] private Sprite _firstPlayerAvatar;
    [SerializeField] private Image _firstPlayerAvatarSource;
    [SerializeField] private GameObject _firstPlayertSkills;
    [Header("OpponentInfo")]
    [SerializeField] private TextMeshProUGUI _secondPlayerName;
    [SerializeField] private Slider _secondPlayerHealthBar;
    [SerializeField] private Sprite _secondPlayerAvatar;
    [SerializeField] private Image _secondPlayerAvatarSource;
    [SerializeField] private GameObject _secondPlayertSkills;
    [Header("GameInfo")]
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private TextMeshProUGUI _ship;


    private void Start()
    {
        HealthSystem.takeDamage += ChangeHealthBarFirstPlayer;
        Cannonball.applyDamage += ChangeHealthBarSecondPlayer;
        SetUiInfo();
    }

    private void SetUiInfo()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            _firstPlayerName.text = PlayerPrefs.GetString("NickName");
            _secondPlayerName.text = ServerPause._secondNickName;
            _firstPlayerAvatarSource.sprite = _firstPlayerAvatar;
            _secondPlayerAvatarSource.sprite = _secondPlayerAvatar;
            _firstPlayertSkills.SetActive(true);
        }
        else
        {
            _firstPlayerName.text = PlayerPrefs.GetString("NickName");
            _secondPlayerName.text = PhotonNetwork.MasterClient.NickName;
            _firstPlayerAvatarSource.sprite = _secondPlayerAvatar;
            _secondPlayerAvatarSource.sprite = _firstPlayerAvatar;
            _secondPlayertSkills.SetActive(true);
        }
    }

    private void ChangeHealthBarFirstPlayer(int damage) => DecreaseHealthBar(_firstPlayerHealthBar, damage);
    private void ChangeHealthBarSecondPlayer(int damage) => DecreaseHealthBar(_secondPlayerHealthBar, damage);

    private void DecreaseHealthBar(Slider hpBar, int damage)
    {
        hpBar.value -= damage;
    }

    public IEnumerator PurchaseInfo(int coin)
    {
        _ship.text = ($"Не хватает {coin} монет.");
        _infoPanel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        _infoPanel.SetActive(false);
    }
}
