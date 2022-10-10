using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private bool isDead = false;

	Canvas canvas;
	
	void Start()
	{
		canvas = GetComponent<Canvas>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update()
	{
		if (playerHealth.CurrentHealth <= 0 && !isDead)
		{
			GameOver();
			isDead = true;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
	public void Play()
	{
		SceneManager.LoadScene("Main");
		Time.timeScale = 1;
	}
	
	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
		Time.timeScale = 1;
	}
    void GameOver()
    {
	    canvas.enabled = !canvas.enabled;
	    Time.timeScale = 0;
	    Cursor.lockState = CursorLockMode.None;
	    Cursor.visible = true;
    }
    
    public void Quit()
    {
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		#else 
	    Application.Quit();
		#endif
    }
}
