using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;


public class rubers1 : MonoBehaviour
{
    private float starrubber1 = 25f;
    public float rubber1 = 0f;
    public Image irubber1;
    // Start is called before the first frame update
    void Start()
    {
        rubber1 = starrubber1;
        irubber1.fillAmount = starrubber1 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (rubber1 / 100 > irubber1.fillAmount)
        {
            irubber1.fillAmount = irubber1.fillAmount + 0.01f;
            Thread.Sleep(50);
        }
        if (rubber1 / 100 < irubber1.fillAmount)
        {
            irubber1.fillAmount = irubber1.fillAmount - 0.01f;
            Thread.Sleep(50);
        }
    }
}
