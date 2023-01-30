using UnityEngine.UI;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] Button soundButton;
    [SerializeField] Sprite soundOn;
    [SerializeField] Sprite soundOff;
  
    // Start is called before the first frame update
    void Start()
    {
        UpdateSoundIcon();
    }

    public void PuaseMusic()
    {
        ToggleSound();
        UpdateSoundIcon();
    }

    void ToggleSound()
    {
        if(PlayerPrefs.GetInt("Muted") == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
        }
    }

    void UpdateSoundIcon()
    {
        if(PlayerPrefs.GetInt("Muted") == 0)
        {
            AudioListener.volume = 1;
            soundButton.GetComponent<Image>().sprite = soundOn;
        }
        else
        {
            AudioListener.volume = 0;
            soundButton.GetComponent<Image>().sprite = soundOff;
        }
    }
}

