using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    public string unitName;

    public int damage;

    public int maxHP;
    public int currentHP;

    public int dodgeValue;

    public int DamageLvl = 0;
    public int HpLvl = 0;
    public float wood;
    public float metal;
    public float rubber;
    public float food;
    [SerializeField]
    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }


    public void Repair(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }

}