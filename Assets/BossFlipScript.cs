using UnityEngine;
using System.Collections;

public class BossFlipScript : MonoBehaviour {

    public bool shouldFlip;
    public bool shouldMove;

    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            shouldFlip = false;
            shouldMove = false;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            StopCoroutine ("flipWait");
            StartCoroutine ("flipWait");
        }
    }
    
    void OnCollisionStay2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            shouldFlip = false;
        }
    }
    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            StopCoroutine ("flipWait");
            StartCoroutine ("flipWait");
        }
    }

	// Use this for initialization
	void Start () {
	   shouldFlip = true;
       shouldMove = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    IEnumerator flipWait(){
        shouldFlip = false;
        shouldMove = false;
        yield return new WaitForSeconds(1f);
        shouldFlip = true;
        shouldMove = true;
        yield return null;
    }
}
