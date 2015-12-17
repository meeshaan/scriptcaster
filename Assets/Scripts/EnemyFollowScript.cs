using UnityEngine;
using System.Collections;

public class EnemyFollowScript : MonoBehaviour {

	public GameObject Player;
	public float moveSpeed = 4.0f;
	public float rotationSpeed = 3.0f;
	public float slowPercent = 0.25f;

	private bool isSlow = false;
	private Vector2 target;

	private GameManager gameManager;
	
	void Start () 
	{
		GameObject Manager = GameObject.Find ("GameManager");
		gameManager = Manager.GetComponent<GameManager>();
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		target = Player.transform.position;
		transform.position = Vector2.MoveTowards (transform.position, target, moveSpeed * Time.deltaTime);
	}

	void FixedUpdate()
	{
		if (gameManager.SlowTime && !isSlow) {
			moveSpeed *= slowPercent;
			rotationSpeed *= slowPercent;
			isSlow = true;
		} else if (!gameManager.SlowTime && isSlow) 
		{
			moveSpeed /= slowPercent;
			rotationSpeed /= slowPercent;
			isSlow = false;
		}

	}

}
