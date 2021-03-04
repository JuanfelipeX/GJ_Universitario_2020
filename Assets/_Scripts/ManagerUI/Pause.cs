using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    bool activate = false;
    public GameObject canvasPause;

    public static bool gameP;
    public static bool boolSeguroP;


    public AudioSource managerAudioGame;
    public AudioSource managerAudioPause;


    void Start()
    {
        canvasPause.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!activate)
            {
                activate = !activate;
                canvasPause.SetActive(true);
                managerAudioGame.Pause();
                Time.timeScale = 0;
            }
            else
            {
                activate = !activate;
                canvasPause.SetActive(false);
                managerAudioGame.Play();
                Time.timeScale = 1;
            }
            
            
            
        }
    }

    public void SwitchPause()
    {
        if (gameP)
        {
            bntResume();
        }
        else
        {
            bntPause();
        }
    }


    public void bntResume()
    {
        canvasPause.SetActive(false);
        Time.timeScale = 1;
        activate = false;
        managerAudioGame.Play();

    }

    public void bntPause()
    {
        canvasPause.SetActive(true);
        Time.timeScale = 0;
        gameP = true;

    }

    public void mPrincipal(string name)
    {
        SceneManager.LoadScene(name);
    }


    public void salirPsi()
    {
        Application.Quit();
    }
}
