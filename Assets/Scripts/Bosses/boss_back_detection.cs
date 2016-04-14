using UnityEngine;
using System.Collections;

public class boss_back_detection : MonoBehaviour {
    
    public bool playerOnBack;
    public GameObject boss;

	// Use this for initialization
	void Start () {
	   playerOnBack = false;
	}
    void OnTriggerStay2D (Collider2D col){
        if(col.gameObject.tag == "Player"){
            playerOnBack = true;
        }
    }
    void OnTriggerExit2D (Collider2D col){
        if(col.gameObject.tag == "Player"){
            playerOnBack = false;
            boss.GetComponent<Boss1_AttackCycle>().cooldownHelper();
        }
    }
}
