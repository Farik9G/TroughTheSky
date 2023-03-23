using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class foods2 : MonoBehaviour
{
    public Image ifood2;
    private float starfood2 = 25f;
    public float food2 = 0f;
    // Start is called before the first frame update
    void Start()
    {
        food2 = starfood2;
        ifood2.fillAmount = starfood2 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (food2 / 100 > ifood2.fillAmount)
        {
            ifood2.fillAmount = ifood2.fillAmount + 0.01f;
            Thread.Sleep(50);
        }
        if (food2 / 100 < ifood2.fillAmount)
        {
            ifood2.fillAmount = ifood2.fillAmount - 0.01f;
            Thread.Sleep(50);
        }
    }
}
