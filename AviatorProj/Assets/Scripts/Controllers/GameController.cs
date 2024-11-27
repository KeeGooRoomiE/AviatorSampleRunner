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
    public float mntSpawnRate = 9f;
    public Vector2 spawnRange = new Vector2(-0.5f, 0.5f);
    public float spawnHeight = 1.5f;
    public float spawnOffscreenHeight = 6f;
    public Vector2 spawnHorRange = new Vector2(-2f, 2f);
    public Vector2 spawnMtnRange = new Vector2(-1f, 1f);
    
    public static bool isDay = true;

    [SerializeField] private GameObject coinInst;
    [SerializeField] private GameObject cloudInst;
    [SerializeField] private GameObject mntInst;
    
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
        InvokeRepeating(nameof(SpawnMountain), 0f, mntSpawnRate); // Запускаем таймер генерации
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
    
    private void SpawnMountain()
    {
        float randomX = Random.Range(spawnMtnRange.x, spawnMtnRange.y); // Случайная позиция по X
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0); // Позиция спавна
        Instantiate(mntInst, spawnPosition, Quaternion.identity); // С
    }

    public static void IncrementCoin()
    {
        levelCoins++;
    }
}
