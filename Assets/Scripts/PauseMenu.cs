using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour 
{
    private MusicManager mm;
    private SoundManager sm;
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider soundSlider;

    private void Awake()
    {
         mm = GameObject.Find("MusicManager").GetComponent<MusicManager>();
         musicSlider.value = mm.channel.volume;

        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        soundSlider.value = sm.channels[0].volume;  
    }

    public void SetMusicVolume()
    {
        mm.SetMusicVolume(musicSlider.value);
    }

    public void SetSoundVolume()
    {
        sm.SetSoundVolume(soundSlider.value);
    }
}
