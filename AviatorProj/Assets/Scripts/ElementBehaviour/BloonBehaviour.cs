using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonBehaviour : MonoBehaviour
{
    public bool randomFlip;
    public float moveSpeed = 5f;
    private Vector3 direction;
    public float lifetime = 5f;
    [SerializeField] private Sprite[] sprites;
    
    
    void Start()
    {
        SpriteRenderer img = gameObject.GetComponent<SpriteRenderer>();
        
        // Случайный поворот по оси X (зеркальное отражение)
        randomFlip = Random.value > 0.5f ? true : false; // Выбор направления
        img.flipX = randomFlip;
        direction = randomFlip ? Vector3.right : Vector3.left;
        Destroy(gameObject, lifetime);
        img.sprite = randomFlip ? img.sprite = sprites[0] : img.sprite = sprites[1];
    }
    
    void Update()
    {
        // Движение в сторону 
        transform.Translate(direction * (moveSpeed * Time.deltaTime));
        // Движение вниз
        transform.Translate(Vector3.down * (0.5f * Time.deltaTime));
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверяем, столкнулся ли игрок
        {
            Debug.Log("BLOON!!!!");
            GameController.Instance.Lose();
        }
    }
}