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
    public float birdSpawnRate = 7f;
    public float bloonSpawnRate = 9f;
    public Vector2 spawnRange = new Vector2(-0.5f, 0.5f);
    public float spawnHeight = 1.5f;
    public float spawnOffscreenHeight = 6f;
    public Vector2 spawnHorRange = new Vector2(-2f, 2f);
    public Vector2 spawnMtnRange = new Vector2(-1f, 1f);
    public float spawnSide = 3f;
    public Vector2 greenHillHeight = new Vector2(1.5f, 3f);
    public Vector2 skyHeight = new Vector2(1.5f, 4f);
    
    public static bool isDay = true;

    [SerializeField] private GameObject coinInst;
    [SerializeField] private GameObject cloudInst;
    [SerializeField] private GameObject mntInst;
    [SerializeField] private GameObject birdInst;
    [SerializeField] private GameObject bloonInst;
    
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
        InvokeRepeating(nameof(SpawnBird), 0f, birdSpawnRate); // Запускаем таймер генерации
        InvokeRepeating(nameof(SpawnBloon), 0f, bloonSpawnRate); // Запускаем таймер генерации
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
    private void SpawnBird()
    {
        float randomY = Random.Range(greenHillHeight.x, greenHillHeight.y); // Случайная позиция по X
        float randomX = Random.value > 0.5f ? -3f : 3f;
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0); // Позиция спавна
        Instantiate(birdInst, spawnPosition, Quaternion.identity); // С
    }
    
    private void SpawnBloon()
    {
        float randomY = Random.Range(skyHeight.x, skyHeight.y); // Случайная позиция по X
        float randomX = Random.value > 0.5f ? -3f : 3f;
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0); // Позиция спавна
        Instantiate(bloonInst, spawnPosition, Quaternion.identity); // С
    }

    public static void IncrementCoin()
    {
        levelCoins++;
    }
}
