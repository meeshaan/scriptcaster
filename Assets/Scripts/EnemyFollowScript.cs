using UnityEngine;
using System.Collections;

public class EnemyFollowScript : MonoBehaviour {

	public GameObject Player;
	public float moveSpeed = 4.0f;
	public int rotationSpeed = 3;

	private Vector2 target;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		target = Player.transform.position;
		transform.position = Vector2.MoveTowards (transform.position, target, moveSpeed * Time.deltaTime);
	}
}
