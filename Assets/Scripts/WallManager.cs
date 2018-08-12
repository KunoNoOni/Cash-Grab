using UnityEngine;
using UnityEngine.UI;

public class WallManager : MonoBehaviour 
{
    
    public Text wallsFrozen;

    private float timerCooldown = 2f;
    private float timeCooldownReset = 2f;
    private MoveWalls leftMovingWall;
    private MoveWalls rightMovingWall;
    private bool moveWallsCanMove;

    SoundManager sm;
    
    void Awake() 
    {
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void Start () 
	{
        leftMovingWall = GameObject.Find("Left Moving Wall").GetComponent<MoveWalls>();
        rightMovingWall = GameObject.Find("Right Moving Wall").GetComponent<MoveWalls>();
        wallsFrozen.text = "0.00";
        MoveWalls();
        moveWallsCanMove = leftMovingWall.GetCanMove();
    }
	
	void Update () 
	{
        if(!moveWallsCanMove)
        {
            timerCooldown -= Time.deltaTime;
            wallsFrozen.text = timerCooldown.ToString("0.00");
            if(timerCooldown <= 0)
            {
                MoveWalls();
                moveWallsCanMove = leftMovingWall.GetCanMove();
                wallsFrozen.text = "0.00";
                timerCooldown = timeCooldownReset;
            }
        }
	}

    private void MoveWalls()
    {
        sm.PlaySound(sm.sounds[0], true);
        leftMovingWall.StartMove(1f);
        rightMovingWall.StartMove(-1f);
    }

    public void StopWalls()
    {
        sm.StopSound();
        timerCooldown += 3;
        leftMovingWall.StopMove();
        rightMovingWall.StopMove();
        moveWallsCanMove = leftMovingWall.GetCanMove();
    }
}
