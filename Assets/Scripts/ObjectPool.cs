using UnityEngine;

public class ObjectPool : MonoBehaviour 
{
    public static void CreatePool(GameObject go, float x, float y, float z, Transform transform, int amount)
    {
        GameObject gmobj;

        for (int i = 0; i < amount; i++) 
        {
            gmobj = Instantiate(go, new Vector3(x,y,z), go.transform.rotation, transform);
            DeactivateObject(gmobj);
            gmobj = null;
        }
    }
    
    public static void ActivateObject(GameObject go)
    {
        go.SetActive(true);
    }

    public static void DeactivateObject(GameObject go)
    {
        go.SetActive(false);
    }
}
