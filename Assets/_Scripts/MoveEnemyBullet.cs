using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyBullet : MonoBehaviour
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
        rig.velocity = transform.up*(-2) * velocidadBala;
        Destroy(this.gameObject, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            
        }
    }
}
