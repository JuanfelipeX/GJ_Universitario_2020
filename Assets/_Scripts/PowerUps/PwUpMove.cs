using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PwUpMove : MonoBehaviour
{

    public float velocidadPwUp;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
        if (this.gameObject.CompareTag("Propulsor"))
        {
            velocidadPwUp = 1.5f;
        }
        
        rb.velocity = transform.up * (-1) * velocidadPwUp;
        Destroy(this.gameObject, 8);
    }
}
