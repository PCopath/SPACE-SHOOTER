using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomRotator : MonoBehaviour
{
    public Rigidbody rb;
    public float tumble;
    // Start is called before the first frame update
    void Start()
    {

        rb.GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
