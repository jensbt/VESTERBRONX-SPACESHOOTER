﻿using UnityEngine;
using System.Collections;

public class Spaceship_Enemy : Spaceship_Base {

	//private float objectVelocity;

	private float lifeSpan;
	private EventTimer_Base timer;
	protected Transform cameraPos;

	// The rate of fire is set in the child classes of the class and sets the rate of fire for the enemy's weapons
	protected float fireRate;

	// collisionDamage of the ENEMY
	public int collisionDamage;

	[System.NonSerialized]
	public Enemy_Spawn Parent;
	// Use this for initialization
	public virtual void Start() { }
	public virtual void shipInitialization(){ }


	public void resetEnemyType(float m, int h, int s, float f){
		maneuverSpeed = m;
		health = h;
		shield = s;
		fireRate = f;
		timer.resetTimer();
	}

	public void  resetTimer(){
		timer.resetTimer();
	}

	// Update is called once per frame
	public override void Update () {

		Transform tmp = transform;
		Vector3 tmpPos = tmp.position;
		tmpPos.y += maneuverSpeed * Time.deltaTime;
		transform.position = tmpPos;
		if(hitTimer.timerActive){
			manageShader();
		}
		if(!gameObject.activeSelf)
			return;
		
		// deletes the enemy if it flies past the camera: 
		if(transform.position.y > cameraPos.transform.position.y){	
			Destroy(gameObject);
		}
		//	RaycastHit hit;
		//	Ray weaponSight = new Ray(transform.position,Vector3.forward);
		//	Debug.DrawRay(transform.position,Vector3.forward, Color.blue);

		//if(Physics.Raycast(weaponSight,out hit, 5000f)){
			//if(hit.collider.tag == "Player"){

				
			//}
		//}
		for (int i = 0; i < canonMountCapacity; i++) {
			EnemyWeapon_Base script = canonMounted[i].GetComponent<EnemyWeapon_Base> ();
			script.fireWeapon ();
		}



	}
	public override void initializeCanon(Transform scale, int i)
	{
		canonMounted[i] = (GameObject)Object.Instantiate(Resources.Load(canonTypes[i]));
		Transform thisTrans = canonMounted[i].transform;
		canonMounted[i].transform.localScale = new Vector3(thisTrans.localScale.x * scale.localScale.x ,thisTrans.localScale.y * scale.localScale.y , thisTrans.localScale.z * scale.localScale.z);
		canonMounted[i].transform.position = canonMount[i].position;
		canonMounted[i].transform.rotation = canonMount[i].rotation;
		canonMounted[i].transform.parent = canonMount[i].transform;
		EnemyWeapon_Base wwscript = canonMounted [i].GetComponent<EnemyWeapon_Base> ();
		wwscript.forceStart ();
		wwscript.setFireRate (fireRate);
	}



	public void initTimer(float life){
		lifeSpan = life;
		timer = new EventTimer_Base(lifeSpan);
	}


	public override void takeDamage(int damage){
		if(shield > 0){
			hitTimer.timerActive = true;
			renderer.material.SetFloat("_ShieldBlend" , 1);
			hitTimer.resetTimer();
			if(shield - damage > 0){
				shield -= damage;
			}else{
				shield -= damage;
				health -= -1 * (shield - damage);
			}
		}else{
			health -= damage;
		}
		if(health<=0)
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
		if(other.collider.tag =="PlayerProjectile")
		{
			//Run a function to subtract damage from the enemy's health, according to the damage of the projectile
			takeDamage(other.collider.GetComponent<Projectile_Base>().damage);
		}
	}




}
