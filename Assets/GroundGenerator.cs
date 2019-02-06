using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour {
	//足場のPrefab
	public GameObject Field1Prefab;
	public GameObject Field2Prefab;
	public GameObject Field3Prefab;
	public GameObject Field4Prefab;

	//時間計測用の変数
	private float delta = 0;

	//足場の生成間隔
	private float span = 1.0f;

	//足場の生成位置:Y座標
	private float genPosX = 12;

	//足場の生成位置オフセット
	private float offsetY = 0.3f;

	//足場の縦方向の間隔
	private float spaceY = 6.9f;

	//足場の生成位置オフセット
	private float offsetX = 0.5f;
	//キューブの横方向の間隔
	private float spaceX = 0.4f;

	//足場の生成個数の上限
	private int maxFieldNum =4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.delta += Time.deltaTime;

		//span秒以上の時間が経過したか調べる
		if (this.delta > this.span) {
			this.delta = 0;
			//生成する足場数をランダムに決める
			int n = Random.Range (1,maxFieldNum+1);

			//指定した数だけ足場を生成する
			for (int i = 0; i < n; i++) {
				//足場の生成
				GameObject go = Instantiate (Field1Prefab) as GameObject;
				go.transform.position = new Vector2 (this.genPosX, this.offsetY + i * this.spaceY);
			}
			//次の足場までの生成時間を決める
			this.span = this.offsetX + this.spaceX * n;
		}
	}
}
