using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawn : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] enemy;
    int randomSpawnPoint, randomEnemy;
    public static bool spawnAllowed;
    public int enemyCount;

    public float startWait;
    public float waveWait;
    public float spawnWait;


    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 1f);
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                randomSpawnPoint = Random.Range(0, spawnPoints.Length);
                randomEnemy = Random.Range(0, enemy.Length);
                Instantiate(enemy[randomEnemy], spawnPoints[randomSpawnPoint].position,
                    Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);

            }
        }
    }


}
