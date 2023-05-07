using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using TMPro;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.IO.File;
using System.Text.RegularExpressions;
using System.Diagnostics;


public class rubers1 : MonoBehaviour
{
    private float starrubber1 = 0f;
    public static float rubber1 = 0f;
    public Image irubber1;
    // Start is called before the first frame update
    void Start()
    {
        rubber1 = starrubber1;
        irubber1.fillAmount = starrubber1 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (rubber1 / 100 > irubber1.fillAmount)
        {
            irubber1.fillAmount = irubber1.fillAmount + 0.0005f;
        }
        if (rubber1 / 100 < irubber1.fillAmount)
        {
            irubber1.fillAmount = irubber1.fillAmount - 0.0005f;
        }
    }
}
