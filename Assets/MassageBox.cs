using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MassageBox : MonoBehaviour
{
    private static MassageBox instance;
    public GameObject Template;
    void Awake()
    {
        instance = this;
    }
    public static void ShowMassage(Action action, string text)
    {
        GameObject massageBox = Instantiate(instance.Template);
        Transform panel = massageBox.transform.Find("Panel");
        Text massageBoxText = panel.Find("Text").GetComponent<Text>();
        massageBoxText.text = text;
        Button ok = panel.Find("OK").GetComponent<Button>();
        ok.onClick.AddListener(() =>
        {
            Destroy(massageBox);
        }
        );

    }
}
