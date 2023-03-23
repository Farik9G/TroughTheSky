using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class woods1 : MonoBehaviour
{
    private float startWood1 = 25f;
    public float wood1 = 0f;
    public Image iWood1;
    // Start is called before the first frame update
    void Start()
    {
        wood1 = startWood1;
        iWood1.fillAmount = startWood1 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (wood1 / 100 > iWood1.fillAmount)
        {
            iWood1.fillAmount = iWood1.fillAmount + 0.01f;
            Thread.Sleep(50);
        }
        if (wood1 / 100 < iWood1.fillAmount)

        {
            iWood1.fillAmount = iWood1.fillAmount - 0.01f;
            Thread.Sleep(50);
        }
    }
}
