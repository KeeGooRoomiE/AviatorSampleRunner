using UnityEngine;

public class PlaneTouchControl : MonoBehaviour
{
    public float moveSpeed = 1f; // Скорость перемещения
    public Vector2 screenBounds; // Ограничения по экрану (зададим автоматически)
    public float waveFrequency = 4f; // Частота покачивания
    public float waveAmplitude = 5f; // Амплитуда покачивания
    public float rotationSpeed = 10f; // Скорость поворота для покачивания

    private Camera mainCamera;
    private Transform plane;
    private bool isMoving = false; // Флаг для отслеживания движения

    void Start()
    {
        mainCamera = Camera.main;
        plane = gameObject.transform;

        // Автоматический расчет границ экрана
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    void Update()
    {
        // Проверяем, есть ли касание
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Преобразуем координаты касания в мировые
            Vector3 touchPosition = mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
            touchPosition.z = 0; // Убираем смещение по оси Z для 2D

            // Ограничиваем самолет в пределах экрана
            touchPosition.x = Mathf.Clamp(touchPosition.x, -screenBounds.x, screenBounds.x);
            touchPosition.y = Mathf.Clamp(touchPosition.y, -5f, -2.7f);

            // Плавное перемещение к позиции пальца
            transform.position = Vector3.Lerp(transform.position, touchPosition, moveSpeed * Time.deltaTime);

            isMoving = true; // Самолет двигается
        }
        else
        {
            isMoving = false; // Если нет касания, значит, самолет не двигается
        }

        // Если самолет в движении, добавляем покачивание
        if (isMoving)
        {
            // Волна на основе синуса для горизонтального покачивания
            float wave = Mathf.Sin(Time.time * waveFrequency) * waveAmplitude;

            // Применяем покачивание к углу поворота по оси Z
            float targetRotation = wave;
            transform.rotation = Quaternion.Euler(0, 0, targetRotation);
        }
        else
        {
            // Если самолет не двигается, сбрасываем его поворот
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}