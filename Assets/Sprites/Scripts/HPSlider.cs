using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class HPSlider : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        StartCoroutine(DelayedStart());
        

    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(0.005f);

        Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();

        slider.value = unit.currentHP;
        Debug.Log("Slider " + unit.name);
        Debug.Log("Slider " + unit.currentHP + " " + slider.value);
    }


    public void IncreaseMaxValue()
    {
        Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
        slider.maxValue = unit.maxHP;
        slider.value = unit.maxHP;
    }
}
