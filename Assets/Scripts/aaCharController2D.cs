using UnityEngine;
using System.Collections;

public class aaCharController2D : MonoBehaviour {

	public float maxSpeed = 10f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	public float slow = 2f;


	float groundRadius = 0.2f;
	bool facingRight = true;
	bool grounded = false;
	bool gravitySwitched = false;
	public bool isSlow = false;

	Animator spriteAnim;
	
	private GameManager gameManager;

	void Start () 
	{
		GameObject Manager = GameObject.Find ("GameManager");
		gameManager = Manager.GetComponent<GameManager>();

		spriteAnim = this.GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		if (gameManager.SlowTime == true && isSlow == false) {
			maxSpeed = maxSpeed / slow;
			//jumpForce = jumpForce / slow;
			isSlow = true;
		}
		else if (gameManager.SlowTime == false && isSlow == true) 
		{
			maxSpeed = maxSpeed * slow;
			GetComponent<Rigidbody2D>().gravityScale /= 0.25f;
			//jumpForce = jumpForce*slow;
			isSlow = false;
			gravitySwitched = false;
			Debug.Log ("Back");
		}

		if(isSlow && !gravitySwitched && GetComponent<Rigidbody2D>().velocity.y < 0)
		{
			GetComponent<Rigidbody2D>().gravityScale *= 0.25f;
			gravitySwitched = true;
			Debug.Log("Switched");
		}










		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		float move = Input.GetAxis ("Horizontal");

		if (grounded)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		else
			GetComponent<Rigidbody2D>().velocity = new Vector2(move * (maxSpeed/2), GetComponent<Rigidbody2D>().velocity.y);

		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip ();
		} else {
		}
	}

	void Update()
	{
		if (grounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
