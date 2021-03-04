using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Move : MonoBehaviour
{
    public Transform bala;
    Rigidbody2D rb;

    public  static float time_start;
    public bool apareci;
    public int golpe = 0;
    public int cont = 0;

    public GameObject special1;
    public GameObject special21;
    public GameObject special22;
    public GameObject special23;
    public Transform special3;
    public bool ataqueS1;
    public bool ataqueS2;
    public static bool termineAtq= false;
    public int ataque;
    public GameObject spawner;

    SpriteRenderer spriteBoss;
    
    void Start()
    {
        StartCoroutine(SpawnBullets());
        SpawnBullets();

    }
    void Awake()
    {
        golpe = 0;
        rb = GetComponent<Rigidbody2D>();
        apareci = true;
        ataqueS1 = false;
        ataqueS1 = false;
        termineAtq = true;
        spriteBoss = GetComponent<SpriteRenderer>();
        GameObject.FindGameObjectWithTag("Respawn").SetActive(false);
        spawner.GetComponent<EnemyGenerator>().enabled = false;

    }

    // Update is called once per frame
    IEnumerator SpawnBullets()
    {
        ataqueS1 = false;


            while (cont <= 6 && ataqueS1 == false)
            {

                yield return new WaitForSeconds(0.4f);
            
            //Instantiate(bala, this.transform.position, this.transform.rotation);
            //parte izquierda
                Instantiate(bala, new Vector3(this.transform.position.x - 2f, this.transform.position.y, this.transform.position.z), this.transform.rotation);
                Instantiate(bala, new Vector3(this.transform.position.x - 1f, this.transform.position.y, this.transform.position.z), this.transform.rotation);
                Instantiate(bala, new Vector3(this.transform.position.x - 1.5f, this.transform.position.y, this.transform.position.z), this.transform.rotation);
                
            //parte derecha
                Instantiate(bala, new Vector3(this.transform.position.x + 2f, this.transform.position.y, this.transform.position.z), this.transform.rotation);
                Instantiate(bala, new Vector3(this.transform.position.x + 1f, this.transform.position.y, this.transform.position.z), this.transform.rotation);
                Instantiate(bala, new Vector3(this.transform.position.x + 1.5f, this.transform.position.y, this.transform.position.z), this.transform.rotation);
            //Disparo especial
                if(golpe >= 9) { Instantiate(special3, this.transform.position, Quaternion.Euler(0, 0, 0)); }
            cont++;
            Debug.Log("Contador :");
            }
        
        if(cont > 6)
        {
            //Debug.Log("entre al >6");
            yield return new WaitForSeconds(3);
            cont = 0;
            StartCoroutine(SpawnBullets());
            SpawnBullets();
        }
        /*if (golpe == 3 || golpe == 6) {
            Debug.Log("entre a golpe 3");
            if (golpe ==3) { ataque = 1; }
            if(golpe == 6) { ataque = 2; }
            switch (ataque)
            {
                case 1:
                    Instantiate(special1, this.transform.position, this.transform.rotation);
                    ataque = 0;
                    break;

                case 2:
                    Instantiate(special21, this.transform.position, this.transform.rotation);
                    Instantiate(special22, this.transform.position, this.transform.rotation);
                    Instantiate(special23, this.transform.position, this.transform.rotation);
                    ataque = 0;
                    break;
            }
        }*/
        
        if (golpe == 3 && ataqueS1 == false && ataqueS2 == false)
        {
            
            Instantiate(special1, this.transform.position, this.transform.rotation);
            ataqueS1 = true;
            ataqueS2 = true;
            StartCoroutine(SpawnBullets());
            SpawnBullets();
            
        }
        if (golpe == 6 && ataqueS1 == false && ataqueS2 == false)
        {

            Instantiate(special21, this.transform.position, this.transform.rotation);
            Instantiate(special22, this.transform.position, this.transform.rotation);
            Instantiate(special23, this.transform.position, this.transform.rotation);
            ataqueS1 = true;
            ataqueS2 = true;

            StartCoroutine(SpawnBullets());
            SpawnBullets();
        }



    }
    private void FixedUpdate()
    {
        //Condicional para saber si se destruye el arma
        if (golpe >= 10)
        {
            Destroy(this.gameObject);
            EnemyGenerator.specialEnemy = false;
            UI_hud.score += 300;
        }

        time_start += Time.deltaTime;

        if (time_start < 1 && apareci == true) { this.transform.position += new Vector3(0, -0.3f, 0) * Time.deltaTime; }


        if (time_start >= 3 && ataqueS1== false && termineAtq == true)
        {
            apareci = false;

            if (time_start >= 5 && time_start <= 10)
            {
                // movx++;
                this.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;

            }


            if (time_start > 15 && time_start <= 25)
            {

                //movx--;
                this.transform.position -= new Vector3(1, 0, 0) * Time.deltaTime;


            }
            if (time_start > 30 && time_start <= 35)
            {

                //movx--;
                this.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;


            }
            if (time_start >= 35)
            {

                time_start = 0;

            }

        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            golpe++;
            StartCoroutine(damage());
            Debug.Log(golpe);

        }
    }



    IEnumerator damage()
    {
        spriteBoss.color = Color.red;
        yield return new WaitForSeconds(.2f);
        spriteBoss.color = Color.white;
        yield return new WaitForSeconds(.2f);
        spriteBoss.color = Color.red;
        yield return new WaitForSeconds(.2f);
        spriteBoss.color = Color.white;
        yield return new WaitForSeconds(.2f);
        spriteBoss.color = Color.red;
        yield return new WaitForSeconds(.2f);
        spriteBoss.color = Color.white;
        yield return null;
    }     
}
