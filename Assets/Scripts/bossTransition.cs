using UnityEngine;
using System.Collections;

public class bossTransition : MonoBehaviour {

	public int Boss;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		Debug.Log ("Boss transition");
		if (c.gameObject.tag == "Player") 
		{
			if (Boss == 1) {
				Debug.Log ("Boss 1");
				Application.LoadLevel (2);
			}
		
			if (Boss == 2) {
				//load boss 2
			}
		
			if (Boss == 3) {
				//load final boss
			}
		}
	}
}
