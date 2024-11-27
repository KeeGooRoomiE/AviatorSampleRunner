using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGameManager : MonoBehaviour
{
    public void OpenGameScene()
    {
        SceneManager.LoadScene("GameScene"); 
    }
}
