using UnityEngine;
using System.Collections;

public class TextTrigger : MonoBehaviour {

    public Renderer rend;

	// Use this for initialization
	void Start () {
        rend.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag != "Player")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), c.gameObject.GetComponent<Collider2D>());
        }
        else if (c.gameObject.tag == "Player" && rend.enabled == false)
        {
        Debug.Log("displaytext");
            rend.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (rend.enabled)
        {
            rend.enabled = false;
        }
    }
}
