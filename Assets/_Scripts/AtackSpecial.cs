using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackSpecial : MonoBehaviour
{
    string nombreS;
    float z;
    float z1;
    Rigidbody2D rig;
    // Start is called before the first frame update
    void Awake()
    {
        //Instantiate(special1, this.transform.position, this.transform.rotation);
        nombreS = this.gameObject.name;
        Debug.Log(nombreS);
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //---------------------primer ataque-------------------------------
        if (nombreS == "Special1(Clone)")
        {
            if (z < 60) {
                z += Time.deltaTime * 10;
                this.transform.rotation = Quaternion.Euler(0, 0, -60 + z);

            }
            else if (z >= 60 && z <= 120)
            {
                z += Time.deltaTime * 10;
                this.transform.rotation = Quaternion.Euler(0, 0, 120 - z);
                if (z >= 120)
                {
                    Destroy(this.gameObject);
                    Boss_Move.termineAtq = true;
                }
            }

        }
        //-----------------------segundo ataque-----------------------------
        if (nombreS == "Special2.1(Clone)")
        {
            if (z1 < 20)
            {
                z1 += Time.deltaTime * 10;
                this.transform.rotation = Quaternion.Euler(0, 0, -60 + z1);

            }
            else if (z1 >= 20)
            {
                Debug.Log("Entre al else if");
                z1 += Time.deltaTime * 10;
                this.transform.rotation = Quaternion.Euler(0, 0, -40 - z1);
                if (z1 >= 40)
                {
                    Destroy(this.gameObject);
                    Boss_Move.termineAtq = true;
                }
            }
        }


        if (nombreS == "Special2.2(Clone)")
        {
            if (z1 < 20)
            {
                z1 += Time.deltaTime * 10;
                this.transform.rotation = Quaternion.Euler(0, 0, z1);

            }
            else if (z1 >= 20)
            {
                Debug.Log("Entre al else if");
                z1 += Time.deltaTime * 10;
                this.transform.rotation = Quaternion.Euler(0, 0, 20 - z1);
                if (z1 >= 40)
                {
                    Destroy(this.gameObject);
                    Boss_Move.termineAtq = true;
                }
            }

        }
        if (nombreS == "Special2.3(Clone)")
        {
            if (z1 < 20)
            {
                z1 += Time.deltaTime * 10;
                this.transform.rotation = Quaternion.Euler(0, 0, 60 + z1);

            }
            else if (z1 >= 20)
            {
                Debug.Log("Entre al else if");
                z1 += Time.deltaTime * 10;
                this.transform.rotation = Quaternion.Euler(0, 0, 80 - z1);
                if (z1 >= 40)
                {
                    Destroy(this.gameObject);
                    Boss_Move.termineAtq = true;
                }
            }

        }
        //-----------------------tercer ataque-----------------------------
        if (nombreS == "BulletS") {

            rig.velocity = transform.up * (-1)*2 ;
            Destroy(this.gameObject, 4);
        }
        if (nombreS == "BulletS (1)")
        {

            rig.velocity = transform.up * (-1) * 2;
            Destroy(this.gameObject, 4);
        }
        if (nombreS == "BulletS (2)")
        {

            rig.velocity = transform.up * (-1) * 2;
            Destroy(this.gameObject, 4);
        }
        if (nombreS == "BulletS (3)")
        {

            rig.velocity = transform.up * (-1) * 2;
            Destroy(this.gameObject, 4);
        }
        if (nombreS == "BulletS (4)")
        {

            rig.velocity = transform.up * (-1) * 2;
            Destroy(this.gameObject, 4);
        }


    }

}
