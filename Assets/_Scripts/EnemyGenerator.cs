using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject enemigo;
    public GameObject enemigo2;
    public GameObject enemigoEspecial;
    public GameObject finalBoss;

    public int limiteMinimo;
    public int limiteMaximo;

    public int enemyCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public static bool specialEnemy;

   
 

    //public int cont = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
        SpawnWaves();
        specialEnemy = false;
     
    }
   

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 SpawnPoints = new Vector3(Random.Range(limiteMinimo, limiteMaximo), this.gameObject.transform.position.y, 0);
                Instantiate(enemigo, SpawnPoints, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            //yield return new WaitForSeconds(waveWait);

            if (UI_hud.numeroTripulante >= 5)
            {
                for (int i = 0; i < 3; i++)
                {
                    //Debug.Log("Apareci en la esquina");
                    yield return new WaitForSeconds(0.5f);
                    Vector3 SpawnPoints = new Vector3(-8, this.gameObject.transform.position.y, 0);
                    Instantiate(enemigo2, SpawnPoints, Quaternion.identity);
                    yield return new WaitForSeconds(spawnWait);
                    Vector3 SpawnPoints2 = new Vector3(8, this.gameObject.transform.position.y, 0);
                    Instantiate(enemigo2, SpawnPoints2, Quaternion.identity);
                    //yield return new WaitForSeconds(spawnWait);
                }
            }

           /* if ( specialEnemy == false && UI_hud.numeroTripulante == 10 || UI_hud.numeroTripulante == 15 || UI_hud.numeroTripulante == 20 )
            {
                specialEnemy = true;
                Vector3 SpawnPoints = new Vector3(-8, this.gameObject.transform.position.y, 0);
                Instantiate(enemigoEspecial, SpawnPoints, Quaternion.identity);
                
            }*/

            if (specialEnemy == false)
            {
                Vector3 SpawnPoints = new Vector3(-8, this.gameObject.transform.position.y, 0);
                Vector3 SpawnPointsF = new Vector3(0, 9, 0);
                switch (UI_hud.numeroTripulante)
                {
                    case 10:
                        specialEnemy = true;
                        Instantiate(enemigoEspecial, SpawnPoints, Quaternion.identity);
                        break;

                    case 15:
                        specialEnemy = true;
                        Instantiate(enemigoEspecial, SpawnPoints, Quaternion.identity);
                        break;

                    case 20:
                        specialEnemy = true;
                        Instantiate(finalBoss, SpawnPointsF, Quaternion.identity);
                        break;
                }

            }
            
        }

    }
    
}
