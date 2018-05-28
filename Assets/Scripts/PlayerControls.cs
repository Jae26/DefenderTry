using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //needed to view in inspector

public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerControls : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;    
    public Boundary boundary;

    public GameObject jet;
    public Transform jetSpawn;
    public GameObject laserShot;
    public Transform laserSpawn;

    public float TurnSpeed = 100f;
    public float fireRate;
    public AudioSource audioInput;

    private float nextFire;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioInput = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(laserShot, laserSpawn.position, laserSpawn.rotation); //Game Object, vector3, quaternion
            audioInput.Play();
        }               
    }



    private void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        if (Input.GetKey(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(0, -90, 0);
            rb.velocity = new Vector3(0, 10, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );

    }

}
