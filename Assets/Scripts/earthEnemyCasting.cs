using UnityEngine;
using System.Collections;

public class earthEnemyCasting : MonoBehaviour {

    public AI_PlayerDetection detect;
    public Transform spell;
    public float projSpeed;
    public float fireInterval;
    public bool active;

    // Use this for initialization
    void Start()
    {
        detect = gameObject.transform.parent.GetComponentInChildren<AI_PlayerDetection>();
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (detect.isDetected && !active)
        {
            active = true;
            StartCoroutine("fireAtInterval");
        }

    }

    IEnumerator fireAtInterval()
    {
        //Will need to adjust for direction: Ask Brent
        while (detect.isDetected)
        {
            yield return new WaitForSeconds(fireInterval);

            Transform bullet = (Transform)Instantiate(spell, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
            Transform bullet2 = (Transform)Instantiate(spell, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.localScale.x, 0));
            bullet2.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * -this.transform.localScale.x, 0));
        }
    }
}
