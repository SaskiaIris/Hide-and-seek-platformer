using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour {
	Camera levelCamera;

	public void LoadMainMenu() {
		GameValues.GameStarted = false;
		SceneManager.LoadScene(GameValues.MainMenu);
	}
	public void LoadPauseMenu() {
		GameValues.IsPaused = true;
		GameValues.CurrentLevel = SceneManager.GetActiveScene().buildIndex;
		levelCamera = GameObject.FindGameObjectWithTag("Level Camera").GetComponent<Camera>();
		levelCamera.enabled = false;
		Time.timeScale = 0;
		SceneManager.LoadScene(GameValues.PauseMenu, LoadSceneMode.Additive);
	}
	/*public void LoadOptionsMenu() {
		GameValues.PreviousMenu = SceneManager.GetActiveScene().buildIndex;
		Camera.main.enabled = false;
		SceneManager.LoadScene(GameValues.OptionsMenu, LoadSceneMode.Additive);
	}*/
	public void LoadLevelSelect() {
		Time.timeScale = 1;
		SceneManager.LoadScene(GameValues.LevelSelect);
    }

    /// <summary>
	/// 
	/// </summary>

	/*public void GoBackFromOptions() {
		Camera.main.enabled = true;
		SceneManager.UnloadSceneAsync(GameValues.OptionsMenu);
		//SceneManager.LoadScene(previousMenu);
	}*/

    public void QuitGame() {
        Application.Quit();
    }

	/// <summary>
	/// 
	/// </summary>

    public void ContinuePlaying() {
		GameValues.IsPaused = false;
		levelCamera = GameObject.FindGameObjectWithTag("Level Camera").GetComponent<Camera>();
		levelCamera.enabled = true;
		Time.timeScale = 1.0f;
		SceneManager.UnloadSceneAsync(GameValues.PauseMenu);
		Camera.main.enabled = true;
	}

    public void RestartLevel() {
		GameValues.IsPaused = false;
		Time.timeScale = 1;
		SceneManager.UnloadSceneAsync(GameValues.PauseMenu);
        SceneManager.LoadScene(GameValues.CurrentLevel);
	}
	
    /// <summary>
	/// 
	/// </summary>

    private void Update() {
        if(Input.GetButtonDown("Exit")) {
			/*if(GameValues.IsPaused) {
				ContinuePlaying();
			} else */if(SceneManager.GetActiveScene().buildIndex >= GameValues.LevelSelect && !GameValues.IsPaused) {
				LoadPauseMenu();
			} /*else if(SceneManager.GetActiveScene().buildIndex == GameValues.MainMenu) {
				QuitGame();
			}*/ /*else if(SceneManager.GetActiveScene().buildIndex == GameValues.OptionsMenu) {
				GoBackFromOptions();
			}*/
        }
    }
}