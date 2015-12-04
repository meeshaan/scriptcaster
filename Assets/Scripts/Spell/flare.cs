using UnityEngine;
using System.Collections;

public class flare : MonoBehaviour {

    bool seen = false;
    Renderer rend;
    public int type = 1;
    GameObject pl;
    // Use this for initialization
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
        rend = GetComponent<Renderer>();
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
        if (c.collider.tag != "Player")
        {
            Vector2 newPos = gameObject.transform.position;
            pl.gameObject.transform.position = newPos;
            Destroy(gameObject);
        }
    }
}
