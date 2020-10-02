using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseText;
    [SerializeField] private Sprite resumeImage;
    [SerializeField] private Sprite pauseImage;


    public void PauseGame()
    {
        if(Time.timeScale != 0)
        {
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0F;
            GetComponent<Image>().sprite = resumeImage;
            pauseText.SetActive(true);
        }

        else
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02F;
            GetComponent<Image>().sprite = pauseImage;
            pauseText.SetActive(false);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02F;
    }
}
