using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    public float life;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, life);
	}
	
	
}
