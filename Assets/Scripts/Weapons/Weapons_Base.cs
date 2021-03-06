﻿using UnityEngine;
using System.Collections;

public class Weapons_Base : MonoBehaviour {

	public Transform barrelEnd;
	public AudioClip fireExplosion;

	//determines when the player can shoot again:
	public bool canShoot = true;

	public string ammoType;
	// upgradeStates = { rate of fire , damage , capacity }
	// will range from 0 to topLimit?
	public int[] upgradeStates = new int[3];
	// the purchase value of the weapon
	public int weaponValue;
	// Damage of projetile
	public int projectileDamage;
	// the rate of fire value
	public float rateOfFire;
	// magasin capacity
	public int magCapacity;
	

	// Use this for initialization
	public virtual void forceStart () {}

	public void setFireRate(float newFire){
		rateOfFire = newFire;
	}
	public int fireWeapon(){

		Debug.Log(upgradeStates[0] + "  " + upgradeStates[1] + "  " + upgradeStates[2]);
		Debug.Log(weaponRateOfFire()  + "  " + weaponDamage() + "  " + weaponCapacity());
		/*if(fireTimer.timerTick()){
			fireTimer.TimerValue = weaponRateOfFire();   
			fireTimer.resetTimer();
*/
		//if(fireTimer.timerTick())
		if(canShoot){
		//	fireTimer.TimerValue = weaponRateOfFire();   
		//	fireTimer.resetTimer();
			StartCoroutine (Shoot (weaponRateOfFire()));
			audio.PlayOneShot(fireExplosion);
			GameObject newShot = (GameObject) Object.Instantiate(Resources.Load(ammoType));
			newShot.tag = "PlayerProjectile";
			newShot.layer = LayerMask.NameToLayer("PlayerProjectile");
			Projectile_Base script = newShot.GetComponent<Projectile_Base>();
			script.setProjectileDamage(weaponDamage());
			newShot.transform.position = barrelEnd.position;
			newShot.transform.rotation = barrelEnd.rotation;
			return 1;
		}else{
			return 0;
		}

	}
	public void setUpStates(int up1, int up2, int up3){
		upgradeStates[0] = up1;
		upgradeStates[1] = up2;
		upgradeStates[2] = up3;
	}


	/// <summary>
	/// Weapons the rate of fire.
	/// </summary>
	/// <returns>The rate of fire.</returns>
	public float weaponRateOfFire(){
		float wROF = rateOfFire  - (rateOfFire * (upgradeStates[0] / 10.0f));
		return wROF;
	}
	public float weaponRateOfFire(int num){
		float wROF = rateOfFire  - (rateOfFire * (num / 10.0f));
		return wROF;
	}

	/// <summary>
	/// Weapons the damage.
	/// </summary>
	/// <returns>The damage.</returns>
	public int weaponDamage(){
		int wDam = projectileDamage + (int) (projectileDamage * (upgradeStates[1] / 10.0f));
		return wDam;
	}
	public int weaponDamage(int num){
		int wDam = projectileDamage + (int) (projectileDamage * (num / 10.0f));
		return wDam;
	}

	/// <summary>
	/// Weapons the capacity.
	/// </summary>
	/// <returns>The capacity.</returns>
	public int weaponCapacity(){
		int wCap = magCapacity + (int) (magCapacity * (upgradeStates[2] / 10.0f));
		return wCap;
	}
	public int weaponCapacity(int num){
		int wCap = magCapacity + (int) (magCapacity * (num / 10.0f));
		return wCap;
	}

	protected IEnumerator Shoot(float fireRate) {
		canShoot = false;
		yield return new WaitForSeconds(fireRate);
		canShoot = true;
	}


}
