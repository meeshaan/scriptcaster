using UnityEngine;
using System.Collections;

public class EnemyDamageControl : MonoBehaviour {

    private GameObject enemy;
    private GameManager gm;
    private test T;
    public int health; //Base health value: 100
    public int typeID; //1==fire, 2==water, 3==wind, 4==earth
    private Vector3 healthPos;
	public GameObject healthDrop;
	public int healthChance;

    // Use this for initialization
    void Start()
    {
        GameObject G = GameObject.FindGameObjectWithTag("GameController");
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        T = G.GetComponent<test>();
        
        enemy = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(WaitForDeathAnimations());
            gm.enemiesKilled++;
            Destroy(this.gameObject);
			int randomNum = Random.Range (1, 10);
			Debug.Log (randomNum);
			if (randomNum <= healthChance) 
			{
				Instantiate (healthDrop, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
			}
        }
    
    }
    IEnumerator WaitForDeathAnimations() {

        yield return new WaitForSeconds(5);  ///edit this for lenght of time for death animations
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        int damage = 0;

        if (c.gameObject.tag == "fireball") //Detects spell type to resolve base damage
        {
            Debug.Log("took base damage 35");
            damage += 35; //Base damage
            if (typeID == 3) //Critical damage
            {
                damage += 35;
                Debug.Log("took critical damage, total 70");
            }
            else if (typeID == 2) //Resisted damage
            {
                damage -= 17;
                Debug.Log("took resisted damage, total 18");
            }
        }

        if (c.gameObject.tag == "blast") //Detects spell type to resolve base damage
        {
            Debug.Log("took base damage 50");
            damage += 65; //Base damage
            if (typeID == 3) //Critical damage
            {
                damage += 65;
                Debug.Log("took critical damage, total 130");
            }
            else if (typeID == 2) //Resisted damage
            {
                damage -= 25;
                Debug.Log("took resisted damage, total 25");
            }
        }

        if (c.gameObject.tag == "nova") //Detects spell type to resolve base damage
        {
            Debug.Log("took base damage 15");
            damage += 15; //Base damage
            if (typeID == 3) //Critical damage
            {
                damage += 30;
                Debug.Log("took critical damage, total 30");
            }
            else if (typeID == 2) //Resisted damage
            {
                damage -= 7;
                Debug.Log("took resisted damage, total 8");
            }
        }

        if (c.gameObject.tag == "bubble") //Detects spell type to resolve base damage
        {
            Debug.Log("took base damage 45");
            damage += 45; //Base damage
            if (typeID == 1) //Critical damage
            {
                damage += 45;
                Debug.Log("took critical damage, total 90");
            }
            else if (typeID == 4) //Resisted damage
            {
                damage -= 22;
                Debug.Log("took resisted damage, total 23");
            }
        }

        if (c.gameObject.tag == "drop") //Detects spell type to resolve base damage
        {
            Debug.Log("took base damage 60");
            damage += 60; //Base damage
            if (typeID == 1) //Critical damage
            {
                damage += 60;
                Debug.Log("took critical damage, total 120");
            }
            else if (typeID == 4) //Resisted damage
            {
                damage -= 30;
                Debug.Log("took resisted damage, total 30");
            }
        }

        if (c.gameObject.tag == "spout") //Detects spell type to resolve base damage
        {
            Debug.Log("took base damage 20");
            damage += 20; //Base damage
            if (typeID == 1) //Critical damage
            {
                damage += 20;
                Debug.Log("took critical damage, total 40");
            }
            else if (typeID == 4) //Resisted damage
            {
                damage -= 10;
                Debug.Log("took resisted damage, total 10");
            }
        }

        if (c.gameObject.tag == "slash") //Detects spell type to resolve base damage
        {
            Debug.Log("took base damage 65");
            damage += 65; //Base damage
            if (typeID == 4) //Critical damage
            {
                damage += 65;
                Debug.Log("took critical damage, total 130");
            }
            else if (typeID == 1) //Resisted damage
            {
                damage -= 32;
                Debug.Log("took resisted damage, total 33");
            }
        }

        if (c.gameObject.tag == "gust") //Detects spell type to resolve base damage
        {
            Debug.Log("took base damage 30");
            damage += 30; //Base damage
            if (typeID == 4) //Critical damage
            {
                damage += 30;
                Debug.Log("took critical damage, total 60");
            }
            else if (typeID == 1) //Resisted damage
            {
                damage -= 15;
                Debug.Log("took resisted damage, total 15");
            }
        }

        if (c.gameObject.tag == "rock") //Detects spell type to resolve base damage
        {
            Debug.Log("took base damage 35");
            damage += 35; //Base damage
            if (typeID == 2) //Critical damage
            {
                damage += 35;
                Debug.Log("took critical damage, total 70");
            }
            else if (typeID == 3) //Resisted damage
            {
                damage -= 17;
                Debug.Log("took resisted damage, total 18");
            }
        }

        if (c.gameObject.tag == "boulder") //Detects spell type to resolve base damage
        {
            Debug.Log("took base damage 50");
            damage += 50; //Base damage
            if (typeID == 2) //Critical damage
            {
                damage += 50;
                Debug.Log("took critical damage, total 100");
            }
            else if (typeID == 3) //Resisted damage
            {
                damage -= 25;
                Debug.Log("took resisted damage, total 25");
            }
        }

        health -= damage;
    }

    void OnGUI()
    {
        healthPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        GUI.Label(new Rect(healthPos.x, healthPos.y, 50, 20), health.ToString());
    }
}
