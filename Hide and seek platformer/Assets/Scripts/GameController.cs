using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	private Text textMessage;
	private string lastText;
	private bool backSpacePressed;

    // Start is called before the first frame update
    void Start() {
		if(!GameValues.GameStarted) {
			GameValues.Carrots = 0;
			GameValues.TotalCarrots = 0;
			GameValues.HealthPoints = 100f;
			GameValues.TimePlayed = 0.0f;
			GameValues.MainMenu = 0;
			GameValues.PauseMenu = 1;
			GameValues.OptionsMenu = 2;
			GameValues.LevelSelect = 3;
			GameValues.Tutorial = 4;
			GameValues.Level_1 = 5;
			GameValues.Level_2 = 6;
			GameValues.Level_3 = 7;
			GameValues.Level_4 = 8;
			GameValues.Level_5 = 9;
			GameValues.BossLevel = 10;
			GameValues.GameOver = 11;
			GameValues.Win = 12;
			GameValues.ProgressInLevels = 4;
			GameValues.IsPaused = false;
			GameValues.GameStarted = true;
			GameValues.AddCarrotsLevel(0, 0);
			GameValues.AddCarrotsLevel(1, 0);
			GameValues.AddCarrotsLevel(2, 0);
			GameValues.AddCarrotsLevel(3, 0);
			GameValues.AddHealthLevel(0, 0.0f);
			GameValues.AddHealthLevel(1, 0.0f);
			GameValues.AddHealthLevel(2, 0.0f);
			GameValues.AddHealthLevel(3, 0.0f);
			GameValues.AddEyesLevel(0, 0);
			GameValues.AddEyesLevel(1, 0);
			GameValues.AddEyesLevel(2, 0);
			GameValues.AddEyesLevel(3, 0);
			GameValues.AddCrouchedLevel(0, 0);
			GameValues.AddCrouchedLevel(1, 0);
			GameValues.AddCrouchedLevel(2, 0);
			GameValues.AddCrouchedLevel(3, 0);
			GameValues.AddShotsLevel(0, 0);
            GameValues.AddShotsLevel(1, 0);
            GameValues.AddShotsLevel(2, 0);
            GameValues.AddShotsLevel(3, 0);
            GameValues.AddDoubleJumpLevel(0, 0);
            GameValues.AddDoubleJumpLevel(1, 0);
            GameValues.AddDoubleJumpLevel(2, 0);
            GameValues.AddDoubleJumpLevel(3, 0);
		}

		textMessage = GameObject.FindWithTag("Screen Message").GetComponent<Text>();
	}

    // Update is called once per frame
    void Update() {
		lastText = textMessage.text;

		GameValues.TimePlayed += Time.deltaTime;

		if (GameValues.HealthPoints < 10) {
			SceneManager.LoadScene(GameValues.GameOver);
		}


		if(GameValues.Carrots > 4 && GameValues.HealthPoints < 100) {
			GameValues.Carrots -= 5;
			GameValues.HealthPoints += 20;
		}

		if(GameValues.CurrentLevel == GameValues.LevelSelect) {
			for(int check = 1; check < 7; check++) {
				if((GameValues.ProgressInLevels - 4) >= check) {
					GameObject.FindWithTag("Cross " + check).GetComponent<Renderer>().enabled = false;
				}
			}
		}

		if(textMessage.text != "" && textMessage.text.Equals(lastText)) {
			StartCoroutine(FadeTextToZeroAlpha(3f, textMessage));
		}

		backSpacePressed = false;
		if(Input.GetKeyDown(KeyCode.Backspace)) {
			if(!backSpacePressed) {
				backSpacePressed = true;
				if(GameValues.ProgressInLevels < GameValues.Level_3) {
					GameValues.ProgressInLevels += 1;
					SceneManager.LoadScene(GameValues.LevelSelect);
				}
			}
		}

		if(GameValues.ProgressInLevels == GameValues.Level_4) {
			Analytics.CustomEvent("Timeplayed", new Dictionary<string, object> {
			{"time played: ", GameValues.TimePlayed}});

			StartCoroutine(NetworkHandler.SendData("wortels", GameValues.GetCarrotsLevel()));
			StartCoroutine(NetworkHandler.SendData("Levens", GameValues.GetHealthLevel()));
			StartCoroutine(NetworkHandler.SendData("Eyes_Closed", GameValues.GetEyesLevel()));
			StartCoroutine(NetworkHandler.SendData("shots", GameValues.GetShotsLevel()));
            StartCoroutine(NetworkHandler.SendData("doublejumps", GameValues.GetDoubleJumpLevel()));
			StartCoroutine(NetworkHandler.SendData("crouches", GameValues.GetCrouchedLevel()));

            /*Analytics.CustomEvent("CarrotsCollected", new Dictionary<string, object> {
			{"Carrots collected: ", GameValues.TotalCarrots }});*/

            Analytics.CustomEvent("Eyes Closed", new Dictionary<string, object>{
			{"Times eyes used: ", GameValues.Eyes_Closed  }});

			SceneManager.LoadScene(GameValues.Win);
			
			//GameValues.ProgressInLevels = GameValues.Level_3;
		}

		

	}

	public IEnumerator FadeTextToFullAlpha(float t, Text i) {
		i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
		while(i.color.a < 1.0f) {
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
			yield return null;
		}
	}

	public IEnumerator FadeTextToZeroAlpha(float t, Text i) {
		i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
		while(i.color.a > 0.0f) {
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
			yield return null;
		}
		i.text = "";
	}
}