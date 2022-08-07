using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menue : MonoBehaviour
{
	#region Fields
	[SerializeField]
	GameObject menue , crosshair;
	[SerializeField]
	Button resumeButton, exitButton;


	bool paused = false;
	#endregion

	#region Methods
	private void Start()
	{
		paused = true;
		Time.timeScale = 0;
		menue.SetActive(true);
		crosshair.SetActive(false);
		Cursor.lockState = CursorLockMode.Confined;
	}
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(paused)
			{
				paused = false;
				Time.timeScale = 1;
				menue.SetActive(false);
				crosshair.SetActive(true);
				Cursor.lockState = CursorLockMode.Locked;
			}
			else
			{
				paused = true;
				Time.timeScale = 0;
				menue.SetActive(true);
				crosshair.SetActive(false);
				Cursor.lockState = CursorLockMode.Confined;
			}
		}
	}
	public void Resume()
	{
		paused = false;
		Time.timeScale = 1;
		menue.SetActive(false);
		crosshair.SetActive(true);
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void Exit()
	{
		Application.Quit();
	}
	#endregion
}
