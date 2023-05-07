using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public static int n = 0;
<<<<<<<< HEAD:Assets/Scripts/MainMenu.cs
========
    public static int n1 = 0;
    public static int nn = 0;
    public static int nn1 = 0;
    public static int startgame=0;
>>>>>>>> main:Assets/Sprites/Scripts/MainMenu.cs
    public void PlayGame()
    {
        startgame = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void LoadGame()
    {
        nn = 1;
        nn1 = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
<<<<<<<< HEAD:Assets/Scripts/MainMenu.cs
        n = 1;
========

>>>>>>>> main:Assets/Sprites/Scripts/MainMenu.cs
    }

    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }

    public void ToggleSound()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
