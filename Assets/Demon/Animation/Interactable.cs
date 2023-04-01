using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;
    public int ID;

    void Start()
    {
        ID = Random.Range(0, 999999);
    }

    void Update()
    {
        if (ItemInteraction.instance.interacted == true)
        {
            // Check if this game object is the one being interacted with
            if (ItemInteraction.instance.selectedItem == gameObject)
            {
                if (gameObject.tag == "Door")
                {
                    SceneManager.LoadScene("Win");
                } 
                else
                {
                    Destroy(gameObject);
                    ItemInteraction.instance.itemsLeft--;
                    ItemInteraction.instance.interacted = false;
                }
            }
        }
    }
}
