using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour 
{
    public GameObject dolly;

    private float speed = 100f;

	void Start () 
	{
	    
	}
	
	void Update () 
	{
        if(dolly.transform.position.y < 5000)
            dolly.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
	}

    public void BackToTitleScreen()
    {
        SceneManager.LoadScene(0);
    }
}
