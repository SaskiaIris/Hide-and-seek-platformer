using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour {
	public void LoadMainMenu() {
		SceneManager.LoadScene(GameValues.MainMenu);
	}
	public void LoadPauseMenu() {
		GameValues.CurrentLevel = SceneManager.GetActiveScene().buildIndex;
		//print("playingscene1 = " + playingScene);
		Camera.main.enabled = false;
		Time.timeScale = 0;
		SceneManager.LoadScene(GameValues.PauseMenu, LoadSceneMode.Additive);
	}
	public void LoadOptionsMenu() {
		GameValues.PreviousMenu = SceneManager.GetActiveScene().buildIndex;
		Camera.main.enabled = false;
		SceneManager.LoadScene(GameValues.OptionsMenu, LoadSceneMode.Additive);
	}
	public void LoadLevelSelect() {
		Time.timeScale = 1;
		SceneManager.LoadScene(GameValues.LevelSelect);
    }

    /// <summary>
	/// 
	/// </summary>

	public void GoBackFromOptions() {
		Camera.main.enabled = true;
		SceneManager.UnloadSceneAsync(GameValues.OptionsMenu);
		//SceneManager.LoadScene(previousMenu);
	}

    public void QuitGame() {
        Application.Quit();
    }

	/// <summary>
	/// 
	/// </summary>

    public void ContinuePlaying() {
		Time.timeScale = 1.0f;
		//print("playingscene2 = " + playingScene);
		
		SceneManager.UnloadSceneAsync(GameValues.PauseMenu);
		Camera.main.enabled = true;
	}

    public void RestartLevel() {
		Time.timeScale = 1;
		Camera.main.enabled = true;
		SceneManager.UnloadSceneAsync(GameValues.PauseMenu);
        SceneManager.LoadScene(GameValues.CurrentLevel);
	}

    /// <summary>
	/// 
	/// </summary>

    private void Update() {
        if(Input.GetButtonDown("Exit")) {
            if (SceneManager.GetActiveScene().buildIndex > 2) {
                LoadPauseMenu();
            } else if(SceneManager.GetActiveScene().buildIndex == 0) {
                QuitGame();
            } else if(SceneManager.GetActiveScene().buildIndex == 1) {
                ContinuePlaying();
            }
        }
    }
}