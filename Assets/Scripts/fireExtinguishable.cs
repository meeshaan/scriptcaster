using UnityEngine;
using System.Collections;

public class fireExtinguishable : MonoBehaviour {

    public int dur = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (dur == 0)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "spout")
        {
            dur--;
        }
    }
}
