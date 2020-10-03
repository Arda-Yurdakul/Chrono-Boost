using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator shipAnimator;
    [SerializeField] private Animator screenAnimator;


    private void Update()
    {
        if(Input.touchCount > 0)
        {
            screenAnimator.SetTrigger("StartGame");
            shipAnimator.SetTrigger("StartGame");
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
