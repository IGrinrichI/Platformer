﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rig;
    private bool onGround = true;
    private bool isFire = true;
    public GameObject Bullet;
    private bool side = true;
    private Ray2D ray;
    private bool das = true;
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update () {
        float w = Input.GetAxis("Horizontal");
        float h = Input.GetAxis("Vertical");
        side = w < 0 ? false : w > 0 ? true : side;
        if (w != 0)
        {
            rig.AddForce(Vector2.right * w * 10);
        }
        if (h > 0 && rig.velocity.y == 0 && onGround == true)
        {
            rig.AddForce(new Vector2(0, 300));
            onGround = false;
        }
        if (gameObject.transform.position.x < -10.25 || gameObject.transform.position.x > 10.25)
        {
            if (gameObject.transform.position.x < 0)
            {
                gameObject.transform.position = new Vector2(-10.2f, gameObject.transform.position.y);
            }
            else
            {
                gameObject.transform.position = new Vector2(10.2f, gameObject.transform.position.y);
            }
            rig.velocity = new Vector2(-rig.velocity.x, 0);
        }
        if (Input.GetButton("Jump") && isFire == true)
        {
            if (side)
            {
                GameObject bullet = Instantiate(Bullet, new Vector2(transform.position.x + .7f, transform.position.y), transform.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(500, 0));
            }
            else
            {
                GameObject bullet = Instantiate(Bullet, new Vector2(transform.position.x - .7f, transform.position.y), transform.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500, 0));
            }
            isFire = false;
            Invoke("IsFire", .2f);
        }
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - .54f), Vector2.down, .1f);
        if (hit.collider != null && das)
        {
            OnGround();
            das = false;
            Invoke("Das",1f);
        }
	}

    private void Das()
    {
        das = true;
    }

    private void IsFire()
    {
        isFire = true;
    }

    private void OnGround()
    {
        onGround = true;
    }

}
