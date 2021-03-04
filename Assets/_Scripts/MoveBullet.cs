using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{

    Rigidbody2D rig;
    public float velocidadBala;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();

    }



    // Start is called before the first frame update
    void Start()
    {
        rig.velocity = transform.up * velocidadBala;
        Destroy(this.gameObject, 2);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            
        }
        if (collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            
        }
    }

}
