using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCoinController : MonoBehaviour
{
    //[SerializeField] private GameController gc;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            GameController.IncrementCoin(); // Увеличиваем счётчик
            Destroy(other.gameObject); // Удаляем монету
            Debug.Log("Coin got");
        }
    }
}
