using UnityEngine;
using System.Collections;

public class bottomBoundaryCollision : MonoBehaviour {
	GameObject player;
	public int x = 0;
	public int y = 1;
	public Vector2 start = new Vector2(0,1);

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		player.transform.position = start;
	}
}
