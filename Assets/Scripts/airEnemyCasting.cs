using UnityEngine;
using System.Collections;

public class airEnemyCasting : MonoBehaviour {

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
        while (detect.isDetected)
        {
            yield return new WaitForSeconds(fireInterval);
            if (!gameObject.transform.parent.GetComponent<AI_Patrol_Air>().facingLeft)
            {
                Transform bullet = (Transform)Instantiate(spell, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 15)));
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.transform.localScale.x + 15, 15) * projSpeed);

                yield return new WaitForSeconds(1.5f);

                bullet = (Transform)Instantiate(spell, this.gameObject.transform.position, Quaternion.Euler(new Vector3(180, 0, 15)));
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.transform.localScale.x + 15, -15) * projSpeed);
            }
            else
            {
                Transform bullet = (Transform)Instantiate(spell, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 180, 15)));
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-this.transform.localScale.x - 15, 15) * projSpeed);

                yield return new WaitForSeconds(1.5f);

                bullet = (Transform)Instantiate(spell, this.gameObject.transform.position, Quaternion.Euler(new Vector3(180, 180, 15)));
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-this.transform.localScale.x - 15, -15) * projSpeed);
            }
        }
    }
}
