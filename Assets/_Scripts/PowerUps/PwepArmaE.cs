using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PwepArmaE : MonoBehaviour
{
    public GameObject balasEspeciales;
    AudioSource audioManager;
    
    // Start is called before the first frame update
    void Start()
    {
        audioManager = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            audioManager.Play();
            Instantiate(balasEspeciales, this.transform.position, this.transform.rotation);
            this.gameObject.SetActive(false);

        }
    }
}
