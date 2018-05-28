using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    public float scrollSpeed = 0;
    public float tileSizeX;
    private Vector3 startPosition;
    //public static BackGroundScroll startPosition;

    float pos = 0;

	void Start ()
    {
        startPosition = transform.position;	
        //startPosition = this;
	}
	
	void Update ()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX);
        //transform.position = startPosition + Vector3.Lerp * newPosition;
	}

    /*public void Update()
    {
        pos += scrollSpeed;
        if (pos > 1.0f)
            pos -= 1.0f;

        //GetComponent<Renderer>().material.mainTextureOffset = new Vector2(pos, 0);
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * scrollSpeed)%1, 0f);

    }*/
}
