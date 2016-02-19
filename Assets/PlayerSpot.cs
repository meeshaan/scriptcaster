using UnityEngine;
using System.Collections;

public class PlayerSpot : MonoBehaviour {
		
	public Transform startSight, endSight, endSight1, endSight2, endSight3;
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
		Debug.DrawLine (startSight.position,endSight1.position,Color.red);
		Debug.DrawLine (startSight.position,endSight2.position,Color.red);
		Debug.DrawLine (startSight.position,endSight3.position,Color.red);

		//spotted = Physics2D.Linecast (startSight.position, endSight.position, 1 << LayerMask.NameToLayer("Player"));

		if (Physics2D.Linecast (startSight.position, endSight.position, 1 << LayerMask.NameToLayer ("Player")) == true ||
		   Physics2D.Linecast (startSight.position, endSight1.position, 1 << LayerMask.NameToLayer ("Player")) == true ||
		   Physics2D.Linecast (startSight.position, endSight2.position, 1 << LayerMask.NameToLayer ("Player")) == true ||
		   Physics2D.Linecast (startSight.position, endSight3.position, 1 << LayerMask.NameToLayer ("Player")) == true) {
			spotted = true;
		} else
			spotted = false;
	}

	void Behaviors()
	{

	}
	void Patrol ()
	{

		//flip left and right at random intervals
		if (facingLeft == true) {
			transform.eulerAngles = new Vector2 (0, 0);
		}
		else {
			transform.eulerAngles = new Vector2 (0, 180);
		}
		facingLeft = !facingLeft;
	}
	void movement()
	{
		if (spotted == true) {
			target = Player.transform.position;
			transform.position = Vector2.MoveTowards (transform.position, target, moveSpeed * Time.deltaTime);
			/*	
			if (facingLeft == true) {
				endSight.transform.position.x += 10;
				endSight1.transform.position.x += 10;
				endSight2.transform.position.x += 10;
				endSight3.transform.position.x += 10;
			} else {
				endSight.transform.position.x -= 10;
				endSight1.transform.position.x -= 10;
				endSight2.transform.position.x -= 10;
				endSight3.transform.position.x -= 10;
			}*/
		} else {
			target = endSight.transform.position;
			transform.position = Vector2.MoveTowards (transform.position, target, moveSpeed/2 * Time.deltaTime);
		}

	}
}
