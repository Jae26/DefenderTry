

using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
/*********************************************/
    /************NOT IN USE******/
/********************************************/
public class EnemySpawn : MonoBehaviour
{
    //enemy creation and movement towards player
    public GameObject[] enemy;
    public GameObject player;
    public int enemyCount;
    public Transform enemyPos;
    public Transform target;
    //public float flightDistance = 5f;
    //public float smoothTime = 10f;
    //public Vector3 spawnValue;
    //public float startWait;
    //public float waveWait;

    public float speed;
    public float rotateSpeed;
    public Vector3 playerPos = new Vector3(0, 0, 0);
    private Vector3 speedRotate = Vector3.left * 25f;

    private bool gameOver;
    private bool restart;

    private Vector3 smoothVelocity = Vector3.zero;

    //
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    //


    void Start()
    {
        //gameOver = false;
        //restart = false;
        player.transform.position = playerPos;
        StartCoroutine(SpawnWaves());
        //StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
        Quaternion.LookRotation(playerPos - transform.position), rotateSpeed * Time.deltaTime);

        //transform.LookAt(playerPos, Vector3.up);
        //transform.Translate(speed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime);
        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        //transform.position = Vector3.Lerp(transform.position, target.position, 0.01f);


        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Game");
            }
        }

    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {

            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restart = true;
                break;
            }
        }
    }


    /*
	void Update ()
    {
        
        /*transform.LookAt(player);
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < flightDistance)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
        }
    }

    void Update()


    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Level");
            }
        }


        Vector3 targetPosition = player.transform.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);

        float distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (distance >= 2)
        {
            transform.Translate(Vector3.forward * speed);
            transform.Translate(Vector2.MoveTowards(enemy.transform.position,
                player.transform.position, flightDistance) * speed * Time.deltaTime);
        }
    }*/

    /*void SpawnEnemy() //IEnumerator SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y), spawnValue.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(enemy, spawnPosition, spawnRotation);


        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                GameObject enemies = enemy[Random.Range(0, enemy.Length)];
                Vector3 spawnPos = new Vector3(Random.Range(-spawnValue.x, spawnValue.x),
                    spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemies, spawnPos, spawnRotation);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restart = true;
                //break;
            }
        //}
    }

    public void GameOver()
    {
        gameOver = true;
    }*/
}
