﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public static ScoreManager instance;
	public Text text;
	public int value;
	private GameObject playerObject;
	private GameObject[] carrotObjects;
	private bool isTriggered;

	void Start() {
		if(instance == null) {
			instance = this;
		}
		value = 1;
		isTriggered = false;
		playerObject = GameObject.FindWithTag("Player");
		carrotObjects = GameObject.FindGameObjectsWithTag("Carrot");
	}

	void Update() {
		foreach(GameObject carrotCheck in carrotObjects) {
			if(playerObject.GetComponent<Collider2D>().IsTouching(carrotCheck.GetComponent<Collider2D>())) {
				if(!isTriggered) {
					isTriggered = true;
					Destroy(carrotCheck);
					GameValues.Carrots += value;
				}
			}
		}

		text.text = GameValues.Carrots.ToString();
		isTriggered = false;
	}
}