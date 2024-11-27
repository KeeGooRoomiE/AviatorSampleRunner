using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
    
    public float moveSpeed = 0.2f; // Скорость движения вниз
    public float waveSpeed = 4f; // Скорость волны
    public float waveAmplitude = 1f; // Базовая амплитуда волны
    private float waveDelay = 1f;
    public float randomFlip;
    private ElementScaler scaler;

    void Start()
    {
        scaler = gameObject.GetComponent<ElementScaler>();
        // Устанавливаем случайную скорость волны с небольшой задержкой
        float endWave = Random.Range(waveSpeed - waveDelay, waveSpeed + waveDelay);
        waveSpeed = endWave;

        // Случайный поворот по оси X (зеркальное отражение)
      randomFlip = Random.value > 0.5f ? 1 : -1; // Выбор направления
      scaler.scaleModifier = randomFlip;
    }

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
}