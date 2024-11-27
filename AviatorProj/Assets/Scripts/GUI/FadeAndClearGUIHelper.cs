using System.Collections;
using UnityEngine;

public class FadeAndDestroy : MonoBehaviour
{
    public float timeToStay = 3f; // Время, которое объект остается видимым с альфой 1
    public float fadeDuration = 1f; // Время для исчезновения объекта (плавное снижение альфы)
    private SpriteRenderer spriteRenderer; // Ссылка на компонент SpriteRenderer
    private float fadeTimer; // Таймер для отслеживания времени исчезновения
    private bool isFading = false; // Флаг для отслеживания, что объект должен исчезнуть

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Получаем компонент SpriteRenderer
        fadeTimer = timeToStay; // Начинаем с времени, которое объект будет видимым
    }

    void Update()
    {
        if (fadeTimer > 0)
        {
            fadeTimer -= Time.deltaTime; // Отсчитываем время
        }
        else if (!isFading)
        {
            // Начинаем плавное исчезновение, когда время для отображения объекта закончится
            isFading = true;
            StartCoroutine(FadeOut());
        }
    }

    // Корутина для плавного исчезновения объекта
    private IEnumerator FadeOut()
    {
        float startAlpha = spriteRenderer.color.a; // Начальный альфа-канал (1)
        float endAlpha = 0f; // Конечный альфа-канал (0)
        float elapsedTime = 0f;

        // Плавное уменьшение альфы
        while (elapsedTime < fadeDuration)
        {
            float currentAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            Color newColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, currentAlpha);
            spriteRenderer.color = newColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Убедитесь, что альфа равна 0, когда завершен процесс исчезновения
        Color finalColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
        spriteRenderer.color = finalColor;

        // Удаляем объект после исчезновения
        Destroy(gameObject);
    }
}