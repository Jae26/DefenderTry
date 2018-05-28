using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour {

    public Vector2 velocity = new Vector2(-2, 0);
    private float spriteWidth;
    private Transform cameraTransform;
    void Start()
    {
        cameraTransform = Camera.main.transform;
       // SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>() as SpriteRenderer;
        //spriteWidth = spriteRenderer.sprite.bounds.size.x;
        //GetComponent().velocity = velocity;
        
    }
    void Update()
    {
        if ((transform.position.x + spriteWidth) < cameraTransform.position.x)
        {
            Vector3 newPos = transform.position;
            newPos.x += 2.0f * spriteWidth;
            transform.position = newPos;
        }
    }
}

