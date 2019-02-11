using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour {
	//足場のPrefab
	public GameObject Field1Prefab;
	public GameObject Field2Prefab;
	public GameObject Field3Prefab;
	public GameObject Field4Prefab;

	//障害物のPrefab
	public GameObject ObjectPrefab;

	//MainCamera
	private GameObject MainCamera;

	//時間計測用の変数
	private float delta = 0;

	//足場の生成間隔
	private float span = 0.2f;

	//足場の生成位置:Y座標
	private float genPosY = 3;

	//足場の生成位置オフセット
	private float offsetY = 0.3f;

	//足場の縦方向の間隔
	private float spaceY = 2.9f;

	//足場の生成位置オフセット
	private float offsetX = 0.5f;
	//キューブの横方向の間隔
	private float spaceX = 0.4f;

	//足場の生成個数の上限
	private int maxFieldNum =1;

	//スタート地点
	private int startPos = 0;

	//アイテムを出すy方向の範囲
	private float posRange = 2.4f;

	public GameObject [] objects;

	// Use this for initialization
	void Start () {
		
		this.MainCamera = GameObject.Find ("MainCamera");
		
	}
	
	// Update is called once per frame
	void Update ()
	{


		this.delta += Time.deltaTime;

		//span秒以上の時間が経過したか調べる
		if (this.delta > this.span) {
			this.delta = 0;

			// ランダムな数字（０〜5）を取得
			int n = Random.Range (0, 5);
			for (int i = startPos; i < n; i += 3) {
				// ゲームオブジェクトを生成
				GameObject field = Instantiate (objects [0]) as GameObject;
				GameObject field1 = Instantiate (objects [n]) as GameObject;
				transform.position = new Vector3 (0, this.MainCamera.transform.position.y + 3);


				//transform.position = new Vector3 (0, this.offsetY + i * this.spaceY);

				//次の足場までの生成時間を決める
				this.span = this.offsetX + this.spaceX * n;
			}
		}
	}
}