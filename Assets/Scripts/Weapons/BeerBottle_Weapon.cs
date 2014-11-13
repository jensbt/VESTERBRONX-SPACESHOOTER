﻿using UnityEngine;
using System.Collections;

public class BeerBottle_Weapon : Weapons_Base {
	
	public override void forceStart () 
	{
		barrelEnd = transform.FindChild("barrelEnd").transform;
		fireExplosion = Resources.Load("Audio/BeerBottleGunS") as AudioClip;

		ammoType = "VesterBro/Projectile_bottle";
		// upgradeStates = { rate of fire , damage , capacity }
		// will range from 0 to topLimit?
		// the purchase value of the weapon
		weaponValue = 3000;
		// Damage of projetile
		projectileDamage = 225;
		// the rate of fire value
		rateOfFire = 2.2f;
		// magasin capacity
		magCapacity = 25;
		
	//	fireTimer = new Weapon_Timer(weaponRateOfFire());
	}
}
