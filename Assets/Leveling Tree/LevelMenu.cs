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


public class LevelMenu : MonoBehaviour
{
    bool n = false;
    public GameObject panel;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject HPButton;
    public Image HP;
    public GameObject DamaheButton;
    public Image Damage;
    public void Lvl()
    {
        if (n == false)
        {
            panel.SetActive(n);
            n = true;
        }
        else
        {
            panel.SetActive(n);
            n = false;
        }
    }
    public void acces1s()
    {
        button1.SetActive(false);
    }
    public void acces2s()
    {
        button2.SetActive(false);
    }
    public void acces3s()
    {
        button3.SetActive(false);
    }
    public void DamagePlus()
    {
        Damage.fillAmount += 0.25f;
    }
    public void HpPlus()
    {
        HP.fillAmount += 0.25f;
    }
}
