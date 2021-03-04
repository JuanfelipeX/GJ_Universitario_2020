using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMove : MonoBehaviour
{
    [SerializeField] float velocidad;
    public float xMin, xMax, yMin, yMax;
    Rigidbody2D rig;
    public bool turbineState = false;

    //vel escenario
    public ParticleSystem velParticle;
    Parallax parallax;
    public DirectMoving estrellas;
    public int planetSpeed = -1;

    // Start is called before the first frame update
    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        parallax = GameObject.FindGameObjectWithTag("Parallax").GetComponent<Parallax>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        int inv = 1;
        Vector2 movement = new Vector2(moveH, moveV);
        if (!turbineState) // velocudad variable
        {
            velocidad =Random.Range(2f, 5f);
            //velParticle.main.simulationSpeed = 1;
            var main = velParticle.main;
            main.simulationSpeed = 1f;
            parallax.velocidadParallax = 150;
            estrellas.speed = -0.5f;
            planetSpeed = -1;
            /*velocidad = Mathf.Lerp(2f, 8f, t);
            t += Time.deltaTime*(inv);
            inv = inv * (-1);*/
        }
        else
        {
            velocidad = 10;
            var main = velParticle.main;
            main.simulationSpeed = 2f;
            parallax.velocidadParallax = 10;
            estrellas.speed = -5f;
            planetSpeed = -5;
        }

        rig.velocity = movement * velocidad;
        rig.position = new Vector2(Mathf.Clamp(rig.position.x, xMin, xMax), Mathf.Clamp(rig.position.y, yMin, yMax));


    }


    public void perder()
    {
        Vector2 pierde = new Vector2(0, 0);
        rig.velocity = pierde*0;
    }        



           
}
