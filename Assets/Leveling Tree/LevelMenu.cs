using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Threading.Tasks;
using System.IO;
using static System.IO.File;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.Threading;
using System.Linq;

public class LevelMenu : MonoBehaviour
{
    public GameObject panel;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public Image HP;
    public Image Damage;
    //GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
    //public Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
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
        Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
        if (unit.DamageLvl < 4)
        {
            unit.damage += 100;
            unit.DamageLvl += 1;
            Damage.fillAmount += 0.25f;
        }
    }
    public void HpPlus()
    {
        Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
        if (unit.HpLvl < 4)
        {

            unit.maxHP += 100;
            unit.HpLvl += 1;
            HP.fillAmount += 0.25f;
        }
    }
    public void heal()
    {
        discontent.DS += 25;
    }
    public void Update()
    {
        Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
        if (MainMenu.startgame==10)
        {
            int a = unit.HpLvl;
            int b = unit.DamageLvl;

            HP.fillAmount = a * 0.25f;
            Damage.fillAmount = b * 0.25f;
            MainMenu.startgame = 0;
        }
        if (MainMenu.nn1 == 10)
        {
            int a = unit.HpLvl;
            int b = unit.DamageLvl;

            HP.fillAmount = a * 0.25f;
            Damage.fillAmount = b * 0.25f;
            Debug.Log("Yeds");
            MainMenu.nn1= 0;
        }
        if (MainMenu.n1 == 10)
        {
            int a = unit.HpLvl;
            int b = unit.DamageLvl;

            HP.fillAmount = a * 0.25f;
            Damage.fillAmount = b * 0.25f;
            Debug.Log("Yeds");
            MainMenu.n1 = 0;
        }
    }
}
