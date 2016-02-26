using UnityEngine;
using System.Collections;

public class wallButton : MonoBehaviour {

    public bool active;

    // Use this for initialization
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Timers go here
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "rock") //This can be edited later on for variants
        {
            active = true;
        }
    }
}
