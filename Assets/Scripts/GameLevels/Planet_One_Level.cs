﻿using UnityEngine;
using System.Collections;

public class Planet_One_Level : Mission_Level {

	public override void loadLevel()
	{
		levelNames = new string[8];
		levelNames[0] = "Level 1";
		levelNames[1] = "Level 2";
		levelNames[2] = "Level 3";
		levelNames[3] = "Level 4";
		levelNames[4] = "Level 5";
		levelNames[5] = "Level 6";
		levelNames[6] = "Level 7";
		levelNames[7] = "Level 8";
		
		if(levels.Count == 0){
			setLevels();
		}


		levelLoaded = true;
		completed = false;
		
		planetState = "Home";
		player = GameObject.Find("ARCamera");
		script = player.GetComponent<Player_Charactor>();
		GameObject image = GameObject.Find ("ImageTarget");
		
		string newProp;
		Vector3 newScale;
		Vector3 newPosition;
		Vector3 newRotation;

		newProp = "LevelProps/EnemyGallery";
		newScale = new Vector3(150,150,150);
		newPosition = new Vector3(0,0,0);
		newRotation = new Vector3(0,0,0);
		createSceneObject(newProp,newScale,newPosition,newRotation,image.transform);
		transform.parent = transform;

		swipeScript = props[0].GetComponent<CameraSwipe>();

		newProp = "SunLight";
		newScale = new Vector3(1,1,1);
		newPosition = new Vector3(0,15,-15);
		newRotation = new Vector3(125,0,0);
		createDirectionalLightInScene(newProp,newScale,newPosition ,newRotation,
		                              image.transform, new Color (0.8f,0.3f,0.0f,1.0f));

	}


	public override void setLevels()
	{
		Level_One newLevel0 = gameObject.AddComponent("Level_One") as Level_One;
		levels.Add(newLevel0);
		Level_Two newLevel1 = gameObject.AddComponent("Level_Two") as Level_Two;
		levels.Add(newLevel1);
		Level_Three newLevel2 = gameObject.AddComponent("Level_Three") as Level_Three;
		levels.Add(newLevel2);
		Level_Four newLevel3 = gameObject.AddComponent("Level_Four") as Level_Four;
		levels.Add(newLevel3);
		Level_5 newLevel4 = gameObject.AddComponent("Level_5") as Level_5;
		levels.Add(newLevel4);
		Level_6 newLevel5 = gameObject.AddComponent("Level_6") as Level_6;
		levels.Add(newLevel5);
		Level_7 newLevel6 = gameObject.AddComponent("Level_7") as Level_7;
		levels.Add(newLevel6);
		Level_8 newLevel7 = gameObject.AddComponent("Level_8") as Level_8;
		levels.Add(newLevel7);
		
	}

}
