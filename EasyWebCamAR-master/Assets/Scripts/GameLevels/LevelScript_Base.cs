﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelScript_Base : MonoBehaviour {

	protected GameObject player; 
	protected Player_Charactor script;

	protected int numberOfEnemies;
	protected List<GameObject> props = new List<GameObject>();


	protected bool completed;

	public virtual void loadLevel(){}
	public virtual void updateLevel(){}
	public virtual void levelGUI(){	}

	protected void createSceneObject(string gameProp,Vector3 scale,Vector3 pos,Vector3 turnRotation,Transform cameraTransform)
	{
		GameObject tmp = (GameObject)Object.Instantiate(Resources.Load(gameProp));
		tmp.transform.localScale = scale;
		Vector3 newPos = cameraTransform.position;
		newPos.x += pos.x;
		newPos.y += pos.y;
		newPos.z += pos.z;
		tmp.transform.position = newPos;
		tmp.transform.rotation = cameraTransform.rotation;
		tmp.transform.Rotate(new Vector3(1,0,0) * turnRotation.x );
		tmp.transform.Rotate(new Vector3(0,1,0) * turnRotation.y );
		tmp.transform.Rotate(new Vector3(0,0,1) * turnRotation.z );
		props.Add(tmp);
	}
	protected void createSceneObject(GameObject gameProp,Vector3 scale,Vector3 pos,Vector3 turnRotation,Transform cameraTransform)
	{
		GameObject tmp = (GameObject)Object.Instantiate(gameProp);
		tmp.transform.localScale = scale;
		Vector3 newPos = cameraTransform.position;
		newPos.x += pos.x;
		newPos.y += pos.y;
		newPos.z += pos.z;
		tmp.transform.position = newPos;
		tmp.transform.rotation = cameraTransform.rotation;
		tmp.transform.Rotate(new Vector3(1,0,0) * turnRotation.x );
		tmp.transform.Rotate(new Vector3(0,1,0) * turnRotation.y );
		tmp.transform.Rotate(new Vector3(0,0,1) * turnRotation.z );
		tmp.SetActive(true);
		props.Add(tmp);

	}
	protected void createPlayerSpaceship(GameObject gameProp,Vector3 scale,Vector3 pos,Vector3 turnRotation,Transform cameraTransform, bool active, bool onStage)
	{
		gameProp.transform.localScale = scale;
		Vector3 newPos = cameraTransform.position;
		newPos.x += pos.x;
		newPos.y += pos.y;
		newPos.z += pos.z;
		gameProp.transform.position = newPos;
		gameProp.transform.rotation = cameraTransform.rotation;
		gameProp.transform.Rotate(new Vector3(1,0,0) * turnRotation.x );
		gameProp.transform.Rotate(new Vector3(0,1,0) * turnRotation.y );
		gameProp.transform.Rotate(new Vector3(0,0,1) * turnRotation.z );
		gameProp.SetActive(onStage);
		Spaceship_Player shipScript = gameProp.GetComponent<Spaceship_Player>();
		shipScript.IsActive = active;
	}
	protected void createDirectionalLightInScene(string gameProp,Vector3 scale,Vector3 pos,Vector3 turnRotation,
	                                  			Transform cameraTransform, Color lightColor)
	{
		GameObject tmp = new GameObject (gameProp);
		tmp.AddComponent<Light>();
		tmp.light.type = LightType.Directional;
		tmp.light.color = Color.white;

		tmp.transform.localScale = scale;
		Vector3 newPos = cameraTransform.position;
		newPos.x += pos.x;
		newPos.y += pos.y;
		newPos.z += pos.z;
		tmp.transform.position = newPos;
		tmp.transform.rotation = cameraTransform.rotation;
		tmp.transform.Rotate(new Vector3(1,0,0) * turnRotation.x );
		tmp.transform.Rotate(new Vector3(0,1,0) * turnRotation.y );
		tmp.transform.Rotate(new Vector3(0,0,1) * turnRotation.z );
		props.Add(tmp);


	}
	public bool Completed{
		get{return completed;}
		set{completed = value;}
	}

	protected void closeLevel(){
		foreach(GameObject element in props){
			Destroy(element);
		}
		props.Clear();

	}

}
