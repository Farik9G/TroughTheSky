using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public bool PanelGame;
    public GameObject panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2)) // при нажатии F2 появляется панель
        {
            if (PanelGame) // если открыто меню панели, то при нажатии F2 закрывает окно
            {
                Resume();
            }
            else // наоборт
            {
                CallPanel();
            }
        }
    }
    public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        PanelGame = false;
    }

    public void CallPanel()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        PanelGame = true;
    }
}
