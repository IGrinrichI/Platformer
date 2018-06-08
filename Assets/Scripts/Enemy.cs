using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Transform start;
    public Transform end;
    public float speed;
    private float t = 0;
    private bool reverse = true;
    private Vector3 startPoint;
    private Vector3 endPoint;

    private void Start()
    {
        startPoint = start.position;
        endPoint = end.position;
    }

    void Update () {
        t += Time.deltaTime * speed;
        if (reverse)
        {
            if (t < 1)
            {
                transform.position = Vector3.Lerp(startPoint, endPoint, t);
            }
            else
            {
                t = 0;
                reverse = false;
                transform.position = endPoint;
            }
        }
        else
        {
            if (t < 1)
            {
                transform.position = Vector3.Lerp(endPoint, startPoint, t);
            }
            else
            {
                t = 0;
                reverse = true;
                transform.position = startPoint;
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = Vector3.zero;
        }
    }
}
