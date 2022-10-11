using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour 
{
	Canvas canvas;
	public bool isPaused;
	
	void Start()
	{
		canvas = GetComponent<Canvas>();
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
		{
			isPaused = true;
			Pause();
		}
		else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
		{
			isPaused = false;
			UnPause();
		}
	}
	
	public void Pause()
	{
		canvas.enabled = !canvas.enabled;
		Time.timeScale = 0;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
	public void UnPause()
	{
		canvas.enabled = false;
		Time.timeScale = 1;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
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
	
	public void Quit()
	{
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		#else 
		Application.Quit();
		#endif
	}
}
