using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadres : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (MainMenu.n==1)
        {
            SaveLoadManager.l1();
            MainMenu.n--;
        }
    }
}