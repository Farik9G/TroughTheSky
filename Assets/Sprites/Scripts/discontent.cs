using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class discontent : MonoBehaviour
{
    public Image ds;
    private float startdiscontent = 0f;
    public static float DS = 0f;
    // Start is called before the first frame update
    void Start()
    {
        DS = startdiscontent;
        ds.fillAmount = startdiscontent / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (DS / 100 > ds.fillAmount)
        {
            ds.fillAmount = ds.fillAmount + 0.0005f;
        }
        if (DS / 100 < ds.fillAmount)
        {
            ds.fillAmount = ds.fillAmount - 0.0005f;
        }
    }
}