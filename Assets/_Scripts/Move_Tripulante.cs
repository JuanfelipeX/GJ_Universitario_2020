using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Tripulante : MonoBehaviour
{


    public float velocidad_Tripulante;
    Rigidbody2D rb;
  

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
       
        rb.velocity = transform.right * (-1) * velocidad_Tripulante;
        Destroy(this.gameObject, 10);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("player golpeo");
            UI_hud.numeroTripulante++;
            Destroy(this.gameObject);
        }
    }
}
