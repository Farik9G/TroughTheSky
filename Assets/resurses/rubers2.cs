using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;


public class rubers2 : MonoBehaviour
{
    private float starrubber2 = 25f;
    public float rubber2 = 0f;
    public Image irubber2;
    // Start is called before the first frame update
    void Start()
    {
        rubber2 = starrubber2;
        irubber2.fillAmount = starrubber2 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (rubber2 / 100 > irubber2.fillAmount)
        {
            irubber2.fillAmount = irubber2.fillAmount + 0.01f;
            Thread.Sleep(50);
        }
        if (rubber2 / 100 < irubber2.fillAmount)
        {
            irubber2.fillAmount = irubber2.fillAmount - 0.01f;
            Thread.Sleep(50);
        }
    }
}
