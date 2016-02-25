using UnityEngine;
using System.Collections;

public class rope : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
