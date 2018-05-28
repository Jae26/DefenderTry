using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsControl : MonoBehaviour
{
    [SerializeField] private Transform player; //

    //public float speed;
    private Vector3 target;

    public GameObject enemyLaser; //laser object
    public Transform laserSpawn; //laser spawning point
    public float fireRate; //time between shots
    public float delay; //start time of shots

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector3(player.position.x, player.position.y);

        InvokeRepeating("Fire", delay, fireRate);
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, fireRate * Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(enemyLaser);
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(enemyLaser);
        }
    }*/

    void Fire()
    {
        if (fireRate <= 0) {
            print("pew pew");
            Instantiate(enemyLaser, laserSpawn.position, laserSpawn.rotation); //create laser
            fireRate = delay; //time when to shoot
    }else{
        
        fireRate -= Time.deltaTime;
       }
	}
}
