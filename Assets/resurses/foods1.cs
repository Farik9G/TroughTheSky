using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class foods1 : MonoBehaviour
{
    public Image ifood1;
    private float starfood1 = 25f;
    public float food1 = 0f;
    // Start is called before the first frame update
    void Start()
    {
        food1 = starfood1;
        ifood1.fillAmount = starfood1 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (food1 / 100 > ifood1.fillAmount)
        {
            ifood1.fillAmount = ifood1.fillAmount + 0.01f;
            Thread.Sleep(50);
        }
        if (food1 / 100 < ifood1.fillAmount)
        {
            ifood1.fillAmount = ifood1.fillAmount - 0.01f;
            Thread.Sleep(50);
        }
    }
}
