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

public class metalnum : MonoBehaviour
{
    public float metalnm = metals1.metal1;
    public TMP_Text myText;
    float n = 0;
    // Start is called before the first frame update
    void Start()
    {
        n = metalnm;
        myText.text = metalnm.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        metalnm = metals1.metal1;
        if (metalnm>n)
        {
            n++;
            myText.text = n.ToString();
        }
        if (metalnm < n)
        {
            n--;
            myText.text = n.ToString();
        }



    }
}
