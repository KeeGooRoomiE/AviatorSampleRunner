using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGameManager : MonoBehaviour
{
    public string mainScene = "MainGame";
    public string webViewScene = "WebViewScene";

    void Start()
    {
        FirebaseDatabase.DefaultInstance.GetReference("webview").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted && task.Result.Exists)
            {
                bool showWebView = bool.Parse(task.Result.Value.ToString());
                SceneManager.LoadScene(showWebView ? webViewScene : mainScene);
            }
        });
    }
    public void OpenGameScene()
    {
        SceneManager.LoadScene("GameScene"); 
    }
    
}
