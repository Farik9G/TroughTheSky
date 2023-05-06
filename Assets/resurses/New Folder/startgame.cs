using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startgame : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenu.startgame == 1)
        {
            player.transform.position = new Vector3(-3.824f, -3.216f, 1.09f);
            metals1.metal1 = 0f;
            woods1.wood1 = 0f;
            rubers1.rubber1 = 0f;
            foods1.food1 = 0f;
            MainMenu.startgame=0;
        }

    }
}
