using UnityEngine;
using System.Collections;

public class floorButton : MonoBehaviour {

    public bool active;

	// Use this for initialization
	void Start () {
        active = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "enemy")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), c.gameObject.GetComponent<Collider2D>());
        }
        else if (c.gameObject.tag == "Player" || c.gameObject.tag == "boulder")
        {
            active = true;
        }
    }

    void OnCollisionExit2D(Collision2D c)
    {
        if (active)
        {
            active = false;
        }
    }
}
