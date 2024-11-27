using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{
    public bool randomFlip;
    public float moveSpeed = 5f;
    private Vector3 direction;
    public float lifetime = 5f;
    
    
    
    void Start()
    {
        SpriteRenderer img = gameObject.GetComponent<SpriteRenderer>();
        
        // Случайный поворот по оси X (зеркальное отражение)
        randomFlip = Random.value > 0.5f ? true : false; // Выбор направления
        img.flipX = randomFlip;
        direction = randomFlip ? Vector3.right : Vector3.left;
        Destroy(gameObject, lifetime);
    }
    
    void Update()
    {
        // Движение в сторону 
        transform.Translate(direction * (moveSpeed * Time.deltaTime));
        // Движение вниз
        transform.Translate(Vector3.down * (1f * Time.deltaTime));
    }
}
