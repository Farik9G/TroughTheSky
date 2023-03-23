using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class metals2 : MonoBehaviour
{
    private float starmetal2 = 25f;
    public float metal2 = 0f;
    public Image imetal2;
    // Start is called before the first frame update
    void Start()
    {
        metal2 = starmetal2;
        imetal2.fillAmount = starmetal2 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (metal2 / 100 > imetal2.fillAmount)
        {
            imetal2.fillAmount = imetal2.fillAmount + 0.01f;
            Thread.Sleep(50);
        }
        if (metal2 / 100 < imetal2.fillAmount)
        {
            imetal2.fillAmount = imetal2.fillAmount - 0.01f;
            Thread.Sleep(50);
        }
    }
}
