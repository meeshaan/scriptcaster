using UnityEngine;
using System.Collections;

public class healthAndDamage : MonoBehaviour {
  public int Health = 3;
  public bool Immune = false;
  private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<SpriteRenderer> ();
    //GameObject sprite = GameObject.Find("Character Sprite");
    //renderer = sprite.GetComponent<SpriteRenderer>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  void OnCollisionEnter2D(Collision2D coll)
  {
    if (coll.gameObject.tag == "Enemy" && Immune == false)
    {
      Health -= 1;
      ImmunityCounter();
      //Debug.Log("Detected");
    }
  }

  void ImmunityCounter()
  {
  
    //Debug.Log("Counter");
    StartCoroutine(CharBlink(.5f, 0.2f));

  }

  IEnumerator CharBlink(float duration, float blinkTime)
  {
    Immune = true;
    //Debug.Log("Blink1");
    while (duration > 0f)
    {
      duration -= Time.deltaTime;

      renderer.enabled = !renderer.enabled;
      Debug.Log(duration);

      yield return new WaitForSeconds(blinkTime);
    }

    renderer.enabled = true;
    Immune = false;
  }
}
