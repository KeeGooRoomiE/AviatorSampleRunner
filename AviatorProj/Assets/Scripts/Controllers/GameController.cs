using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public static int levelCoins = 0;

    public static int boosterRocket = 0;
    public static int boosterShield = 0;
    public static int boosterMagnet = 0;
    
    [SerializeField] private TextMeshProUGUI boosterRText;
    [SerializeField] private TextMeshProUGUI boosterSText;
    [SerializeField] private TextMeshProUGUI boosterMText;
    
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI modalCoinText;

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
    public static bool isGameEnd = false;

    [SerializeField] private GameObject modal;

    [SerializeField] private GameObject coinInst;
    [SerializeField] private GameObject cloudInst;
    [SerializeField] private GameObject mntInst;
    [SerializeField] private GameObject birdInst;
    [SerializeField] private GameObject bloonInst;

    public AudioClip musicClip;
    public AudioClip failSound;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        LoadBoosters();
        isDay = PlayerPrefs.GetInt("isDay", 0) != 0 ? false : true;
        
        InvokeRepeating(nameof(SpawnCoin), 0f, coinSpawnRate); // Запускаем таймер генерации
        InvokeRepeating(nameof(SpawnCloud), 0f, cloudSpawnRate); // Запускаем таймер генерации
        InvokeRepeating(nameof(SpawnMountain), 0f, mntSpawnRate); // Запускаем таймер генерации
        InvokeRepeating(nameof(SpawnBird), 0f, birdSpawnRate); // Запускаем таймер генерации
        InvokeRepeating(nameof(SpawnBloon), 0f, bloonSpawnRate); // Запускаем таймер генерации

        bool canPlayMusic = PlayerPrefs.GetInt("Sounds", 0) != 0 ? true : false;
        if (canPlayMusic)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            // Настройка AudioSource
            audioSource.clip = musicClip;
            audioSource.loop = true; // Включаем зацикливание
            audioSource.playOnAwake = false; // Выключаем автозапуск

            // Запуск музыки
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = levelCoins.ToString();
        modalCoinText.text = levelCoins.ToString();
        
        boosterSText.text = boosterShield.ToString();
        boosterRText.text = boosterRocket.ToString();
        boosterMText.text = boosterMagnet.ToString();
    }

    private void SpawnCoin()
    {
        if (!isGameEnd)
        {
            float randomX = Random.Range(spawnRange.x, spawnRange.y); // Случайная позиция по X
            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0); // Позиция спавна
            Instantiate(coinInst, spawnPosition, Quaternion.identity); // С
        }
    }

    private void SpawnCloud()
    {
        if (!isGameEnd)
        {
            float randomX = Random.Range(spawnHorRange.x, spawnHorRange.y); // Случайная позиция по X
            Vector3 spawnPosition = new Vector3(randomX, spawnOffscreenHeight, 0); // Позиция спавна
            Instantiate(cloudInst, spawnPosition, Quaternion.identity); //
        }
    }

    private void SpawnMountain()
    {
        if (!isGameEnd)
        {
            float randomX = Random.Range(spawnMtnRange.x, spawnMtnRange.y); // Случайная позиция по X
            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0); // Позиция спавна
            Instantiate(mntInst, spawnPosition, Quaternion.identity); // С
        }
    }

    private void SpawnBird()
    {
        if (!isGameEnd)
        {
            float randomY = Random.Range(greenHillHeight.x, greenHillHeight.y); // Случайная позиция по X
            float randomX = Random.value > 0.5f ? -3f : 3f;
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0); // Позиция спавна
            Instantiate(birdInst, spawnPosition, Quaternion.identity); // С
        }
    }

    private void SpawnBloon()
    {
        if (!isGameEnd)
        {
            float randomY = Random.Range(skyHeight.x, skyHeight.y); // Случайная позиция по X
            float randomX = Random.value > 0.5f ? -3f : 3f;
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0); // Позиция спавна
            Instantiate(bloonInst, spawnPosition, Quaternion.identity); // С
        }
    }

    public static void IncrementCoin()
    {
        levelCoins++;
    }

    
    private void SaveBoosters()
    {
        PlayerPrefs.SetInt("RocketBooster", boosterRocket);
        PlayerPrefs.SetInt("ShieldBooster", boosterShield);
        PlayerPrefs.SetInt("MagnetBooster", boosterMagnet);
        PlayerPrefs.Save();
    }
    
    public void LoadBoosters()
    {
        boosterRocket = PlayerPrefs.GetInt("RocketBooster", 0); // 0 - значение по умолчанию
        boosterShield = PlayerPrefs.GetInt("ShieldBooster", 0);
        boosterMagnet = PlayerPrefs.GetInt("MagnetBooster", 0);
    }
    
    public static void BuyBooster(int boosterNum)
    {
        switch (boosterNum)
        {
            case 0:
                boosterRocket++;
                break;

            case 1:
                boosterShield++;
                break;

            case 2:
                boosterMagnet++;
                break;
        }
    }

    public void AttemptBuyRocket()
    {
        if (levelCoins >= 20)
        {
            levelCoins -= 20;
            BuyBooster(0);
            SaveBoosters();
        }
    }
    
    public void AttemptBuyShield()
    {
        if (levelCoins >= 50)
        {
            levelCoins -= 50;
            BuyBooster(1);
            SaveBoosters();
        }
    }
    
    public void AttemptBuyMagnet()
    {
        if (levelCoins >= 150)
        {
            levelCoins -= 150;
            BuyBooster(2);
            SaveBoosters();
        }
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    
    public void OpenMenuScene()
    {
        SceneManager.LoadScene("MenuScene"); 
        Time.timeScale = 1f;
    }

    public void Lose()
    {
        OpenLoseModal();
        Time.timeScale = 0f;
        isGameEnd = true;
        if (PlayerPrefs.GetInt("SFX", 0) != 0)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            // Настройка AudioSource
            audioSource.clip = failSound;
            audioSource.loop = false; // Включаем зацикливание
            audioSource.playOnAwake = false; // Выключаем автозапуск

            // Запуск музыки
            audioSource.Play();
        }
    }

    private void OpenLoseModal()
    {
        modal.SetActive(true);
    }
}