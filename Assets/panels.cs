using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panels : MonoBehaviour
{
    bool n = true;
    bool n1 = true;
    bool n2 = true;
    public  GameObject panels1;
    public GameObject panels2;
    public GameObject panels3;
    // Start is called before the first frame update
    public void panel1()
    {
        panels1.SetActive(n);
        if (n == true)
        {
            n = false;
        }
        else
        {
            n = true;
        }
    }
    public void panel2()
    {
        panels2.SetActive(n1);
        if (n1 == true)
        {
            n1 = false;
        }
        else
        {
            n1 = true;
        }
    }
    public void panel3()
    {
        panels3.SetActive(n2);
        if (n2 == true)
        {
            n2 = false;
        }
        else
        {
            n2 = true;
        }
    }
}
