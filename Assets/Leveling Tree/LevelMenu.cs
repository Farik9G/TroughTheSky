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
using System.Threading;



public class LevelMenu : MonoBehaviour
{
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
        if(panel.activeSelf==false)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
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
        if (Damage.fillAmount >= 1f)
        {

        }
        else
        Damage.fillAmount += 0.25f;
    }
    public void HpPlus()
    {
        if (HP.fillAmount >= 1)
        {

        }
        else
        HP.fillAmount += 0.25f;
    }
    public void heal()
    {
        discontent.DS += 25;
    }
}
