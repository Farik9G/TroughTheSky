using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.IO.File;
using System.Text.RegularExpressions;
using System.Diagnostics;

public class cliсk : MonoBehaviour
{
    public float metal = 0f;
    public float wood = 0f;
    public float rubber = 0f;
    public float food = 0f;
    void OnMouseDown()
    {
        Destroy(gameObject);
        // присваивай любой ресурс
        metals1.metal1 += metal;
        woods1.wood1 += wood;
        rubers1.rubber1 += rubber;
        foods1.food1 += food;
    }
}