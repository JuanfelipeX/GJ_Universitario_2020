using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerPerder : MonoBehaviour
{


    public void Replay()
    {
        StartCoroutine(botonT("_Scenes/lvl"));
    }

    public void menu()
    {
        StartCoroutine(botonT("_Scenes/Menu"));
    }


    IEnumerator botonT(string escena)
    {
        
        print(escena);
        //yield return new WaitForSeconds(0.5f);
        
        Time.timeScale = 1;
        
        SceneManager.LoadScene(escena);
        yield return null;
    }       
}
