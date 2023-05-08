using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject smoke1;
    public GameObject smoke2;
    public GameObject smoke3;
    public static bool n1=true;
    public static bool n2 = true;
    public static bool n3 = true;
    public void smok1()
    {
        n1 = false;
        smoke1.SetActive(n1);
    }
    public void smok2()
    {
        n2 = false;
        smoke2.SetActive(n2);
    }
    public void smok3()
    {
        n3 = false;
        smoke3.SetActive(n3);
    }
}
