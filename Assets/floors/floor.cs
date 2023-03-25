using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class floor : MonoBehaviour
{
    public void floor1()
    {
        SceneManager.LoadScene(1);
    }
    public void floor2()
    {
        SceneManager.LoadScene(4);
    }
    public void floor3()
    {
        SceneManager.LoadScene(5);
    }
}