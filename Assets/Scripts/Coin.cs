using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public GameObject obj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(GameObject slot in GameObject.FindGameObjectsWithTag("ItemPosition"))
        {
            if (slot.transform.childCount == 0)
            {
                Instantiate(obj).transform.parent = GameObject.Find("Inventory").transform;
                break;
            }
        }
        
    }
}
