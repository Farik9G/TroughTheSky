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

public class foodnum : MonoBehaviour
{
    public float foodnm = foods1.food1;
    public TMP_Text myText;
    float n = 0;
    // Start is called before the first frame update
    void Start()
    {
        n = foodnm;
        myText.text = foodnm.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        foodnm = foods1.food1;
        if (foodnm > n)
        {
            n++;
            myText.text = n.ToString();
        }
        if (foodnm < n)
        {
            n--;
            myText.text = n.ToString();
        }
    }
}
