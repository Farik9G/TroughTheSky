using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class metals1 : MonoBehaviour
{
    private float starmetal1 = 25f;
    public float metal1 = 0f;
    public Image imetal1;
    
    // Start is called before the first frame update
    void Start()
    {
        metal1 = starmetal1;
        imetal1.fillAmount = starmetal1 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (metal1 / 100 > imetal1.fillAmount)
        {
            imetal1.fillAmount = imetal1.fillAmount + 0.01f;
            Thread.Sleep(50);
        }
        if (metal1 / 100 < imetal1.fillAmount)
        {
            imetal1.fillAmount = imetal1.fillAmount - 0.01f;
            Thread.Sleep(50);
        }

    }
}
