using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private void Start()
    {
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BouncyWall")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = -gameObject.GetComponent<Rigidbody2D>().velocity;
        }
        else if(collision.GetComponent<BoxCollider2D>().isTrigger){

        }
        else
        {
            Destroy(gameObject);
        }
    }

}
