using UnityEngine;
using System.Collections;

public class bubbleBox : MonoBehaviour {

    public bool caught;
    public Rigidbody2D box;
    public GameObject b;
    // Use this for initialization
    void Start()
    {
        caught = false;
        box = gameObject.GetComponent<Rigidbody2D>();
        box.gravityScale = 0;
        box.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (caught && b != null)
        {
            gameObject.transform.position = b.transform.position;
        }
        else if (caught && b == null)
        {
            box.isKinematic = false;
            box.gravityScale = 10.0f;
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "bubble")
        {
            caught = true;
            b = c.gameObject;
        }
    }
}
