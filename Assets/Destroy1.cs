using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy1 : MonoBehaviour {

	//MainCamera
	private GameObject MainCamera;


	// Use this for initialization
	void Start () {
		this.MainCamera = GameObject.Find("MainCamera");

	}

	// Update is called once per frame
	void Update () {

		//画面外に出たら破棄する
		if (this.MainCamera.transform.position.y - this.gameObject.transform.position.y >= 30) {
			Destroy (gameObject);	
		}
	}
}