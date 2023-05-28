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
    public void DamagePlus()
    {
        if (metals1.metal1 >= 20)
        {
            Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
            if (unit.DamageLvl < 4)
            {
                unit.damage += 10;
                unit.DamageLvl += 1;
                Damage.fillAmount += 0.25f;
            }
            metals1.metal1 -= 20;
        }
        
    }
    public void HpPlus()
    {
        if (woods1.wood1 >= 20)
        {
            Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
            if (unit.HpLvl < 4)
            {

                unit.maxHP += 10;
                unit.HpLvl += 1;
                HP.fillAmount += 0.25f;
            }
            woods1.wood1 -= 20;
        }
    }
    public void heal()
    {
        if ((woods1.wood1 >= 10)&& (metals1.metal1 >= 10) &&(woods1.wood1 >= 30))
        {   
            if (discontent.DS+25>100)
            {
                discontent.DS = 100;
                foods1.food1 -= 20;
                metals1.metal1 -= 10;
                woods1.wood1 -= 30;
            }
            else
            {
                foods1.food1 -= 20;
                discontent.DS += 25;
                metals1.metal1 -= 10;
                woods1.wood1 -= 30;
                
            }
            
        }
    }
    public void Update()
    {
        //Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
        if (MainMenu.startgame==10)
        {
            Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
            int a = unit.HpLvl;
            int b = unit.DamageLvl;

            HP.fillAmount = a * 0.25f;
            Damage.fillAmount = b * 0.25f;
            MainMenu.startgame = 0;
        }
        if (MainMenu.nn1 == 10)
        {
            Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
            int a = unit.HpLvl;
            int b = unit.DamageLvl;

            HP.fillAmount = a * 0.25f;
            Damage.fillAmount = b * 0.25f;
            Debug.Log("Yeds");
            MainMenu.nn1= 0;
        }
        if (MainMenu.n1 == 10)
        {
            Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
            int a = unit.HpLvl;
            int b = unit.DamageLvl;

            HP.fillAmount = a * 0.25f;
            Damage.fillAmount = b * 0.25f;
            Debug.Log("Yeds");
            MainMenu.n1 = 0;
        }
        if (NewBehaviourScript.n1==false)
        {
            Destroy(button1);
            button2.SetActive(false);
        }
        if (NewBehaviourScript.n2 == false)
        {
            Destroy(button2);
            button2.SetActive(false);
        }
        if (NewBehaviourScript.n3 == false)
        {
            Destroy(button3);
             button3.SetActive(false);
        }
    }
}
