using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroy : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;

    private GameControl gameControl;

    void Start()
    {
        GameObject gameControlObject = GameObject.FindGameObjectWithTag("GameController");
        if(gameControlObject != null)
        {
            gameControl = gameControlObject.GetComponent<GameControl>();
        }
        if(gameControl == null)
        {
            Debug.Log("Cannot not find 'GameControl' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy") //(other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            //Destroy(gameObject);
        }
        
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //Destroy(gameObject);
            gameControl.GameOver();
        }
        gameControl.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);        
    }

}
