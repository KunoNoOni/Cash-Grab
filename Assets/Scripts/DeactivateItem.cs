using UnityEngine;

public class DeactivateItem : MonoBehaviour 
{
    private float despawnTimer = 5f;
    private float despawnTimerReset = 5f;
    private LevelManager levelManager;
    private WallManager wallManager;

    SoundManager sm;

    void Awake()
    {
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void Start () 
	{
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        wallManager = GameObject.Find("WallManager").GetComponent<WallManager>();
    }
	
	void Update () 
	{
	    if(this.gameObject.activeInHierarchy)
        {
            despawnTimer -= Time.deltaTime;
            if (despawnTimer <= 0)
            {
                ResetTimer();
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            
            if(this.tag == "GoldCoin")
            {
                sm.PlaySound(sm.sounds[1], false);
                levelManager.AddScore(1);
            }
            else if(this.tag == "GoldBar")
            {
                sm.PlaySound(sm.sounds[2], false);
                levelManager.AddScore(5);
                wallManager.StopWalls();
            }
            ResetTimer();
        }
    }

    private void ResetTimer()
    {
        despawnTimer = despawnTimerReset;
        ObjectPool.DeactivateObject(this.gameObject);
    }
}
