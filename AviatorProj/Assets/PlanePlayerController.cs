using UnityEngine;

public class PlaneTouchControl : MonoBehaviour
{
    public float moveSpeed = 1f; // Скорость перемещения
    public Vector2 screenBounds; // Ограничения по экрану (зададим автоматически)

    private Camera mainCamera;
    private Transform plane;

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
            touchPosition.y = Mathf.Clamp(touchPosition.y, -5f, -2.75f);

            // Плавное перемещение к позиции пальца
            transform.position = Vector3.Lerp(transform.position, touchPosition, moveSpeed * Time.deltaTime);
        }
    }
}