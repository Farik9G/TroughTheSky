using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadpos : MonoBehaviour
{
   public GameObject player;
    void Update()
    {
        if (MainMenu.n1 == 1)
        {
            SaveLoadManager.PlayerData posdata = SaveLoadManager.Load();
            player.transform.position =posdata.position;
            MainMenu.n1--;
        }
    }
}
