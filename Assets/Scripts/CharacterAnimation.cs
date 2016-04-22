using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour {
	public int isDead;
	Animator spriteAnim;
	NewMovementScript characterController;
	// Use this for initialization
	void Start () {
		spriteAnim = this.GetComponentInChildren<Animator> ();
		characterController = this.GetComponentInParent<NewMovementScript> ();

		isDead = 0;
	}
	
	// Update is called once per frame
	void Update () {
		runningAnim ();
		jumpingAnim ();
	}

	void runningAnim(){
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) {
			spriteAnim.SetBool ("running", true);
		} else {
			spriteAnim.SetBool ("running", false);
		}
	}

	void jumpingAnim(){
		if (characterController.isGrounded == true && Input.GetKey (KeyCode.Space)) {
			spriteAnim.SetBool ("jumping", true);

		}
		else if(characterController.isGrounded == true && spriteAnim.GetBool ("jumping") == true){
			spriteAnim.SetBool ("jumping", false);
		}

	}
}
