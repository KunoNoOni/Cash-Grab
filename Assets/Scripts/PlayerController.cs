using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    private float speed = 4f;
    private float horizontal;
    private float vertical;
    
    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            transform.Translate(new Vector3(horizontal * speed * Time.deltaTime, 0, 0));
        }

        vertical = Input.GetAxis("Vertical");
        if (vertical != 0)
        {
            transform.Translate(new Vector3(0, vertical * speed * Time.deltaTime, 0));
        }
    }
    
}
