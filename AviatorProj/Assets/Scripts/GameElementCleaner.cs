using UnityEngine;

public class GameElementCleaner : MonoBehaviour
{
    public float lowerBoundary = -10f; 
    
    void Update()
    {
        if (transform.position.y < lowerBoundary)
        {
            Destroy(gameObject); 
        }
    }
}