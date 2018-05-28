using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] //needs 2?
    private Transform player;

    [SerializeField]
    private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        player.transform.position = respawnPoint.transform.position;
    }

}
