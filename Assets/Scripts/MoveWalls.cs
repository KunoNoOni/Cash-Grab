using UnityEngine;

public class MoveWalls : MonoBehaviour 
{
    private bool canMove = false;
    private float direction;
    private float speed = .025f;
    private LevelManager levelManager;
    
	void Start () 
	{
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	}
	

    private void FixedUpdate()
    {
        if (canMove)
        {
            transform.position += new Vector3(direction, 0) * speed * Time.fixedDeltaTime;
        }
    }

    public void StartMove(float dir)
    {
        canMove = true;
        direction = dir;
    }

    public void StopMove()
    {
        canMove = false;
    }

    public bool GetCanMove()
    {
        return canMove;
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            //Time.timeScale = 0;
            levelManager.GameOver();
        }
    }

}
