﻿using UnityEngine;
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
	
	void Start()
	{
		canvas = GetComponent<Canvas>();
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			canvas.enabled = !canvas.enabled;
			Pause();
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
	
	public void Pause()
	{
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
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
