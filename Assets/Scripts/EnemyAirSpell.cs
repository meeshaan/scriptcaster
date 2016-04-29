using UnityEngine;
using System.Collections;

public class EnemyAirSpell : MonoBehaviour {

    bool seen = false;
    Renderer rend;
    public int type = 1;
    float timer = 1.5f;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        Physics2D.IgnoreLayerCollision(11, 11);
    }

    // Update is called once per frame
    void Update()
    {
        if (rend.isVisible)
            seen = true;

        if (seen && !rend.isVisible)
            Destroy(gameObject);

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag != "Player")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), c.gameObject.GetComponent<Collider2D>());
        }
        else
            Destroy(gameObject);
    }
}
