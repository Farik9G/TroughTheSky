using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class metals3 : MonoBehaviour
{
    private float starmetal3 = 25f;
    public float metal3 = 0f;
    public Image imetal3;
    // Start is called before the first frame update
    void Start()
    {
        metal3 = starmetal3;
        imetal3.fillAmount = starmetal3 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (metal3 / 100 > imetal3.fillAmount)
        {
            imetal3.fillAmount = imetal3.fillAmount + 0.01f;
            Thread.Sleep(50);
        }
        if (metal3 / 100 < imetal3.fillAmount)
        {
            imetal3.fillAmount = imetal3.fillAmount - 0.01f;
            Thread.Sleep(50);
        }
    }
}
