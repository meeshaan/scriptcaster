using UnityEngine;
using System.Collections;

public class boss1_spike : MonoBehaviour {
    
    private bool shouldfall;

	// Use this for initialization
	void Start () {
       Physics2D.IgnoreLayerCollision(13, 8);
	   shouldfall = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        if(shouldfall)
            this.GetComponent<Rigidbody2D>().isKinematic = false;
	}
    
    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.tag == "slash"){
            shouldfall = true;
        }
        
        if(coll.gameObject.layer == 9){
            //Destroy(this.gameObject);
        }
    }
    
    void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.tag == "slash"){
            shouldfall = true;
        }
        
        if(coll.gameObject.layer == 9){
            //Destroy(this.gameObject);
        }
    }
}
