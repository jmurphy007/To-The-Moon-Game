using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public AudioSource soundUI;
	void Start()
    {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
	
	public void PlayGame ()
	{
		soundUI.Play();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void QuitGame ()
	{
		soundUI.Play();
		Debug.Log ("QUIT!");
		Application.Quit();
	}
}
