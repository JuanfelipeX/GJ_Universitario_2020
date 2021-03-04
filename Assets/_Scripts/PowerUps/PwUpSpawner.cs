using System.Collections;
using UnityEngine;

public class PwUpSpawner : MonoBehaviour
{
    public GameObject [] PowerUps;
    public int limiteMinimo;
    public int limiteMaximo;

    public int PwUpCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;


    int PwUpActual = 0;
    ManagerPlayer player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ManagerPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
        SpawnWaves();
    }

    private void Update()
    {
        PwUpActual = player.powerState;
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < PwUpCount; i++)
            {
                Vector3 SpawnPoints = new Vector3(Random.Range(limiteMinimo, limiteMaximo), this.gameObject.transform.position.y, 0);
                Instantiate(PowerUps[PwUpActual], SpawnPoints, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }

    }
}
