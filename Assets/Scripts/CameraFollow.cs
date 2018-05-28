using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

	void LateUpdate ()
    {
        if(target != null)
        transform.position = new Vector3(target.position.x, 0.0f, -10f);
		
	}
}
