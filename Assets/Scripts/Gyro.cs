﻿using UnityEngine;
using System.Collections;

public class Gyro : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		print ("Gyro: "+Input.gyro.attitude.eulerAngles.z);
	
	}
}
