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
	private float span = 2;

	//足場の生成間隔
	private float span1 = 1.0f;

	//スタート地点
	private int startPos = 0;
	//ゴール地点
	private int goalPos = 500;

	//アイテムを出すY方向の範囲
	private float posRange = 10.4f;

	public GameObject [] objects;

	// Use this for initialization
	void Start () {
		
		this.MainCamera = GameObject.Find ("MainCamera");
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		//カメラが移動したらアイテムを生成
		if (this.MainCamera.transform.position.y + 10 > this.MainCamera.transform.position.y ) {

		//一定距離ごとにアイテムを生成
		for (int j = -1; j <= 1; j++) {
			//足場の種類を決める
			int item = Random.Range (1, 15);

			//60%field 配置:30%field1 配置:10%何もなし
			if (1 <= item && item <= 6) {
				//コインを生成
				GameObject field = Instantiate (objects [0]) as GameObject;
				this.Field1Prefab.transform.position = new Vector3 (0, posRange * j);
			} else if (7 <= item && item <= 9) {
				//車を生成
				GameObject field = Instantiate (objects [1]) as GameObject;
				this.Field2Prefab.transform.position = new Vector3 (0, posRange * j);
				}
			}
		}
	}
}