using UnityEngine;
using System.Collections;

public class mentorAnimation : MonoBehaviour {

	public GameObject mentor;
	Animator mentorAnimator;

	// Use this for initialization
	void Start () {
		mentorAnimator = mentor.gameObject.GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") 
		{
			Debug.Log ("Mentor appears");
			mentorAnimator.SetBool ("in", true);
		}
	}

	void OnTriggerExit2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player")
		{
			Debug.Log ("Mentor disappears");
			mentorAnimator.SetBool ("in", false);
		}
	}
}
