using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplate : MonoBehaviour {
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player") collision.GetComponent<Player>().onGround = false;
    }
}
