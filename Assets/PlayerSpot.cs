using UnityEngine;
using System.Collections;

public class PlayerSpot : MonoBehaviour {
		
	public Transform startSight, endSight;
	public bool spotted = false;
	public bool facingLeft = true;
	public GameObject Player;
	public Vector2 target;
	public float moveSpeed = 1.0f;



	// Use this for initialization
	void Start () {
		InvokeRepeating ("Patrol", 0f, Random.Range(4f,6f)) ;
		Player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		Raycasting ();
		Behaviors ();
		movement ();

	}

	void Raycasting()
	{
		Debug.DrawLine (startSight.position,endSight.position,Color.red);
		spotted = Physics2D.Linecast (startSight.position, endSight.position, 1 << LayerMask.NameToLayer("Player"));

	}

	void Behaviors()
	{

	}
	void Patrol ()
	{

		//flip left and right at random intervals
		facingLeft = !facingLeft;
		if (facingLeft == true) {
			transform.eulerAngles = new Vector2 (0, 0);
		}
		else {
			transform.eulerAngles = new Vector2 (0, 180);
		}
	}
	void movement()
	{
		if (spotted == true) {
			target = Player.transform.position;
			transform.position = Vector2.MoveTowards (transform.position, target, moveSpeed * Time.deltaTime);
		}
	}
}
