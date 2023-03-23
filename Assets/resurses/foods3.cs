using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class foods3 : MonoBehaviour
{
    public Image ifood3;
    private float starfood3 = 25f;
    public float food3 = 0f;
    // Start is called before the first frame update
    void Start()
    {
        food3 = starfood3;
        ifood3.fillAmount = starfood3 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (food3 / 100 > ifood3.fillAmount)
        {
            ifood3.fillAmount = ifood3.fillAmount + 0.01f;
            Thread.Sleep(50);
        }
        if (food3 / 100 < ifood3.fillAmount)
        {
            ifood3.fillAmount = ifood3.fillAmount - 0.01f;
            Thread.Sleep(50);
        }
    }
}
