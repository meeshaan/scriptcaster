using UnityEngine;
using System.Collections;

public class Boss3_spellcasting : MonoBehaviour {

    //Projectile spell speeds, placeholders for now 
    public float fbSpeed;
    public float wtSpeed;
    public float arSpeed;
    public float erSpeed;

    //Array of castpoints for projectiles from boss
    public GameObject[] castArray = new GameObject[8];

    //Player object for when spells need to target the player's position
    public GameObject player;

    //Spell prefabs, placeholders until we start making spell prefabs
    public Transform testProj;
    public Transform test2;

    //Test timer
    public float timer = 3.0f;

    //Direction 
    public bool facingLeft = true;
    Vector3 leftBlastOffset;
    Vector3 rightBlastOffset;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        leftBlastOffset = new Vector3(castArray[6].transform.position.x - 1.17f, castArray[6].transform.position.y, castArray[6].transform.position.z);
        rightBlastOffset = new Vector3(castArray[2].transform.position.x + 1.17f, castArray[2].transform.position.y, castArray[2].transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        //Test timer
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Cast(1);
            timer = 3.0f;
        }	    
	}

    void Cast (int cond) {
        switch (cond)
        {
            case 1: //Spreadshot fireballs
                if(facingLeft) //vectors will invert depending on direction boss is facing
                {
                    Transform bullet = (Transform)Instantiate(testProj, castArray[6].transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-this.transform.localScale.x, 0) * fbSpeed);
                    Transform bullet2 = (Transform)Instantiate(testProj, castArray[5].transform.position, Quaternion.Euler(new Vector3(0, 0, 45)));
                    bullet2.GetComponent<Rigidbody2D>().AddForce(new Vector2(-this.transform.localScale.x, -this.transform.localScale.y) * fbSpeed);
                    Transform bullet3 = (Transform)Instantiate(testProj, castArray[4].transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                    bullet3.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -this.transform.localScale.y) * fbSpeed);
                }
                else
                {
                    Transform bullet = (Transform)Instantiate(testProj, castArray[2].transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
                    bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.transform.localScale.x, 0) * fbSpeed);
                    Transform bullet2 = (Transform)Instantiate(testProj, castArray[3].transform.position, Quaternion.Euler(new Vector3(0, 180, 45)));
                    bullet2.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.transform.localScale.x, -this.transform.localScale.y) * fbSpeed);
                    Transform bullet3 = (Transform)Instantiate(testProj, castArray[4].transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                    bullet3.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -this.transform.localScale.y) * fbSpeed);
                }
                break;
            case 2:
                if(facingLeft)
                {
                    Transform blast = (Transform)Instantiate(test2, leftBlastOffset, Quaternion.Euler(new Vector3(0, 0, -90)));
                }
                else
                {
                    Transform blast = (Transform)Instantiate(test2, rightBlastOffset, Quaternion.Euler(new Vector3(0, 0, 90)));
                }
                break;
            default:
                break;
        }
    }
}
