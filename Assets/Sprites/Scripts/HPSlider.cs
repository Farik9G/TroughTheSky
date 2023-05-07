using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class HPSlider : MonoBehaviour
{
    public Slider slider;
    public void IncreaseMaxValue()
    {
        Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
        slider.maxValue = unit.maxHP;
    }
}
