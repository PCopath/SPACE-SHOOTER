using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveShooting : MonoBehaviour
{
    public Rigidbody rb;
    public float speed; 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
