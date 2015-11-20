using UnityEngine;
using System.Collections;

public class droplet : MonoBehaviour {

    bool seen = false;
    Renderer rend;
    public int type = 1;
    GameObject pl;
    public Transform drop;
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
        if (rend.isVisible)
            seen = true;

        if (seen && !rend.isVisible)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag == "Enemy")
            Destroy(gameObject);

        else
        {
            Transform drip = (Transform)Instantiate(drop, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
    }
}
