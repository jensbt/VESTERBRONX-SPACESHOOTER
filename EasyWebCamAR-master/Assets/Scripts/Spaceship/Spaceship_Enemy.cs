﻿using UnityEngine;
using System.Collections;

public class Spaceship_Enemy : Spaceship_Base {

	private float objectVelocity;
	private float lifeSpan;
	private EventTimer_Base timer;
	protected Transform cameraPos; 

	[System.NonSerialized]
	public Enemy_Spawn Parent;
	// Use this for initialization
	public virtual void Start() { }
	public virtual void shipInitialization(){ }

	public void  resetTimer(){
		timer.resetTimer();
	}
	// Update is called once per frame
	public override void Update () {

		Transform tmp = transform;
		Vector3 tmpPos = tmp.position;
		tmpPos.y += maneuverSpeed * Time.deltaTime;
		transform.position = tmpPos;

		if(!gameObject.activeSelf)
			return;
		
		// deletes the enemy if it flies past the camera: 
		if(transform.position.y > cameraPos.transform.position.y){	
			Destroy(gameObject);
		}


	}
	public void initTimer(float life){
		lifeSpan = life;
		timer = new EventTimer_Base(lifeSpan);
	}


	public override void takeDamage(int damage){
		health -= damage;
		if(health>=0)
		{
			Parent.deadEnemy++;
			Destroy(gameObject);
		}
	}
	// if the enemy os out of health, it will die. 
	public void die()
	{


	}



	void OnCollisionEnter(Collision other)
	{
		//If the object has the tag projectile run this
		if(other.collider.tag =="projectile")
		{
			//Run a function to subtract damage from the enemy's health, according to the damage of the projectile
			takeDamage(other.collider.GetComponent<Projectile_Base>().damage);
		}
	}




}
