using UnityEngine;
using System.Collections;

public class CharController2D : MonoBehaviour {

	public float maxSpeed = 10f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	float groundRadius = 0.2f;
	bool facingRight = true;
	bool grounded = false;

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		float move = Input.GetAxis ("Horizontal");

		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if (move > 0 && !facingRight) {
			Flip ();
		} else if(move < 0 && facingRight){
			Flip();
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
