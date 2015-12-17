using UnityEngine;
using System.Collections;

public class drop : MonoBehaviour {

    bool seen = false;
    Renderer rend;
    public int type = 1;
    GameObject pl;
    TextControlScript castPoint;
    float timer = 1.0f;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        pl = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), pl.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), pl.GetComponent<CircleCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag == "Enemy")
            Destroy(gameObject);
    }
}
