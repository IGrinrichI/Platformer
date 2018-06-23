using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IDragHandler, IDropHandler {

    private Vector3 homePosition;
    public GameObject[] positions;

    private void Start()
    {
        homePosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
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
}
