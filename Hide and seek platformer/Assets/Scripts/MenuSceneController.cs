using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour {
	public int playingScene;
	int previousMenu;
	int mainMenu = 0;
	int pauseMenu = 1;
	int optionsMenu = 2;
	int levelSelect = 3;

	public void LoadMainMenu() {
		SceneManager.LoadScene(mainMenu);
	}
	public void LoadPauseMenu() {
		playingScene = SceneManager.GetActiveScene().buildIndex;
		print("playingscene1 = " + playingScene);
		Camera.main.enabled = false;
		Time.timeScale = 0;
		SceneManager.LoadScene(pauseMenu, LoadSceneMode.Additive);
	}
	public void LoadOptionsMenu() {
		previousMenu = SceneManager.GetActiveScene().buildIndex;
		Camera.main.enabled = false;
		SceneManager.LoadScene(optionsMenu, LoadSceneMode.Additive);
	}
	public void LoadLevelSelect() {
		Time.timeScale = 1;
		SceneManager.LoadScene(levelSelect);
    }

    /// <summary>
	/// 
	/// </summary>

	public void GoBackFromOptions() {
		Camera.main.enabled = true;
		SceneManager.UnloadSceneAsync(optionsMenu);
		//SceneManager.LoadScene(previousMenu);
	}

    public void QuitGame() {
        Application.Quit();
    }

	/// <summary>
	/// 
	/// </summary>

    public void ContinuePlaying() {
		print("playingscene2 = " + playingScene);
		Time.timeScale = 1;
		Camera.main.enabled = true;
		SceneManager.UnloadSceneAsync(pauseMenu);
    }

    public void RestartLevel() {
		Time.timeScale = 1;
		Camera.main.enabled = true;
		SceneManager.UnloadSceneAsync(pauseMenu);
        SceneManager.LoadScene(playingScene);
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