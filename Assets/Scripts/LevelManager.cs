using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
    public GameObject gameOverPanel;
    public GameObject pauseMenu;
    public GameObject goldCoin;
    public GameObject goldStack;
    public Text scoreText;

    private float spawnTimer = 3f;
    private float spawnTimerReset = 3f;
    private int score = 0;

    SoundManager sm;
    MusicManager mm;

    void Awake()
    {
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        mm = GameObject.Find("MusicManager").GetComponent<MusicManager>();

        sm.SetSoundVolume(.5f);
    }

    private void Start()
    {
        Time.timeScale = 1;
        ObjectPool.CreatePool(goldCoin, -500, 0, 0, this.transform, 50);
        ObjectPool.CreatePool(goldStack, -500, 0, 0, this.transform, 5);
        scoreText.text = score.ToString();
        mm.PlaySound(mm.music[Random.Range(2,7)]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sm.StopSound();
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }

        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            SpawnPooledObjects();
            spawnTimer = spawnTimerReset;
        }
    }

    private void SpawnPooledObjects()
    {
        float randomXPos;
        float randomYPos;
        GameObject go;

        go = GetRandomPooledObject();

        randomXPos = Random.Range(-5f,4f);
        randomYPos = Random.Range(-2.5f,3.5f);
        go.transform.position = new Vector2(randomXPos,randomYPos);
        ObjectPool.ActivateObject(go);
    }

    private GameObject GetRandomPooledObject()
    {
        int randomNumber;
        int maxObjects;
        GameObject go;

        maxObjects = this.transform.childCount;
        randomNumber = Random.Range(0, maxObjects);

        go = this.gameObject.transform.GetChild(randomNumber).gameObject;

        while (go.activeInHierarchy)
        {
            randomNumber = Random.Range(0, maxObjects);
            go = this.gameObject.transform.GetChild(randomNumber).gameObject;
        }

        return go;
    }

    public void GameOver()
    {
        sm.StopSound();
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ClosePauseMenu()
    {
        sm.PlaySound(sm.sounds[0], true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

}
