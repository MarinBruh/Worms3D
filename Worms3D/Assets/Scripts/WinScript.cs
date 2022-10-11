using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameOverManager gameOver;
    void Update()
    {
        if (PlayerSwitcher.GM.one[0].GetComponent<PlayerHealth>().currentHealth +
            PlayerSwitcher.GM.one[1].GetComponent<PlayerHealth>().currentHealth <= 0)
        {
            SceneManager.LoadScene("RedWin");
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            print("team one won");
        }


        if (PlayerSwitcher.GM.two[0].GetComponent<PlayerHealth>().currentHealth +
            PlayerSwitcher.GM.two[1].GetComponent<PlayerHealth>().currentHealth <= 0)
        {
            SceneManager.LoadScene("BlueWin");
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            print("team two won");
        }
    }
}