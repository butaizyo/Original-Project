using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	//ゲームオーバテキスト
	private GameObject gameOverText;

	//上昇距離テキスト
	private GameObject ScoreText;

	//昇った距離
	private float rise = 0;

	//昇る速度
	private float speed = 0.01f;

	//ゲームオーバの判定
	private bool isGameOver = false;

	// Use this for initialization
	void Start () {
		//シーンビューからオブジェクトの実体を検索する
		this.gameOverText = GameObject.Find ("GameOver");
		this.ScoreText = GameObject.Find ("Score");
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isGameOver == false) {
			//上昇距離を更新する
			this.rise += this.speed;
			//上昇距離を表示する
			this.ScoreText.GetComponent<Text> ().text = "Score:  "  + rise.ToString ("F2") + "m";
		}
		//ゲームオーバになった場合
		if (this.isGameOver == true) {
			//クリックされたらシーンをロードする
			if (Input.GetMouseButtonDown (0)) {
				//GameSceneを読み込む
				SceneManager.LoadScene ("GameScene");
			}
		}
	}
	public void GameStart () {
		SceneManager.LoadScene ("START");
	}

	public void GameOver() {
		//ゲームオーバになったときに、画面上にゲームオーバを表示する
		this.gameOverText.GetComponent<Text>().text = "GameOver";
		this.isGameOver = true;
	}

}