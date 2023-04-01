using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInteraction : MonoBehaviour
{
    public LayerMask interactableLayermask = 10;
    Interactable interactable;

    public float itemsToCollect = 5f;
    public float itemsCollected;
    public float itemsLeft;

    public static ItemInteraction instance;
    public bool interacted;
    public GameObject selectedItem; // added variable

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        itemsLeft = itemsToCollect - itemsCollected;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableLayermask))
        {
            if (hit.collider.GetComponent<Interactable>() != false)
            {
                if (interactable == null || interactable.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                    selectedItem = hit.collider.gameObject; // set the selectedItem
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interacted = true;
                    interactable.onInteract.Invoke();
                }
                else interacted = false;
            }
        }
    }
}
