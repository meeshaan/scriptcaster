using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

    public BoxCollider2D c; //the door's collider
    public SpriteRenderer spr; //the door's sprite renderer

    public floorButton fb = null;
    public wallButton wb = null;

    public bool respondsToWall = false;
    public bool respondsToFloor = false;
	// Use this for initialization
    void Start()
    {
        c = gameObject.GetComponent<BoxCollider2D>();
        spr = gameObject.GetComponent<SpriteRenderer>();
    }
	// Update is called once per frame
	void Update () {
	    if(respondsToFloor && fb != null)
        {
            if(fb.active)
            {
                c.enabled = false;
                spr.enabled = false;
            }
            else
            {
                c.enabled = true;
                spr.enabled = true;
            }
        }
        else if (respondsToWall && wb != null)
        {
            if (wb.active)
            {
                c.enabled = false;
                spr.enabled = false;
            }
            else
            {
                c.enabled = true;
                spr.enabled = true;
            }
        }
	}
}
