using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private Rigidbody2D rig;
    public bool onGround = true;
    private bool isFire = true;
    public GameObject Bullet;
    private bool side = true;
    private Ray2D ray;
    public int degrodNum;
    public Text degrodText;

    // Use this for initialization
    void Start () {
        degrodText.text = "Дегроданство: " + degrodNum;
        rig = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        float w = Input.GetAxis("Horizontal");
        float h = Input.GetAxis("Vertical");
        side = w < 0 ? false : w > 0 ? true : side;

        if (w != 0)
        {
            rig.velocity = new Vector2(w * 5f, rig.velocity.y);
        }

        if (h > 0 && onGround)
        {
            rig.velocity = new Vector2(rig.velocity.x, 6f);
        }
        //Выход за границы ограничен
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
        //Стрельба
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
        //Биение головой об стену (условно)
        if (onGround)
        {
            RaycastHit2D hitside = side == true ? Physics2D.Raycast(new Vector2(transform.localPosition.x + .41f, transform.localPosition.y), Vector2.right, .1f) : Physics2D.Raycast(new Vector2(transform.localPosition.x - .41f, transform.localPosition.y), Vector2.left, .1f);
            if (hitside.collider && Input.GetKey(KeyCode.E))
            {
                if (!hitside.collider.isTrigger) CrushHead();
            }
        }
    }

    private void IsFire()
    {
        isFire = true;
    }

    private void CrushHead()
    {
        Debug.Log("Head is Crushed!");
        degrodNum += 10;
        degrodText.text = "Дегроданство: " + degrodNum;
    }
}
