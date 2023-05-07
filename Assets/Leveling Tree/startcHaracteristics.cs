using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System;
using System.Threading.Tasks;
using System.IO;
using static System.IO.File;
using System.Text.RegularExpressions;
using System.Diagnostics;
using UnityEngine.UI;

public class startcHaracteristics : MonoBehaviour
{
    public Image HP;
    public Image Damage;
    void Start()
    {
        HP.fillAmount = 0f;
        Damage.fillAmount = 0f;
    }

}
