using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
<<<<<<< Updated upstream
=======
        startgame = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void LoadGame()
    {
        n = 1;
        n1 = 1;
>>>>>>> Stashed changes
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
