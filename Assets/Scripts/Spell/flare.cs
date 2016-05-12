using UnityEngine;
using System.Collections;

public class flare : MonoBehaviour {

    bool seen = false;
    Renderer rend;
    public int type = 1;
    GameObject pl;
    public Transform nova;
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
            Vector3 newPos = gameObject.transform.position;
            pl.gameObject.transform.position = newPos;

            newPos.x = newPos.x + 0.1f;
            newPos.z++;
            newPos.y = newPos.y + 0.15f;

            Transform fNova = (Transform)Instantiate(nova, newPos, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
    }
}
