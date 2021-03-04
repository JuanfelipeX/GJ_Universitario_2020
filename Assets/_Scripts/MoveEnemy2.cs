using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidadEnemy;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        if (transform.position.x == -8)
        {
            rb.velocity = transform.TransformVector(1.2f, -0.8f, 0) * velocidadEnemy;
            Destroy(this.gameObject, 3);
        }
        if (transform.position.x == 8)
        {
            rb.velocity = transform.TransformVector(-1.2f, -0.8f, 0) * velocidadEnemy;
            Destroy(this.gameObject, 3);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("player");
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            UI_hud.score += 200;
        }
    }
}
