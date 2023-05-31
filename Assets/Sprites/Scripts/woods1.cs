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

public class woods1 : MonoBehaviour
{
    private float startWood1 = 0f;
    public static float wood1 = 0f;
    public Image iWood1;
    // Start is called before the first frame update
    void Start()
    {
        wood1 = startWood1;
        iWood1.fillAmount = startWood1 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (wood1 / 100 > iWood1.fillAmount)
        {
            iWood1.fillAmount = iWood1.fillAmount + 0.005f;
        }
        if (wood1 / 100 < iWood1.fillAmount)

        {
            iWood1.fillAmount = iWood1.fillAmount - 0.005f;
        }
    }
}
