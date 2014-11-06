﻿using UnityEngine;
using System.Collections;

public class Level_Two :  LevelScript_Level {


	public override void loadLevel( )
	{
		setClassTargets();
		loadButtons();	
		
		levelNumber = 2;
		howManyEnemies = 50;
		
		
		Debug.Log(priceCreditsValue() + " " + priceCreditsTotal());
		
		
		newScale = new Vector3(10,10,10);
		newPosition = new Vector3(0,0,-20);
		newRotation = new Vector3(90,0,0);
		createPlayerSpaceship(script.hangar.hangarslots[script.shipChoise],newScale,newPosition,newRotation,background.transform,true,true);
		
		
		
		newProp = "EnemySpawn";
		newScale = new Vector3(1,1,1);
		newPosition = new Vector3(0,-4000,-20);
		newRotation = new Vector3(-90,0,180);
		createSceneObject(newProp,newScale,newPosition,newRotation,background.transform);
		spwnScr = props[0].GetComponent<SpawnControl_Enemy>();
		int[] enemyTypeSelection = new int[20]{	0,0,1,0,0,
												0,1,0,0,1,
												0,0,1,0,1,
												1,0,1,0,1};

		spwnScr.setSpawnBase(levelNumber , 100,enemyTypeSelection);
		spwnScr.numberOfEnemies = howManyEnemies;
		
		newProp = "MeteorSpawn";
		newScale = new Vector3(1,1,1);
		newPosition = new Vector3(0,-1000,-100);
		newRotation = new Vector3(90,0,0);
		createSceneObject(newProp,newScale,newPosition,newRotation,background.transform);
	
		newProp = "SunLight";
		newScale = new Vector3(1,1,1);
		newPosition = new Vector3(0,0,0);
		newRotation = new Vector3(0,180,90);
		createDirectionalLightInScene(newProp,newScale,newPosition ,newRotation,
		                              background.transform, Color.yellow);

		newProp = "Vortex";
		newScale = new Vector3(1,1,1);
		newPosition = new Vector3(0,2,0);
		newRotation = new Vector3(0,90,0);
		createSceneObject(newProp,newScale,newPosition,newRotation,background.transform);
		
	}
	public override void updateLevel(){
		
		
		
		if(useAxisInput) {
			// assigns the position of the joystick to h and v
			joystickInput = joystick.position.x;
		}
		else {
			joystickInput = Input.GetAxis("Horizontal");
		}
		
		sentButtonInput();
		
		
		if (spwnScr.spawnEmpty){
			SpawnControl_Enemy tmpscr =  props[0].GetComponent<SpawnControl_Enemy>();
			enemiesDestroyed = tmpscr.EnemyDead;
			
			if( (float)enemiesDestroyed/howManyEnemies > 0.6f){
				endGame = "Complete";
				gain = priceCreditsTotal();
			}else {
				endGame = "Fail";
				gain = 0;
			}
			
			_unLoadTimer -= Time.deltaTime * 1f;
			
			if(_unLoadTimer < 0){
				if( (float)enemiesDestroyed/howManyEnemies > 0.6f){
					script.credits += priceCreditsTotal();

				}
				
				completed = true;	
				closeLevel();
				unloadButtons();
				Spaceship_Player shipScript = script.hangar.hangarslots[script.shipChoise].GetComponent<Spaceship_Player>();
				shipScript.gameObject.SetActive(false);
				shipScript.IsActive = false;
				Debug.Log("Empty");
			}
			
		}


	}
	
	

	

}
