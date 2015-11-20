using UnityEngine;
using System.Collections;

public class boulder : MonoBehaviour {

    bool seen = false;
    Renderer rend;
    public float timer = 5.0f;
    int strength = 1;
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

        timer -= Time.deltaTime;

        if (timer <= 0)
            Destroy(gameObject);

    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag == "Enemy" && strength == 0)
            Destroy(gameObject);

        if (c.collider.tag == "Enemy" && strength > 0)
            strength--;
    }
}
