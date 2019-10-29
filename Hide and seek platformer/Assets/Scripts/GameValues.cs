using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameValues {
	private static bool gv_GameStarted, gv_IsPaused;
	private static int gv_Carrots, gv_ProgressInLevels;
	private static float gv_HealthPoints;
	private static int gv_MainMenu, gv_PauseMenu, gv_OptionsMenu, gv_LevelSelect, gv_GameOver;
	private static int gv_Tutorial, gv_Level_1, gv_Level_2, gv_Level_3, gv_Level_4, gv_Level_5, gv_BossLevel;
	private static int gv_PreviousMenu, gv_CurrentLevel;

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
}