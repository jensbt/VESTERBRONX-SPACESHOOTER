﻿using UnityEngine;
using System.Collections;

public class SpawnControl_Enemy : SpawnControl_Base {

	public int numberOfEnemies;
	public Enemy_Spawn spawnBase;

	public bool spawnEmpty;

	private float spwnTim = 0.5f;
	private int spawnCount = 0;
	private bool spwnWing = false;
	private Vector3 tmpPos;

	// int that determines the formation of the wave: 
	public int formationType = Random.Range(0,3);

	// spawnrate 25


	// 5 different enemies in each version
	// spawn {30,40,20,10,0}
	// how many of each enemy type to spawn
	private int[] enemySets = new int[5];

	private string[] shaderNames;

	public int EnemyDead = 0;

	private int enemyTypeCounter = 0;
	private int[] enemyTypes = new int[20];

	public void setSpawnBase (int levelNumber, int enemytospawn, int[] enemyType, float spawnTime) {
		spawnRate = spawnTime;
		numberOfEnemies = enemytospawn;
		enemyTypes = enemyType;
		spawnBase = gameObject.AddComponent<Enemy_Spawn>() as Enemy_Spawn;
		spawnBase.forceStart(levelNumber);
		spawnBase.enemiesToSpawn = numberOfEnemies;
		spawnEmpty = false;
		timer = new EventTimer_Base(spawnRate);
	}
	/*
	protected override void Start () {
		spawnEmpty = false;
		timer = new EventTimer_Base(spawnRate);
	}
	*/
	// Update is called once per frame
	protected override void Update () {
		EnemyDead = spawnBase.deadEnemy;
		if(spawnBase.enemiesToSpawn > 0){
			if(timer.timerTick()){
				timer.TimerValue = spawnRate;
				spwnWing = true;
				tmpPos = new Vector3 (transform.position.x + Random.Range(-50f,50f),transform.position.y,transform.position.z);
//				Debug.Log(spawnBase.enemiesToSpawn);
			}
		}else if (transform.childCount == 0){

			spawnEmpty = true;
		}



		if (spwnWing){
			spwnTim -= Time.deltaTime * 2f;
			if (spwnTim < 0){
				spawnBase.SpawnWing(tmpPos , spawnCount, enemyTypes[enemyTypeCounter], formationType);
				spawnCount++;
				spwnTim = 1.5f;
			}
			if (spawnCount > 2){
				timer.TimerValue = spawnRate + Random.Range(-spawnRate/8,spawnRate/8);
				timer.resetTimer();
				enemyTypeCounter++;
				spwnWing = false;
				spawnCount = 0;
				spwnTim = 1.5f;
				formationType = Random.Range(0,3);
			}
		}
	
	}
}
