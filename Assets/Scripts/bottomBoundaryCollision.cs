using UnityEngine;
using System.Collections;

public class bottomBoundaryCollision : MonoBehaviour {
	Transform player;
	public int x = 0;
	public int y = 1;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		player.position.Set (0, 1, 0);
	}
}
