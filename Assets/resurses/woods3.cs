using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class woods3 : MonoBehaviour
{
    private float startWood3 = 25f;
    public float wood3 = 0f;
    public Image iWood3;
    // Start is called before the first frame update
    void Start()
    {
        wood3 = startWood3;
        iWood3.fillAmount = startWood3 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (wood3 / 100 > iWood3.fillAmount)
        {
            iWood3.fillAmount = iWood3.fillAmount + 0.01f;
            Thread.Sleep(50);
        }
        if (wood3 / 100 < iWood3.fillAmount)
        {
            iWood3.fillAmount = iWood3.fillAmount - 0.01f;
            Thread.Sleep(50);
        }
    }
}
