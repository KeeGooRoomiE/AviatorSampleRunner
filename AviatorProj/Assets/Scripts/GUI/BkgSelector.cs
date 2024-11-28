using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BkgSelector : MonoBehaviour
{
    private SpriteRenderer spr;
    [SerializeField] private Sprite[] imgs;
    
    // Start is called before the first frame update
    void Start()
    {
        spr = gameObject.GetComponent<SpriteRenderer>();
        int loadedData = PlayerPrefs.GetInt("isDay", 0);
        spr.sprite = imgs[loadedData];
    }
}
