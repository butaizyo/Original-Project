using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	//Main
	private GameObject MainCamera;

	//スクロール速度
	private float scrollSpeed = -0.30f;
	//背景終了位置
	//private float deadline = -48;
	//背景開始位置
	//private float StartLine = 5;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		//背景を移動する
		transform.Translate(0,this.scrollSpeed,0);

		//画面外に出たら、画面に移動する
		//if(transform.position.y < this.deadline) {
		if (this.MainCamera.transform.position.y > this.gameObject.transform.position) {
			transform.position = new Vector2 (0, this.MainCamera.transform.position.y);
		}
	}
}
