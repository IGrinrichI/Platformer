using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

<<<<<<< HEAD
public class Inventory : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler {

    private Vector3 homePosition;
    public GameObject[] positions;
    public int curPos;
    public Transform par;
    public Item item;
    private Transform inventory;
=======
public class Inventory : MonoBehaviour, IDragHandler, IDropHandler {

    private Vector3 homePosition;
    public GameObject[] positions;
>>>>>>> master

    private void Start()
    {
        homePosition = transform.position;
<<<<<<< HEAD
        positions = GameObject.FindGameObjectsWithTag("ItemPosition");
        for (int i = 0; i < positions.Length; i++)
        {
            if (Mathf.Abs(Mathf.Abs(positions[i].transform.position.x) - Mathf.Abs(transform.position.x)) < 25 && Mathf.Abs(Mathf.Abs(positions[i].transform.position.y) - Mathf.Abs(transform.position.y)) < 25)
            {
                if (positions[i].transform.childCount == 0)
                {
                    transform.parent = positions[i].transform;
                }
                else
                {
                    positions[i].transform.GetChild(0).position = par.position;
                    positions[i].transform.GetChild(0).parent = par;
                    transform.parent = positions[i].transform;
                }
                homePosition = positions[i].transform.position;
                break;
            }
        }
        inventory = GameObject.Find("Inventory").transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        par = transform.parent;
        transform.parent = inventory;
=======
>>>>>>> master
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
<<<<<<< HEAD
        for(int i = 0; i < positions.Length; i++)
        {
            if (Mathf.Abs(Mathf.Abs(positions[i].transform.position.x) - Mathf.Abs(transform.position.x)) < 25 && Mathf.Abs(Mathf.Abs(positions[i].transform.position.y) - Mathf.Abs(transform.position.y)) < 25)
            {
                if (positions[i].transform.childCount == 0)
                {
                    transform.parent = positions[i].transform;
                }
                else
                {
                    positions[i].transform.GetChild(0).position = par.position;
                    positions[i].transform.GetComponentInChildren<Inventory>().homePosition = par.position;
                    positions[i].transform.GetChild(0).parent = par;
                    transform.parent = positions[i].transform;
                }
                homePosition = positions[i].transform.position;
                break;
            }
            if (i == positions.Length - 1)
            {
                transform.parent = par;
            }
        }
        transform.position = homePosition;
    }

=======
        foreach(GameObject pos in positions)
        {
            if (Mathf.Abs(Mathf.Abs(pos.transform.position.x) - Mathf.Abs(transform.position.x)) < 50 && Mathf.Abs(Mathf.Abs(pos.transform.position.y) - Mathf.Abs(transform.position.y)) < 50)
            {
                homePosition = pos.transform.position;
                break;
            }
        }
        transform.position = homePosition;
    }
>>>>>>> master
}
