using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    [SerializeField] AudioSource fx;
    public AudioClip hover;
    public AudioClip click;


    private void Start()
    {
        fx = gameObject.GetComponent<AudioSource>();

    }
    public void hoverSfx()
    {
        fx.PlayOneShot(hover);
    }
    
    public void clickSfx()
    {
        fx.PlayOneShot(click);
    }        
}
