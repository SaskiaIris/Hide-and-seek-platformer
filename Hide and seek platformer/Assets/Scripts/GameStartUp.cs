using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		if(!GameValues.GameStarted) {
			GameValues.Carrots = 0;
			GameValues.HealthPoints = 100;
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
			GameValues.IsPaused = false;
			GameValues.GameStarted = true;
		}
	}

    // Update is called once per frame
    void Update()
    {
    }
}
