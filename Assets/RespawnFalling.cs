﻿using UnityEngine;
using System.Collections;

public class RespawnFalling : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Floor")
		{
			Debug.Log("Time to respawn");
		}
	}


}
