using UnityEngine;
using System.Collections;

public class EnemySpell : MonoBehaviour {

    bool seen = false;
    Renderer rend;
    public int type = 1;
    // Use this for initialization
    void Start()
    {
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
        if (c.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), c.gameObject.GetComponent<Collider2D>());
        }
        else
            Destroy(gameObject);
    }
}
