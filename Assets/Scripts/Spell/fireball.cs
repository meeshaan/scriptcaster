using UnityEngine;
using System.Collections;

public class fireball : MonoBehaviour {

    bool seen = false;
    Renderer rend;
    public int type = 1;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (rend.isVisible)
            seen = true;

        if (seen && !rend.isVisible)
            Destroy(gameObject);
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag != "Player")
            Destroy(gameObject);
    }
}
