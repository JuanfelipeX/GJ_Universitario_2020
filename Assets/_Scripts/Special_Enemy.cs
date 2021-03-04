using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Enemy : MonoBehaviour
{
    public Transform bala;
    public int cont =0;
    Rigidbody2D rb;
    public float time_start;
    public bool apareci;
    public int golpe = 0;
  
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
        
    }

    // Update is called once per frame
    IEnumerator SpawnBullets()
    {
        while (true)
        {
          
                yield return new WaitForSeconds(2);
                Instantiate(bala, this.transform.position, this.transform.rotation);
                Instantiate(bala, new Vector3(this.transform.position.x - 0.5f, this.transform.position.y, this.transform.position.z), this.transform.rotation);
                Instantiate(bala, new Vector3(this.transform.position.x + 0.5f, this.transform.position.y, this.transform.position.z), this.transform.rotation);
               
           
        }
        
    }
    private void FixedUpdate()
    {
        //Condicional para saber si se destruye el arma
        if (golpe >= 6)
        {
            Destroy(this.gameObject);
            EnemyGenerator.specialEnemy = false;
            UI_hud.score += 300;
        }

        time_start += Time.deltaTime;

        if(time_start < 3 && apareci == true) { this.transform.position += new Vector3(0, -1, 0) * Time.deltaTime; }
      

        if (time_start >= 3)
            {
            apareci = false;

                if (time_start >= 5 &&time_start <= 20  )
                {
                   // movx++;
                    this.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
                    
                }

               
                if (time_start > 25 && time_start <= 40)
                {

                    //movx--;
                    this.transform.position -= new Vector3(1, 0, 0) * Time.deltaTime;
                  

                }
                if (time_start >= 40)
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
            Debug.Log(golpe);
            
        }
    }
}
