using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DESTROYBYCONTACT : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gameController;
    public int scoreValue;

    void Start()
    {
        
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("gormedi");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" )
        {


            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver(); // Oyuncu çarpıştığında Game Over'ı tetikle
        }

        gameController.AddScore();
        Destroy(other.gameObject);
        Destroy(gameObject);
        



    }

    void Update()
    {

        
    }
}
