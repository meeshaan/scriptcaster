using UnityEngine;
using System.Collections;

public class lift : MonoBehaviour {

    bool seen = false;
    Renderer rend;
    public int type = 1;
    float timer = 1.0f;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (rend.isVisible)
            seen = true;

        if (seen && !rend.isVisible)
            Destroy(gameObject);

        if (timer <= 0)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag == "Enemy")
            Destroy(gameObject);
        else
        {

        }
    }
}
