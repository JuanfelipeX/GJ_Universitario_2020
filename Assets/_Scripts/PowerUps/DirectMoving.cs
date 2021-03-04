using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script moves the attached object along the Y-axis with the defined speed
/// </summary>
public class DirectMoving : MonoBehaviour {

    [Tooltip("Moving speed on Y axis in local space")]
    public float speed;

    NaveMove gm;

    private void Awake()
    {
        if (this.gameObject.CompareTag("Planeta")) { 
            gm = GameObject.FindGameObjectWithTag("Player").GetComponent<NaveMove>();
            Destroy(this.gameObject, 20);
        }
    }

    //moving the object with the defined speed
    private void Update()
    {
        if (this.gameObject.CompareTag("Planeta"))
        {
            speed = gm.planetSpeed;
        }
        transform.Translate(Vector3.up * speed * Time.deltaTime); 
    }
}
