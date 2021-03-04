using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controladoScri : MonoBehaviour
{
    public GameObject countDown;
    public GameObject nave;

    public void Awake()
    {
        nave.SetActive(false);
    }
    void Start()
    {
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;


        countDown.SetActive(false);
        nave.SetActive(true);
        Time.timeScale = 1;
    }
}
