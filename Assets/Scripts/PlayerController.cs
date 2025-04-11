using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float xmin, xmax, zmin, zmax;
    public float tilt;


    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    public AudioSource shootSound;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shootSound = GetComponent<AudioSource>();


    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.velocity = movement * speed;
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, xmin, xmax), 0, Mathf.Clamp(rb.position.z, zmin, zmax));
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);



    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            shootSound.Play();
        }


    }
}
