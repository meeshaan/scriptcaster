using UnityEngine;
using System.Collections;

public class suspendedObject : MonoBehaviour {

    public Rigidbody2D body;
    public bool released = false;
    public GameObject rope;

	// Use this for initialization
	void Start () {
        body = gameObject.GetComponent<Rigidbody2D>();
        body.isKinematic = true;
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), rope.GetComponent<Collider2D>());
	}
	
	// Update is called once per frame
	void Update () {
        if (rope == null)
        {
            body.isKinematic = false;
        }
	    
	}
}
