﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameValues {
	private static bool gv_GameStarted, gv_IsPaused;
	private static int gv_Carrots, gv_ProgressInLevels, gv_Total_Carrots, gv_Eyes_Closed;
	private static float gv_HealthPoints, gv_TimePlayed;
	private static int gv_MainMenu, gv_PauseMenu, gv_OptionsMenu, gv_LevelSelect, gv_GameOver, gv_Win;
	private static int gv_Tutorial, gv_Level_1, gv_Level_2, gv_Level_3, gv_Level_4, gv_Level_5, gv_BossLevel;
	private static int gv_PreviousMenu, gv_CurrentLevel;
    private static int gv_Amount_Shots, gv_Amount_DoubleJump;

	public static bool GameStarted {
		get {
			return gv_GameStarted;
		}
		set {
			gv_GameStarted = value;
		}
	}

	public static bool IsPaused {
		get {
			return gv_IsPaused;
		}
		set {
			gv_IsPaused = value;
		}
	}

	public static int Carrots {
		get {
			return gv_Carrots;
		}
		set {
			gv_Carrots = value;
		}
	}

	public static int TotalCarrots {
		get {
			return gv_Total_Carrots;
		}
		set {
			gv_Total_Carrots = value;
		}
	}

	public static int Eyes_Closed {
		get {
			return gv_Eyes_Closed;
		}
		set {
			gv_Eyes_Closed = value;
		}
	}

	public static int ProgressInLevels {
		get {
			return gv_ProgressInLevels;
		}
		set {
			gv_ProgressInLevels = value;
		}
	}

	public static float HealthPoints {
		get {
			return gv_HealthPoints;
		}
		set {
			gv_HealthPoints = value;
		}
	}

	public static float TimePlayed {
		get {
			return gv_TimePlayed;
		}
		set {
			gv_TimePlayed = value;
		}
	}

	public static int MainMenu {
		get {
			return gv_MainMenu;
		}
		set {
			gv_MainMenu = value;
		}
	}

	public static int OptionsMenu {
		get {
			return gv_OptionsMenu;
		}
		set {
			gv_OptionsMenu = value;
		}
	}

	public static int PauseMenu {
		get {
			return gv_PauseMenu;
		}
		set {
			gv_PauseMenu = value;
		}
	}

	public static int LevelSelect {
		get {
			return gv_LevelSelect;
		}
		set {
			gv_LevelSelect = value;
		}
	}

	public static int GameOver {
		get {
			return gv_GameOver;
		}
		set {
			gv_GameOver = value;
		}
	}

	public static int Win {
		get {
			return gv_Win;
		}
		set {
			gv_Win = value;
		}
	}

	public static int Tutorial {
		get {
			return gv_Tutorial;
		}
		set {
			gv_Tutorial = value;
		}
	}

	public static int Level_1 {
		get {
			return gv_Level_1;
		}
		set {
			gv_Level_1 = value;
		}
	}

	public static int Level_2 {
		get {
			return gv_Level_2;
		}
		set {
			gv_Level_2 = value;
		}
	}

	public static int Level_3 {
		get {
			return gv_Level_3;
		}
		set {
			gv_Level_3 = value;
		}
	}

	public static int Level_4 {
		get {
			return gv_Level_4;
		}
		set {
			gv_Level_4 = value;
		}
	}

	public static int Level_5 {
		get {
			return gv_Level_5;
		}
		set {
			gv_Level_5 = value;
		}
	}

	public static int BossLevel {
		get {
			return gv_BossLevel;
		}
		set {
			gv_BossLevel = value;
		}
	}

	public static int PreviousMenu {
		get {
			return gv_PreviousMenu;
		}
		set {
			gv_PreviousMenu = value;
		}
	}

	public static int CurrentLevel {
		get {
			return gv_CurrentLevel;
		}
		set {
			gv_CurrentLevel = value;
		}
	}

    public static int AmountShots
    {
        get
        {
            return gv_Amount_Shots;
        }
        set
        {
            gv_Amount_Shots = value;
        }
    }

    public static int AmountDoubleJump
    {
        get
        {
            return gv_Amount_DoubleJump;
        }
        set
        {
            gv_Amount_DoubleJump = value;
        }
    }
}