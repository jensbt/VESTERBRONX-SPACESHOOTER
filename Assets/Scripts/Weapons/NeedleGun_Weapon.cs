﻿using UnityEngine;
using System.Collections;

public class NeedleGun_Weapon : Weapons_Base {
	
	public override void forceStart () 
	{
		barrelEnd = transform.FindChild("barrelEnd").transform;
		fireExplosion = Resources.Load("Audio/needleGunS") as AudioClip;

		ammoType = "Vesterbro/Projectile_needle";
		// upgradeStates = { rate of fire , damage , capacity }
		// will range from 0 to topLimit?
		// the purchase value of the weapon
		weaponValue = 2000;
		// Damage of projetile
		projectileDamage = 230;
		// the rate of fire value
		rateOfFire = 3/4f;
		// magasin capacity
		magCapacity = 120;
		
		//fireTimer = new Weapon_Timer(weaponRateOfFire());
	}
}
