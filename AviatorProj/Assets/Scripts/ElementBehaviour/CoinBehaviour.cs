using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    public float moveSpeed = 1f; // Скорость движения вниз
    public float waveSpeed = 2f; // Скорость волны
    public float waveAmplitude = 0.5f; // Базовая амплитуда волны

    void Update()
    {
        // Движение вниз
        transform.Translate(Vector3.down * (moveSpeed * Time.deltaTime));
        
        // Волна на основе синуса для горизонтального движения
        float wave = Mathf.Sin(Time.time * waveSpeed) * waveAmplitude;
        
        // Применяем множитель скейла к амплитуде
        float scaledWave = wave * transform.localScale.x;

        // Обновляем позицию объекта с учётом горизонтального и вертикального движения
        transform.position += new Vector3(scaledWave * Time.deltaTime, 0, 0);
    }

    // Столкновение с игроком
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверяем, столкнулся ли игрок
        {
            GameController.IncrementCoin(); // Увеличиваем счет
            Destroy(gameObject); // Удаляем монету
        }
    }
}