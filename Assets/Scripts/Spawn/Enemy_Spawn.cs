﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy_Spawn : SpawnClass_Base {

	private int profileSet;
	private int levelNum;

	public string[] enemyShipScipt;

	private float objScale = 7f;
	public bool enemySpawning;
	private Vector3 spawnPosition;
	private float portalTime;

	public string enemyType;

	public int enemiesToSpawn;

	public int deadEnemy = 0;

	private GameObject portal;

	private string[] versionModifier;

	public void forceStart(int leveln){
		levelNum = leveln;
		profileSet = GameObject.Find("ARCamera").GetComponent<Player_Charactor>().gameSetting;
		versionModifier = GameObject.Find("ARCamera").GetComponent<Player_Charactor>().enemyVersion;

		spawnObject = new GameObject[4];
		spawnObject[0] = (GameObject)Resources.Load(versionModifier[0]);
		spawnObject[1] = (GameObject)Resources.Load(versionModifier[1]);
		spawnObject[2] = (GameObject)Resources.Load(versionModifier[2]);
		spawnObject[3] = (GameObject)Resources.Load(versionModifier[3]);
		/*
		if(profileSet == 0){
			spawnObject = new GameObject[3];
			spawnObject[0] = (GameObject)Resources.Load("Enemies/Mustang");
			spawnObject[1] = (GameObject)Resources.Load("Enemies/Needle");
			spawnObject[2] = (GameObject)Resources.Load("Enemies/Spike");
		}else{
			spawnObject = new GameObject[3];
			spawnObject[0] = (GameObject)Resources.Load("Enemies/Mustang");
			spawnObject[1] = (GameObject)Resources.Load("Enemies/Needle");
			spawnObject[2] = (GameObject)Resources.Load("Enemies/Spike");
		}
		*/
		portal = (GameObject)Resources.Load("PortalFog");
		
		enemySpawning = false;
		enemyShipScipt = new string[4] {"EnemyFirstClass","EnemySecondClass","EnemyThirdClass","EnemyFourthClass"};

		portalTime = 0.66f;
		stackSize = 25;
	}
	// Use this for initialization
	/*public override void Start () {

		portal = (GameObject)Resources.Load("PortalFog");

		enemySpawning = false;
		enemyShipScipt = new string[2];
		enemyShipScipt[0] = "EnemyFirstClass";
		enemyShipScipt[1] = "EnemySecondClass";

		spawnObject = new GameObject[1];
		spawnObject[0] = (GameObject)Resources.Load("xxx");


		portalTime = 0.66f;
		stackSize = 25;

	}*/

	public void SpawnWing(Vector3 newPos , int num, int type , int formation){
		if (formation == 0) {
			switch (num) {
			case 0:
					spawnPosition = new Vector3 (newPos.x, newPos.y, newPos.z);
					Spawn (type);
					break;
			case 1:
					spawnPosition = new Vector3 (newPos.x + 80, newPos.y, newPos.z);
					Spawn (type);
					spawnPosition = new Vector3 (newPos.x - 80, newPos.y, newPos.z);
					Spawn (type);
					break;
			case 2:
					spawnPosition = new Vector3 (newPos.x + 160, newPos.y, newPos.z);
					Spawn (type);
					spawnPosition = new Vector3 (newPos.x - 160, newPos.y, newPos.z);
					Spawn (type);
					break;
			default:
					break;
			}
		}

		else if(formation ==1){
			switch (num) {
			case 0:
				spawnPosition = new Vector3 (newPos.x-160, newPos.y, newPos.z);
				Spawn (type);
				break;
			case 1:
				spawnPosition = new Vector3 (newPos.x - 80, newPos.y, newPos.z);
				Spawn (type);
				spawnPosition = new Vector3 (newPos.x , newPos.y, newPos.z);
				Spawn (type);
				break;
			case 2:
				spawnPosition = new Vector3 (newPos.x + 80, newPos.y, newPos.z);
				Spawn (type);
				spawnPosition = new Vector3 (newPos.x + 160, newPos.y, newPos.z);
				Spawn (type);
				break;
			default:
				break;
			}
		}
		else if(formation ==2){
			switch (num) {
			case 0:
				spawnPosition = new Vector3 (newPos.x+160, newPos.y, newPos.z);
				Spawn (type);
				break;
			case 1:
				spawnPosition = new Vector3 (newPos.x + 80, newPos.y, newPos.z);
				Spawn (type);
				spawnPosition = new Vector3 (newPos.x , newPos.y, newPos.z);
				Spawn (type);
				break;
			case 2:
				spawnPosition = new Vector3 (newPos.x - 80, newPos.y, newPos.z);
				Spawn (type);
				spawnPosition = new Vector3 (newPos.x - 160, newPos.y, newPos.z);
				Spawn (type);
				break;
			default:
				break;
			}
		}
		else{
			switch (num) {
			case 0:
				spawnPosition = new Vector3 (newPos.x + 160, newPos.y, newPos.z);
				Spawn (type);
				spawnPosition = new Vector3 (newPos.x - 160, newPos.y, newPos.z);
				Spawn (type);
				break;
			case 1:
				spawnPosition = new Vector3 (newPos.x + 80, newPos.y, newPos.z);
				Spawn (type);
				spawnPosition = new Vector3 (newPos.x -160 , newPos.y, newPos.z);
				Spawn (type);
				break;
			case 2:
				spawnPosition = new Vector3 (newPos.x, newPos.y, newPos.z);
				Spawn (type);

				break;
			default:
				break;
			}
		}


		}

	public override  void Spawn(int type)
	{
		GameObject go = (GameObject)Object.Instantiate(spawnObject[type]);
		go.transform.localScale = new Vector3 (objScale,objScale,objScale);
		go.transform.position = spawnPosition ;
		go.transform.rotation = transform.rotation;
		//int ls = (int)Random.Range(0.5f , 1.5f);
		go.AddComponent(enemyShipScipt[type]);
		Spaceship_Enemy createdObject = go.GetComponent<Spaceship_Enemy>();
		createdObject.forceStart();
		createdObject.modifyEnemy(levelNum);
		createdObject.Parent = this;
		createdObject.transform.parent = this.transform;
		enemiesToSpawn--;
		Instantiate(portal, spawnPosition,transform.rotation);

	}

	private int modifyValue(int modifier){
		return modifier * levelNum;
	}

}
