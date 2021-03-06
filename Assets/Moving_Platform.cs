﻿using UnityEngine;
using System.Collections;

public class Moving_Platform : MonoBehaviour {

	public GameObject platform;
	public float moveSpeed;
	private Transform currentPoint;
	public Transform[] points;
	public int pointsSelction; 



	// Use this for initialization
	void Start () {

		currentPoint = points[pointsSelction];
	
	}
	
	// Update is called once per frame
	void Update () {

		platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
	
		if (platform.transform.position == currentPoint.position) {

			pointsSelction++;
			if (pointsSelction == points.Length) {

				pointsSelction = 0;
			}
			currentPoint = points[pointsSelction];
		}
	}
}
