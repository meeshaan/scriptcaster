using UnityEngine;
using System.Collections;

public class rockthrow : MonoBehaviour {

    bool seen = false;
    Renderer rend;
    public int type = 4;
    int strength = 1;
	private AudioSource audio;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
		audio = gameObject.GetComponent<AudioSource> ();
	}

    // Update is called once per frame
    void Update()
    {
        if (rend.isVisible)
            seen = true;

        if (seen && !rend.isVisible)
            Destroy(gameObject);

    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag != "Player" && strength == 0)
            Destroy(gameObject);

        if (c.collider.tag != "Player" && strength > 0)
			audio.Play ();
            strength--;
    }
}
