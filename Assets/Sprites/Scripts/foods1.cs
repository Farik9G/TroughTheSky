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

public class foods1 : MonoBehaviour
{
    public Image ifood1;
    private float starfood1 = 0f;
    public static float food1 = 0f;
    // Start is called before the first frame update
    void Start()
    {
        food1 = starfood1;
        ifood1.fillAmount = starfood1 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (food1 / 100 > ifood1.fillAmount)
        {
            ifood1.fillAmount = ifood1.fillAmount + 0.005f;
        }
        if (food1 / 100 < ifood1.fillAmount)
        {
            ifood1.fillAmount = ifood1.fillAmount - 0.005f;
        }
    }
}
