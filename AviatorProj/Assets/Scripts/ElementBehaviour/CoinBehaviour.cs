using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    public float moveSpeed = 1f; // Скорость движения вниз
    public float waveSpeed = 2f; // Скорость волны
    public float waveAmplitude = 0.5f; // Базовая амплитуда волны
    public AudioClip sound;

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
            if (PlayerPrefs.GetInt("SFX", 0) != 0)
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                if (audioSource == null)
                {
                    audioSource = gameObject.AddComponent<AudioSource>();
                }

                // Настройка AudioSource
                audioSource.clip = sound;
                audioSource.loop = false; // Включаем зацикливание
                audioSource.playOnAwake = false; // Выключаем автозапуск

                // Запуск музыки
                audioSource.Play();
            }

            Destroy(gameObject); // Удаляем монету
        }
    }
}