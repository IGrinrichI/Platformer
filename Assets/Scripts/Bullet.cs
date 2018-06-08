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
        else if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            player.degrodNum++;
            player.degrodText.text = "Дегроданство: " + player.degrodNum;
            Destroy(gameObject);
        }
        else if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if(collision.GetComponent<BoxCollider2D>()){
            if (!collision.GetComponent<BoxCollider2D>().isTrigger)
            {
                Destroy(gameObject);
            }
        }
    }

}
