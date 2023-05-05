using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public static int n = 0;
    public static int n1 = 0;
    public static int startgame=0;
    public void PlayGame()
    {
        SystemBoss.n = 0;
        startgame = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void LoadGame()
    {
        n = 1;
        n1 = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

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
