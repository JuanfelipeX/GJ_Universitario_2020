using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PwupTurbina : MonoBehaviour
{
    NaveMove player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<NaveMove>();
    }

    // Update is called once per frame
    void Update()
    {
        player.turbineState = true;
    }
}
