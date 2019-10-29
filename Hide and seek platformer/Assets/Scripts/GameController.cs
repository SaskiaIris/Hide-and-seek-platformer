using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	private Text textMessage;
	private string lastText;

    // Start is called before the first frame update
    void Start() {
		if(!GameValues.GameStarted) {
			GameValues.Carrots = 0;
			GameValues.HealthPoints = 100f;
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
			GameValues.ProgressInLevels = 4;
			GameValues.IsPaused = false;
			GameValues.GameStarted = true;
		}

		textMessage = GameObject.FindWithTag("Screen Message").GetComponent<Text>();
	}

    // Update is called once per frame
    void Update() {
		lastText = textMessage.text;

		if(GameValues.HealthPoints < 5) {
			SceneManager.LoadScene(GameValues.GameOver);
		}

		print("HP:" + GameValues.HealthPoints);

		if(GameValues.Carrots > 4 && GameValues.HealthPoints < 100) {
			GameValues.Carrots = 0;
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
			StartCoroutine(FadeTextToZeroAlpha(4f, textMessage));
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