using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;


public class rubers3 : MonoBehaviour
{
    private float starrubber3 = 25f;
    public float rubber3 = 0f;
    public Image irubber3;
    // Start is called before the first frame update
    void Start()
    {
        rubber3 = starrubber3;
        irubber3.fillAmount = starrubber3 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (rubber3 / 100 > irubber3.fillAmount)
        {
            irubber3.fillAmount = irubber3.fillAmount + 0.01f;
            Thread.Sleep(50);
        }
        if (rubber3 / 100 < irubber3.fillAmount)
        {
            irubber3.fillAmount = irubber3.fillAmount - 0.01f;
            Thread.Sleep(50);
        }
    }
}
