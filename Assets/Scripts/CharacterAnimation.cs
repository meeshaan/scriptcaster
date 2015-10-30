using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour {

	Animator spriteAnim;
	aaCharController2D characterController;
	// Use this for initialization
	void Start () {
		spriteAnim = this.GetComponentInChildren<Animator> ();
		characterController = this.GetComponentInParent<aaCharController2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		runningAnim ();
		jumpingAnim ();
	}

	void runningAnim(){
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {
			spriteAnim.SetBool ("running", true);
		} else {
			spriteAnim.SetBool ("running", false);
		}
	}

	void jumpingAnim(){
		if (characterController.grounded == true && Input.GetKey (KeyCode.Space)) {
			spriteAnim.SetBool ("jumping", true);

		}
		else if(characterController.grounded == true && spriteAnim.GetBool ("jumping") == true){
			spriteAnim.SetBool ("jumping", false);
		}

	}
}
