using UnityEngine;
using System.Collections;

public class wall : MonoBehaviour {

    bool seen = false;
    Renderer rend;
    public float timer = 10.0f;
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
        if (c.collider.tag == "Enemy")
            Destroy(gameObject);
        else if (c.collider.tag == "boss" || c.collider.tag == "boss_damage")
            Destroy(gameObject);
            
    }
}
