using UnityEngine;
using System.Collections;

public class delete : MonoBehaviour {
	private GameObject enemy;
	private GameManager gm;
	private test T;
	public int health = 2;
	
	// Use this for initialization
	void Start () {
		GameObject G = GameObject.FindGameObjectWithTag ("GameController");
		gm = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ();
		T = G.GetComponent<test> ();

		enemy = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			gm.enemiesKilled++;
			Destroy (this.gameObject);
		}
	}
	IEnumerator OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "spell") {
			Debug.Log("wooooooo");
			//Destroy((other.gameObject));
			health -- ;
			//Destroy (this.gameObject);
			
			//T.cubeCount = T.cubeCount -1;
			yield return new WaitForSeconds(2.0f);
			
		}
	}
	
}
