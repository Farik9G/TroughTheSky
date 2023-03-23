using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class woods2 : MonoBehaviour
{
    private float startWood2 = 25f;
    public float wood2 = 0f;
    public Image iWood2;

    // Start is called before the first frame update
    void Start()
    {
        wood2 = startWood2;
        iWood2.fillAmount = startWood2 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (wood2 / 100 > iWood2.fillAmount)
        {
            iWood2.fillAmount = iWood2.fillAmount + 0.01f;
            Thread.Sleep(50);
        }
        if (wood2 / 100 < iWood2.fillAmount)
        {
            iWood2.fillAmount = iWood2.fillAmount - 0.01f;
            Thread.Sleep(50);
        }
    }
}
