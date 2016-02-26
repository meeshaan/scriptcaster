using UnityEngine;
using System.Collections;

public class rope : MonoBehaviour {

    GameObject pl;

	// Use this for initialization
	void Start () {

        pl = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), pl.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), pl.GetComponent<CircleCollider2D>());
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "fireball" || c.gameObject.tag == "blast" || c.gameObject.tag == "slash")
        {
            Destroy(gameObject);
        }
    }
}
