using UnityEngine;
using System.Collections;

public class healthDrop : MonoBehaviour {

	private healthAndDamage health;

	// Use this for initialization
	void Start () {

		health = GameObject.FindGameObjectWithTag ("Player").GetComponent<healthAndDamage> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag != "Player") { 
			Physics2D.IgnoreCollision(GetComponent<Collider2D>(), c.gameObject.GetComponent<Collider2D>());
		}
		else if (c.gameObject.tag == "Player"){
			Destroy(this.gameObject);
			if (health.Health < 4)
			{
				health.Health++;
			}
		}
	}
}
