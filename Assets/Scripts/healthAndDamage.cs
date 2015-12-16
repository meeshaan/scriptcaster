using UnityEngine;
using System.Collections;

public class healthAndDamage : MonoBehaviour {
  public int Health = 3;
  public bool Immune = false;
  public Vector3 spawnPoint;
  private CameraController cc;
  private SpriteRenderer renderer;
  public float cameraWaitDuration = 3f;

	// Use this for initialization
	void Start () {
    GameObject sprite = GameObject.Find("Character Sprite");
    renderer = sprite.GetComponent<SpriteRenderer>();
	cc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  void OnCollisionEnter2D(Collision2D coll)
  {
    if (coll.gameObject.tag == "Enemy" && Immune == false)
    {
      Health -= 1;
	  Immune = true;
      ImmunityCounter();
      //Debug.Log("Detected");
    }
  }
  
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Fall" && Immune == false)
		{
			Health -= 1;
			cc.isFollowing = false;
			Immune = true;
			StartCoroutine(CameraFollowWait(cameraWaitDuration));
			
		}
	}

  void ImmunityCounter()
  {
  
    //Debug.Log("Counter");
    StartCoroutine(CharBlink(.2f, 0.2f));

  }
	

  IEnumerator CameraFollowWait(float duration)
  {
    yield return new WaitForSeconds (duration);
	GetComponent<Transform>().position = spawnPoint;
	cc.isFollowing = true;
	StartCoroutine(CharBlink(.2f, 0.2f));
	}

  IEnumerator CharBlink(float duration, float blinkTime)
  {
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
