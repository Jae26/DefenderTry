using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDestroy : MonoBehaviour
{
    public GameObject laser;
    public float interval;

	void Start ()
    {
        Destroy(laser, interval);
	}
	
	void Update () {
		
	}
}
