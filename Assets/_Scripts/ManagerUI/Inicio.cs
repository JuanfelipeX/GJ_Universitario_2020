using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio : MonoBehaviour
{

    public GameObject[] todo;
    public TW_MultiStrings_RandomText text;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame



    public void function()
    {
        for (int i = 0; i < todo.Length; i++)
        {
            todo[i].SetActive(true);

        }
        this.gameObject.SetActive(false);
    }     
}
