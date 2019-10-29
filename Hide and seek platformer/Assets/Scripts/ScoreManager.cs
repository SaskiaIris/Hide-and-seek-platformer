using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public static ScoreManager instance;

	private int value;
	private bool isTriggered;

	private GameObject carrotCounter;
	private GameObject healthPoints;

	void Start() {
		if(instance == null) {
			instance = this;
		}

		value = 1;

		carrotCounter = GameObject.FindWithTag("Carrot Count");
		healthPoints = GameObject.FindWithTag("Health Bar");
	}

	void Update() {
		isTriggered = false;

		carrotCounter.GetComponent<Text>().text = GameValues.Carrots.ToString();
		healthPoints.GetComponent<Image>().fillAmount = GameValues.HealthPoints / 100;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Light Carrot") && !PlayerMovement.instance.isDark) {
			if(!isTriggered) {
				isTriggered = true;
				Destroy(other.gameObject);

				GameValues.Carrots += value;
			}
		}

		if(other.gameObject.CompareTag("Dark Carrot") && PlayerMovement.instance.isDark) {
			if(!isTriggered) {
				isTriggered = true;
				Destroy(other.gameObject);

				GameValues.Carrots += value;
			}
		}
	}
}