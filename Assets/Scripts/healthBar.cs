using UnityEngine;
using System.Collections;

public class healthBar : MonoBehaviour {
	public Sprite health4;
	public Sprite health3;
	public Sprite health2;
	public Sprite health1;
	private healthAndDamage health;
	private SpriteRenderer healthSR;
	private Animator player;
	//private isDead death;



	// Use this for initialization
	void Start () {
		health = GameObject.FindGameObjectWithTag ("Player").GetComponent<healthAndDamage> ();
		healthSR = GameObject.FindGameObjectWithTag ("healthBar").GetComponent<SpriteRenderer> ();
		player = GameObject.FindGameObjectWithTag ("Character Sprite").GetComponent<Animator> ();
		//death = player.GetComponent<isDead>();
	}
	
	// Update is called once per frame
	void Update () {
		if (health.Health == 4) {
			healthSR.sprite = health4;
		} else if (health.Health == 3) {
			healthSR.sprite = health3;
		} else if (health.Health == 2) {
			healthSR.sprite = health2;
		} else if (health.Health == 1) {
			healthSR.sprite = health1;
		} else {
			healthSR.sprite = null;
			player.SetBool("dead", true);
			StartCoroutine(Lose ());
		}
	}

	IEnumerator Lose(){
		Debug.Log("We died!");
		yield return new WaitForSeconds(1.2f);
		Application.LoadLevel ("lose");

	}
}
