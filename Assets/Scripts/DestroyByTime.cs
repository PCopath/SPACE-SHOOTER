using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{

    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
