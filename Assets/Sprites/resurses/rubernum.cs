using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.IO.File;
using System.Text.RegularExpressions;
using System.Diagnostics;

public class rubernum : MonoBehaviour
{
    public float rubernm = rubers1.rubber1;
    public TMP_Text myText;
    float n = 0;
    int g = 0;
    // Start is called before the first frame update
    void Start()
    {
        n = rubernm;
        myText.text = rubernm.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        rubernm = rubers1.rubber1;
        if (rubernm > n)
        {
            if (g > 0)
            {
                g--;
            }
            else
            {
                n++;
                myText.text = n.ToString();
                g = 20;
            }
        }
        if (rubernm < n)
        {
            if (g > 0)
            {
                g--;
            }
            else
            {
                n--;
                myText.text = n.ToString();
                g = 20;
            }
        }



    }
}