using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	private bool isTriggered;

    // Start is called before the first frame update
    void Start() {
		
    }

    // Update is called once per frame
    void Update() {
		isTriggered = false;
	}

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
			if(!isTriggered) {
				isTriggered = true;
				GameValues.CurrentLevel = SceneManager.GetActiveScene().buildIndex;
				GameValues.HealthPoints = (GameValues.HealthPoints / 2);
				SceneManager.LoadScene(GameValues.CurrentLevel);
			}
        }
    }
}
