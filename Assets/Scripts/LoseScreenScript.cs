using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScreenScript : MonoBehaviour
{
    public GameObject loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        loseScreen = transform.Find("Lose Screen").gameObject;
        loseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      if (MoveTo.instance.playerDeath == true)
        {
            loseScreen.SetActive(true);
        } else loseScreen.SetActive(false);

    }
}
