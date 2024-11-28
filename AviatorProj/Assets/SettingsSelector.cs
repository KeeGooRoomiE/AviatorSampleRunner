using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSelector : MonoBehaviour
{
    public void TriggerDaySetting(bool value)
    {
        int setVal = value ? 1 : 0;
        PlayerPrefs.SetInt("isDay", setVal);
        PlayerPrefs.Save();
    }
    
    public void TriggerSoundSetting(bool value)
    {
        int setVal = value ? 1 : 0;
        PlayerPrefs.SetInt("Sounds", setVal);
        PlayerPrefs.Save();
    }
    
    public void TriggerSFXSetting(bool value)
    {
        int setVal = value ? 1 : 0;
        PlayerPrefs.SetInt("SFX", setVal);
        PlayerPrefs.Save();
    }
}
