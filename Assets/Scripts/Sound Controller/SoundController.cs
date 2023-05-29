using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private Image _musicButton;
    [SerializeField] private Sprite _onSound;
    [SerializeField] private Sprite _offSound;
    [SerializeField] private AudioSource _audioSrc;
    private bool _soundOn = true;

    private void Update()
    {
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            _musicButton.GetComponent<Image>().sprite = _onSound;
            _audioSrc.volume = 0.7f;
            _soundOn = true;
        }
        else if (PlayerPrefs.GetInt("sound") == 1)
        {
            _musicButton.GetComponent<Image>().sprite = _offSound;
            _audioSrc.volume = 0f;
            _soundOn = false;
        }
    }

    public void OffSound()
    {
        if (_soundOn)
            PlayerPrefs.SetInt("sound", 0);
        if (!_soundOn)
            PlayerPrefs.SetInt("sound", 1);
    }
}
