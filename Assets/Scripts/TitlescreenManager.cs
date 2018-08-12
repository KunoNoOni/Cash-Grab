using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlescreenManager : MonoBehaviour 
{
    MusicManager mm;
    
    void Awake() 
    {
        mm = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        mm.PlaySound(mm.music[0]);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }
    
    public void Instructions()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        SceneManager.LoadScene(3);
    }
}
