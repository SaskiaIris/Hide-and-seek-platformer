using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {
    public int levelNumber = 0;

    private bool isByDoor = false;
    private GameObject keyHint;
	private Text warningMessage;

	// Start is called before the first frame update
	void Start() {
        keyHint = GameObject.FindWithTag("Key Hint " + levelNumber.ToString());
		warningMessage = GameObject.FindWithTag("Screen Message").GetComponent<Text>();
	}

    // Update is called once per frame
    void Update() {
		GameValues.CurrentLevel = SceneManager.GetActiveScene().buildIndex;

        if(isByDoor) {
            keyHint.GetComponent<Renderer>().enabled = true;
			if(Input.GetAxis("Vertical") > 0.1) {
				if(GameValues.CurrentLevel > 3) {
					GameValues.InsertCarrotsLevel(GameValues.CurrentLevel, GameValues.TotalCarrots);
					GameValues.InsertHealthLevel(GameValues.CurrentLevel, GameValues.HealthLostTotal);
					GameValues.InsertEyesLevel(GameValues.CurrentLevel, GameValues.Eyes_Closed);
					GameValues.InsertCrouchedLevel(GameValues.CurrentLevel, GameValues.Crouched);
					GameValues.InsertTimeLevel(GameValues.CurrentLevel, GameValues.TimePlayed);
					GameValues.TimePlayed = 0;
					GameValues.Eyes_Closed = 0;
					GameValues.Crouched = 0;
					GameValues.HealthLostTotal = 0;
					GameValues.TotalCarrots = 0;
					if(GameValues.CurrentLevel == GameValues.ProgressInLevels) {
						GameValues.ProgressInLevels++;
					}
				}
				if(GameValues.ProgressInLevels >= levelNumber) {
					SceneManager.LoadScene(levelNumber);
				} else {
					if(levelNumber == 5) {
						warningMessage.text = "You have to beat the tutorial first!";
					} else {
						warningMessage.text = "You have to beat level " + (levelNumber - 5).ToString() + " first!";
					}
				}
				print("Progress: " + GameValues.ProgressInLevels);
            }
        } else {
            keyHint.GetComponent<Renderer>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        isByDoor = true;
    }
    private void OnTriggerExit2D(Collider2D other) {
        isByDoor = false;
    }
}
