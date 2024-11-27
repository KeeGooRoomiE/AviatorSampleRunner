using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    public static GameController Instance; 
    
    public static int levelCoins = 0;
    [SerializeField] private TextMeshProUGUI coinText;
    
    public float coinSpawnRate = 1f;
    public float cloudSpawnRate = 3f;
    public Vector2 spawnRange = new Vector2(-2f, 2f);
    public float spawnHeight = 6f;
    public Vector2 spawnHorRange = new Vector2(-2f, 2f);
    public float spawnOffscreenHeight = 6f;

    [SerializeField] private GameObject coinInst;
    [SerializeField] private GameObject cloudInst;
    
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        InvokeRepeating(nameof(SpawnCoin), 0f, coinSpawnRate); // Запускаем таймер генерации
        InvokeRepeating(nameof(SpawnCloud), 0f, cloudSpawnRate); // Запускаем таймер генерации
    }
    // Update is called once per frame
    void Update()
    {
        coinText.text = levelCoins.ToString();
        
    }

    private void SpawnCoin()
    {
        float randomX = Random.Range(spawnRange.x, spawnRange.y); // Случайная позиция по X
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0); // Позиция спавна
        Instantiate(coinInst, spawnPosition, Quaternion.identity); // С
    }
    
    private void SpawnCloud()
    {
        float randomX = Random.Range(spawnHorRange.x, spawnHorRange.y); // Случайная позиция по X
        Vector3 spawnPosition = new Vector3(randomX, spawnOffscreenHeight, 0); // Позиция спавна
        Instantiate(cloudInst, spawnPosition, Quaternion.identity); // С
    }

    public static void IncrementCoin()
    {
        levelCoins++;
    }
}
