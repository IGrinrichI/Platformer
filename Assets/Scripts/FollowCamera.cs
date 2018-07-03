using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

<<<<<<< HEAD
    public Transform player;
    public float followSpeed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, player.position + Vector3.back * 10, Time.deltaTime * followSpeed);
=======
    public GameObject player;
    public float smooth;
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * smooth) + Vector3.back;
>>>>>>> master
	}
}
