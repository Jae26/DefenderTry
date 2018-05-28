using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    private Transform player;
    public float speed;
    public float stoppingDistance;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();        
    }

    void Update()
    {
        /*Look at Player*/

        if (player != null)//will continuously be reference, if statement placed to "stop the search"
        {
            Vector3 relativePos = player.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relativePos);


            /**/

            if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }
        
    }

    
}
