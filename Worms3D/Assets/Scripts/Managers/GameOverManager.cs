using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    Canvas canvas; 
    void Start()
    {
        canvas = GetComponent<Canvas>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    public void Play()
    {
        SceneManager.LoadScene("MainGame");
        Time.timeScale = 1;
    }
	
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        canvas.enabled = !canvas.enabled;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}