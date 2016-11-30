﻿using UnityEngine;
using System.Collections;

public static class DataManager {

	public static void LoadData(string level, int isFinished, int star) {
	
	}
	
	// isFinished: 1 for next level is unlocked
	// star: the number of coins you get
	public static void SaveData(string level, int isFinished, int star) {
		
		PlayerPrefs.SetInt(level.ToString() + "isFinished", isFinished);
		
		// no star statics or better result then update data
		if (!PlayerPrefs.HasKey("starOf" + level.ToString()) ||
			PlayerPrefs.GetInt("starOf" + level.ToString()) < star) {
				
			PlayerPrefs.SetInt("starOf" + level.ToString(), star);
		}
		
	}
 
}
