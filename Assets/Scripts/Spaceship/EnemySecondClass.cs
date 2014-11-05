﻿using UnityEngine;
using System.Collections;

public class EnemySecondClass : Spaceship_Enemy {
	
	public override void Start() { 
		cameraPos = GameObject.Find ("ARCamera").transform;
		
		renderer.material.shader = Shader.Find("Game/TransparentBulgingShield");
		renderer.material.SetColor("_Color" , Color.white);
		renderer.material.SetColor("_ColorShield" ,new Color(0.0f,0.2f,0.6f,0.0f));
		

		canonScale = transform;
		health = 30;
		shield = 10;
		// Ship speed
		maneuverSpeed = 300f;
		// damage inflicted if the player collides with this enemy
		collisionDamage = 100;
		// Amount of gun attachments 
		canonMountCapacity = transform.childCount;
		// sets the rate of fire for the guns of this Enemy:
		fireRate = 10;
		
		
		// Find the canon mounts on model
		canonMount = new Transform[canonMountCapacity];
		canonTypes = new string[canonMountCapacity];

		// the guns of this enemy:
		canonTypes[0] = "enemyCanon";
		canonTypes[1] = "enemyCanon";
		canonTypes[2] = "enemyCanon";
		canonTypes[3] = "enemyCanon";


		
		for (int i = 0 ; i < transform.childCount ; i ++){
			canonMount[i] = transform.FindChild("mountT" + i);
			canonTypes[i] = canonTypes[i];
		}
		// Give an intitial value to canon types
		
		// Set array for canons
		canonMounted = new GameObject[canonMountCapacity];
		// Save the initial rotation of ship for reference
		spaceshipRotation = transform.rotation.z;
		
		for(int i = 0 ; i < canonMountCapacity/2 ; i++){
			mountCanon(i);
		}
		// this function determines how often the ship will fire
		//setRateofFire ();

	}
	public virtual void shipInitialization(){
		
		
		
	}
}