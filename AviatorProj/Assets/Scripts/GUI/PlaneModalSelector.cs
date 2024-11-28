using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneModalSelector : MonoBehaviour
{
    public int planeNum = 0;

    [SerializeField] private Image planeImg;
    // [SerializeField] private Button backBtn;
    // [SerializeField] private Button fwdBtn;

    [SerializeField] private Sprite[] planes;
    
    void Start()
    {
        planeNum = PlayerPrefs.GetInt("Plane", 0);
    }

    void Update()
    {
        planeImg.sprite = planes[planeNum];
    }

    public void NextItem()
    {
        if (planeNum >= planes.Length-1)
        {
            planeNum = 0;
        }
        else
        {
            planeNum++;
        }
        
        PlayerPrefs.SetInt("Plane", planeNum);
        PlayerPrefs.Save();
    }

    public void PrevItem()
    {
        if (planeNum <= 0)
        {
            planeNum = planes.Length-1;
        }
        else
        {
            planeNum--;
        }
        
        PlayerPrefs.SetInt("Plane", planeNum);
        PlayerPrefs.Save();
    }
    
}
