using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripulanteSpawner : MonoBehaviour
{

    public GameObject tripulante;
    public int rangoMinimo;
    public int rangoMaximo;

    public int tripulanteCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
        SpawnWaves();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < tripulanteCount; i++)
            {
                Vector3 SpawnPoints = new Vector3(this.gameObject.transform.position.x,  Random.Range(rangoMinimo, rangoMaximo), 0);
                Instantiate(tripulante, SpawnPoints, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }

    }
}
