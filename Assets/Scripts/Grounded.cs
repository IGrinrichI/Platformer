using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour {

    public Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            player.onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.onGround = false;
    }
}
