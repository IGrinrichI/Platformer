using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public GameObject player;
    public float smooth;
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * smooth) + Vector3.back;
	}
}
