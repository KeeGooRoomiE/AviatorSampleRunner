using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainBehaviour : MonoBehaviour
{
    public float moveSpeed = 1f; // Скорость движения вниз
    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private Sprite[] sprites;

    void Start()
    {
        
        if (GameController.isDay = true)
        {
            spr.sprite = sprites[0];
        }
        else
        {
            spr.sprite = sprites[1];
        }
    }

    void Update()
    {
        // Движение вниз
        transform.Translate(Vector3.down * ((moveSpeed*transform.localScale.x) * Time.deltaTime));
    }
    

    // Столкновение с игроком
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверяем, столкнулся ли игрок
        {
            GameController.Instance.Lose();
        }
    }
}