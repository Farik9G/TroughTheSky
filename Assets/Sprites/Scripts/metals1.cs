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

public class metals1 : MonoBehaviour
{
    private float starmetal1 = 0f;
    public static float metal1 = 0f;
    public Image imetal1;
    // Start is called before the first frame update
    void Start()
    {
        Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
        metal1 = starmetal1;
        imetal1.fillAmount = starmetal1 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (metal1 / 100 > imetal1.fillAmount)
        {
            imetal1.fillAmount = imetal1.fillAmount + 0.005f;
        }
        if (metal1 / 100 < imetal1.fillAmount)
        {
            imetal1.fillAmount = imetal1.fillAmount - 0.005f;
        }
        
    }
}
