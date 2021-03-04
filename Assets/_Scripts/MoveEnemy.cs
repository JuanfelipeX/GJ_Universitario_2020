using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{

    public float velocidadEnemy;
    Rigidbody2D rb;
    public int cont;
    int random;

    public Sprite Asteroid1;
    public Sprite Asteroid2;
    public Sprite Asteroid3;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cont = 0;
        random = Random.Range(1, 3);
        Debug.Log("El numero randon es :" + random);
        switch (random)
        {
            case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Asteroid1;
                break;
            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Asteroid2;
                break;
            case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Asteroid3;
                break;

        }
    }

    private void Start()
    {
        rb.velocity = transform.up * (-1) * velocidadEnemy;
        Destroy(this.gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (UI_hud.numeroTripulante >15)
        {
            if(cont >= 4)
            {
                Destroy(this.gameObject);
                UI_hud.score += 200;
            }
        }
        else if (col.CompareTag("Bullet"))
        {
            
            Destroy(this.gameObject);
            UI_hud.score += 100;
        }
        cont++;
    }
}
