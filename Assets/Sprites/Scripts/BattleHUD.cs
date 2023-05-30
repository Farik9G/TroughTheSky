using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{

    public TMP_Text nameText;
    public TMP_Text damageText;
    public TMP_Text hpText;
    public Slider hpSlider;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        damageText.text = "ÓÐÎÍ " + unit.damage;
        hpText.text = "ÍÐ " + unit.currentHP;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
        hpText.text = "ÍÐ " + hp;
    }

}