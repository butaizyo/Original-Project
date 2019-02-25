using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour {
	//足場のPrefab
	public GameObject Field1Prefab;
	public GameObject Field2Prefab;
	public GameObject Field3Prefab;
	public GameObject Field4Prefab;
	public GameObject Field5Prefab;

	//障害物のPrefab
	public GameObject ObjectPrefab;

	//MainCamera
	private GameObject MainCamera;

	//時間計測用の変数
	private float delta = 0;
	//足場の生成間隔
	private float span = 3.5f;
	//足場の生成間隔
	private float span1 = 1.0f;

	//スタート地点
	private int startPos = 0;
	//ゴール地点
	private int goalPos = 500;


	public GameObject [] objects;

	// 足場の生成位置オフセット
	private float offsetY = 0.3f;
	// 足場キューブの縦方向の間隔
	private float spaceY = 6.9f;

	//アイテムを出すx方向の範囲
	private float posRange = 3.4f;


	// Use this for initialization
	void Start () {
		
		this.MainCamera = GameObject.Find ("MainCamera");
		
	}
	
	// Update is called once per frame
	float generatePos = 0;

	// Update is called once per fram5
	void Update ()
	{

		if (this.MainCamera.transform.position.y + 130 > generatePos) {
			Debug.Log (generatePos);
			//足場の種類を決める
			int item = Random.Range (1, 14);

			//60%field 配置:30%field1 配置:10%何もなし
			if (1 <= item && item <= 4) {
				//足場を生成
				GameObject field = Instantiate (objects [0]) as GameObject;
				this.Field1Prefab.transform.position = new Vector2 (0, generatePos);
			} else if (4 <= item && item <= 7) {
				//足場を生成
				GameObject field1 = Instantiate (objects [1]) as GameObject;
				this.Field2Prefab.transform.position = new Vector2 (0, generatePos);
			} else if (7 <= item && item <= 10) {
				//足場を生成
				GameObject field2 = Instantiate (objects [2]) as GameObject;
				this.Field3Prefab.transform.position = new Vector2 (0, generatePos);
			} else if (10 <= item && item <= 11) {
				//足場を生成
				GameObject field3 = Instantiate (objects [3]) as GameObject;
				this.Field4Prefab.transform.position = new Vector2 (0, generatePos);
			}else if (11 <= item && item <= 14) {
				//足場を生成
				GameObject field4 = Instantiate (objects [4]) as GameObject;
				this.Field5Prefab.transform.position = new Vector2 (0, generatePos);
			}

		
			generatePos += 8.5f;
		}
	}
}
