using UnityEngine;
using System.Collections;

public class TextTrigger : MonoBehaviour {

    public Renderer rend;
    public TextMesh textBubble;
    public int idx;
    public string[] lines = new string[10];

	// Use this for initialization
	void Start () {
        rend.enabled = false;
        textBubble = rend.gameObject.GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        if (rend.enabled == true && Input.GetKeyDown(KeyCode.Return))
        {
            if (idx < 9 && lines[idx + 1] != "")
            {
                idx++;
                textBubble.text = lines[idx];
            }        
        }
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player" && rend.enabled == false)
        {
            Debug.Log("displaytext");
            textBubble.text = lines[idx];
            rend.enabled = true;
        }
        else if (c.gameObject.tag != "Player")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), c.gameObject.GetComponent<Collider2D>());
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (rend.enabled)
        {
            idx = 0;
            rend.enabled = false;
        }
    }
}