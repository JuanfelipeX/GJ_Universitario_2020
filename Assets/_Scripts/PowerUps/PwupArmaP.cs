using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PwupArmaP : MonoBehaviour
{
    public Transform bala;
    AudioSource audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioManager.PlayOneShot(audioManager.clip);
            Instantiate(bala, this.transform.position, this.transform.rotation);
        }
    }
}
