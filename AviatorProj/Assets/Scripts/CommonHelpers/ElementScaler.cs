using UnityEngine;

public class ElementScaler : MonoBehaviour
{
    public float minScale = 0.1f;    // Минимальный размер
    public float maxScale = 1f;     // Максимальный размер
    public float smoothSpeed = 5f;  // Скорость плавного изменения размера
    public float targetY = 0f;      // Конкретная точка по высоте, где объект достигает maxScale
    
    void Update()
    {
        // Текущая высота объекта относительно заданной точки
        float distanceToTarget = targetY - transform.position.y;

        // Определяем диапазон, где объект изменяет размер
        float normalizationRange = Mathf.Abs(targetY);

        // Нормализуем расстояние (значение от 0 до 1)
        float normalizedScaleFactor = Mathf.Clamp01(distanceToTarget / normalizationRange);

        // Рассчитываем целевой масштаб
        float targetScale = Mathf.Lerp(minScale, maxScale, normalizedScaleFactor);

        // Плавное движение к целевому масштабу
        float smoothScale = Mathf.Lerp(transform.localScale.y, targetScale, Time.deltaTime * smoothSpeed);
        transform.localScale = new Vector3(smoothScale, smoothScale, 1);
    }
}