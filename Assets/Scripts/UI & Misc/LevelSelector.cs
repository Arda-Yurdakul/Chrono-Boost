using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private GameObject lockedText;

    public void Level(int i)
    {
        if (PlayerPrefs.GetInt("HighestLevel") >= i - 1)
            SceneManager.LoadScene(i + 1);
        else
            lockedText.SetActive(true);
        
    }

    public void VisitStore()
    {
        #if UNITY_ANDROID
                Application.OpenURL("market://details?id=com.VoidInteractive.ChronoBoost");
        #elif UNITY_EDITOR
                print("Going to The Play Store");
        #endif
    }
}
