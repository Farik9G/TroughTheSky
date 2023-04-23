using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public bool PanelGame;
    public GameObject panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2)) // ��� ������� F2 ���������� ������
        {
            if (PanelGame) // ���� ������� ���� ������, �� ��� ������� F2 ��������� ����
            {
                Resume();
            }
            else // �������
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
