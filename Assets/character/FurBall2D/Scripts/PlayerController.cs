using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


	public float maxSpeed = 6f;
	public float jumpForce = 1000f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float verticalSpeed = 20;
	[HideInInspector]
	public bool lookingRight = true;
	bool doubleJump = false;
	public GameObject Boost;
	
	private Animator cloudanim;
	public GameObject Cloud;


	private Rigidbody2D rb2d;
	private Animator anim;
	private bool isGrounded = false;

	//MainCamera
	private GameObject MainCamera;

	//ゲームオーバになる位置
	private float deadLine = -15;

	//上昇距離テキスト
	private GameObject ScoreText;

	//昇った距離
	private float rise = 0;

	//昇る速度
	private float speed = 0.01f;

	// Use this for initialization
	void Start () {
		MainCamera = GameObject.Find("MainCamera");
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		//cloudanim = GetComponent<Animator>();

		Cloud = GameObject.Find("Cloud");
  		//cloudanim = GameObject.Find("Cloud(Clone)").GetComponent<Animator>();

		//シーン中のScoreオブジェクトを取得
		this.ScoreText = GameObject.Find ("Score");
	}


	void OnCollisionEnter2D(Collision2D collision2D) {
		
		if (collision2D.relativeVelocity.magnitude > 20){
			Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
		//	cloudanim.Play("cloud");	

		}
	}


	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Jump") && (isGrounded || !doubleJump)) {
			rb2d.AddForce (new Vector2 (0, jumpForce));

			if (!doubleJump && !isGrounded) {
				doubleJump = true;
				Boost = Instantiate (Resources.Load ("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
				//	cloudanim.Play("cloud");		
			}
		}


		if (Input.GetButtonDown ("Vertical") && !isGrounded) {
			rb2d.AddForce (new Vector2 (0, -jumpForce));
			Boost = Instantiate (Resources.Load ("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
			//cloudanim.Play("cloud")
		}

		if (this.MainCamera.transform.position.y >= 0 ) {
			
			//上昇距離を更新する
			this.rise += this.speed;
		
		//	Debug.Log(this.ScoreText.GetComponent<Text> ().text ="Score: " + rise.ToString("F2")  + "m" );
			//上昇距離を表示する
			//this.ScoreText.GetComponent<Text> ().text = "Score:  "  + rise.ToString ("F2") + "m";
		}
			
		//デッドラインを超えた場合ゲームオーバにする
		if (this.MainCamera.transform.position.y - this.gameObject.transform.position.y > 15) {
			//UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する
			GameObject.Find ("Canvas").GetComponent<UIController> ().GameOver ();
			Destroy (gameObject);
		}
	}


	void FixedUpdate()
	{
		if (isGrounded) 
			doubleJump = false;


		float hor = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (hor));

		rb2d.velocity = new Vector2 (hor * maxSpeed, rb2d.velocity.y);
		  
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.15F, whatIsGround);

		anim.SetBool ("IsGrounded", isGrounded);

		if ((hor > 0 && !lookingRight)||(hor < 0 && lookingRight))
			Flip ();
		 
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
	}


	
	public void Flip()
	{
		lookingRight = !lookingRight;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}

}
