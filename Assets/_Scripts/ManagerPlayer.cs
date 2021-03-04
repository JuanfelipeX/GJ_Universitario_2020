using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPlayer : MonoBehaviour
{

    public GameObject[] PowerUps;
    public AudioClip[] clipUpgrade;
    public AudioClip[] clipDowngrade;
    public AudioClip[] clipState;
    public AudioClip clipPana;

    AudioSource audioManager;
    public Sprite[] naves;
    public int powerState = 0; // 0 sin PwUp, 1 propulsor, 2 PrimerArma, 3 SegundaArma, 4 ArmaEspecial
    SpriteRenderer spriteNave;
    NaveMove player;
    public GameObject canvasPerder;
    BoxCollider2D colliderPlayer;
    public AudioSource audioScene;
    public AudioSource audiomanager2;

    public GameObject[] animMuerte;

    private void Awake()
    {
        spriteNave = gameObject.GetComponent<SpriteRenderer>();
        player = gameObject.GetComponent<NaveMove>();
        audioManager = gameObject.GetComponent<AudioSource>();
        colliderPlayer= gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

        print("power " + powerState);
        if (powerState > 3) powerState = 3;
        if (powerState < 0) powerState = 0;

        if(!PowerUps[0].activeSelf  && (PowerUps[1].activeSelf || PowerUps[2].activeSelf) ) powerState = 0;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Propulsor"))
        {
            PowerUps[0].SetActive(true);
            //powerState = 1;
            powerState++;
            spriteNave.sprite = naves[1];
            audioManager.clip = clipUpgrade[0];
            audioManager.Play();
            audiomanager2.clip = clipDowngrade[1];
            audiomanager2.Play();
            Destroy(col.gameObject);
        }

        if (col.CompareTag("Arma1"))
        {
            PowerUps[1].SetActive(true);
            //powerState = 2;
            powerState++;
            audioManager.clip = clipUpgrade[1];
            audioManager.Play();
            Destroy(col.gameObject);
        }

        /*if (col.CompareTag("Arma1") && !PowerUps[0].activeSelf)
        {
            PowerUps[1].SetActive(true);
            powerState = 0;
            Destroy(col.gameObject);
        }*/

        if (col.CompareTag("Arma2"))
        {
            PowerUps[2].SetActive(true);
            PowerUps[1].SetActive(false);
            //powerState = 3;
            powerState++;
            audioManager.clip = clipUpgrade[2];
            audioManager.Play();
            Destroy(col.gameObject);
        }

        if (col.CompareTag("ArmaEsp"))
        {
            PowerUps[3].SetActive(true);
            audioManager.clip = clipUpgrade[3];
            audioManager.Play();
            Destroy(col.gameObject);
        }

        if (col.CompareTag("Tripulante"))
        {
            audioManager.clip = clipPana;
            audioManager.Play();
        }

        
        if (col.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            if(powerState == 0)
            {
                StartCoroutine(Muerte());

            }else if (powerState == 1)
            {
                PowerUps[0].SetActive(false);
                player.turbineState = false;
                spriteNave.sprite = naves[0];
                audiomanager2.clip = clipDowngrade[2];
                audiomanager2.Play();
                StartCoroutine(damage());
                powerState --;
            }
            else if  (PowerUps[1].activeSelf && !PowerUps[0].activeSelf)
            {
                PowerUps[0].SetActive(false);
                player.turbineState = false;
                spriteNave.sprite = naves[0];
                StartCoroutine(damage());
                powerState--;
            }
            else if (powerState == 2)
            {
                PowerUps[1].SetActive(false);
                StartCoroutine(damage());
                powerState --;
            }
            else if (powerState == 3)
            {
                PowerUps[2].SetActive(false);
                PowerUps[1].SetActive(true);
                StartCoroutine(damage());
                powerState --;
            }

            audioManager.clip = clipDowngrade[0];
            audioManager.Play();

            // PowerUps Especiales
            if (PowerUps[3].activeSelf) PowerUps[3].SetActive(false); // si esta activo el poder especial y es golpeado, lo pierde
            DestruirPwUpACtivos();

        }

        
    }


    void DestruirPwUpACtivos() // busca todos los objetos power up en escena y los elimina
    {
        GameObject pw1;
        GameObject pw2;
        GameObject pw3;
        pw1 = GameObject.FindGameObjectWithTag("Propulsor");
        pw2 = GameObject.FindGameObjectWithTag("Arma1");
        pw3 = GameObject.FindGameObjectWithTag("Arma2");

        if (pw1 != null) { Destroy(pw1.gameObject); }
        if (pw2 != null) { Destroy(pw2.gameObject); }
        if (pw3 != null) { Destroy(pw3.gameObject); }
        
    }


    IEnumerator damage()
    {
        colliderPlayer.enabled = false;
        spriteNave.enabled = false;
        yield return new WaitForSeconds(.1f);
        spriteNave.enabled = true;
        yield return new WaitForSeconds(.1f);
        spriteNave.enabled = false;
        yield return new WaitForSeconds(.1f);
        spriteNave.enabled = true;
        yield return new WaitForSeconds(.08f);
        spriteNave.enabled = false;
        yield return new WaitForSeconds(.08f);
        spriteNave.enabled = true;
        yield return new WaitForSeconds(.05f);
        spriteNave.enabled = false;
        yield return new WaitForSeconds(.05f);
        spriteNave.enabled = true;
        yield return new WaitForSeconds(.05f);
        spriteNave.enabled = false;
        yield return new WaitForSeconds(.05f);
        spriteNave.enabled = true;
        yield return new WaitForSeconds(.1f);
        colliderPlayer.enabled = true;

    }



    IEnumerator Muerte()
    {
        player.perder();
        player.enabled = false;
        audioScene.Stop();
        audioManager.clip = clipState[0];
        audioManager.Play();
        colliderPlayer.enabled = false;
        spriteNave.enabled = false;
        yield return new WaitForSeconds(.1f);
        spriteNave.enabled = true;
        yield return new WaitForSeconds(.1f);
        spriteNave.enabled = false;
        yield return new WaitForSeconds(.1f);
        spriteNave.enabled = true;
        yield return new WaitForSeconds(.08f);
        spriteNave.enabled = false;
        yield return new WaitForSeconds(.08f);
        spriteNave.enabled = true;
        yield return new WaitForSeconds(.05f);
        spriteNave.enabled = false;
        yield return new WaitForSeconds(.05f);
        spriteNave.enabled = true;
        yield return new WaitForSeconds(.05f);
        spriteNave.enabled = false;
        yield return new WaitForSeconds(.05f);
        spriteNave.enabled = true;
        yield return new WaitForSeconds(.05f);
        spriteNave.enabled = false;
        
        animMuerte[0].SetActive(true);
        yield return new WaitForSeconds(.5f);
        animMuerte[1].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        canvasPerder.SetActive(true);
        Time.timeScale = 0;
        yield return null;
    }       

}
