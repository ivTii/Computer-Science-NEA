using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Items : MonoBehaviour
{
    public bool startEndGame;
    int randomDoor;

    public GameObject door1, door2, door3, door4, door5;

    // Start is called before the first frame update
    void Start()
    {
        randomDoor = Random.Range(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (ItemInteraction.instance.itemsLeft == 0)
        {
            startEndGame = true;
        }
        else startEndGame = false;

        if (startEndGame)
        {
            MoveTo.instance.proximityRadius = 50f;
            if (randomDoor == 0)
            {
                door1.SetActive(true);
            }
            else if (randomDoor == 1)
            {
                door2.SetActive(true);
            }
            else if (randomDoor == 2)
            {
                door3.SetActive(true);
            }
            else if (randomDoor == 3)
            {
                door4.SetActive(true);
            }
            else
            {
                door5.SetActive(true);
            }
        }
    }
}
