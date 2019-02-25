﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	//Main
	private GameObject MainCamera;

	// Use this for initialization
	void Start () {
		MainCamera = GameObject.Find("MainCamera");
	}

	// Update is called once per frame
	void Update () {
		if (this.MainCamera.transform.position.y - this.gameObject.transform.position.y >= 50.5f) {
			transform.position = new Vector2 (0, this.MainCamera.transform.position.y + 57.5f);
		}
	}
}
