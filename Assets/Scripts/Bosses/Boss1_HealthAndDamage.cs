using UnityEngine;
using System.Collections;

public class Boss1_HealthAndDamage : MonoBehaviour {

    private GameObject boss1_manager;
    public int typeID; //1==fire, 2==water, 3==wind, 4==earth
    private float health;

    // Use this for initialization
    void Start()
    {
        boss1_manager = GameObject.Find("Boss1Manager");
        health = boss1_manager.GetComponent<Boss1_Manager>().health;
    }

    // Update is called once per frame
    void Update()
    {
        if ( health <= 0)
        {
            Destroy(this.gameObject);
        }
    
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        int damage = 0;

        if (c.gameObject.tag == "fireball") //Detects spell type to resolve base damage
        {
            Debug.Log("took base damage 10");
            damage += 10; //Base damage
            if (typeID == 3){ //Critical damage
            }
            else if (typeID == 2) //Resisted damage
            {
            }
        }
        
/*
        if (c.gameObject.tag == "bubble") //Detects spell type to resolve base damage
        {
            Debug.Log("took base damage 10");
            damage += 10; //Base damage
            if (typeID == 1) //Critical damage
            {
            }
            else if (typeID == 4) //Resisted damage
            {
            }
        }

        if (c.gameObject.tag == "slash") //Detects spell type to resolve base damage
        {
            Debug.Log("took base damage 10");
            damage += 10; //Base damage
            if (typeID == 4) //Critical damage
            {
            }
            else if (typeID == 1) //Resisted damage
            {
            }
        }*/
        
        if (c.gameObject.tag == "spike" && boss1_manager.GetComponent<Boss1_Manager>().stunned) //Detects spell type to resolve base damage
        {
            Debug.Log("took base damage 65");
            damage += 40; //Base damage
            Destroy(c.gameObject);
        }
        
        if(boss1_manager.GetComponent<Boss1_Manager>().stunned){
            //damage *= 6;
        }
        boss1_manager.GetComponent<Boss1_Manager>().health -= damage;
        
        
        if(damage > 0 && boss1_manager.GetComponent<Boss1_Manager>().stunned){
            //this.GetComponent<Boss1_AttackCycle>().cooldownHelper();
            boss1_manager.GetComponent<Boss1_Manager>().stunned = false;
        }
    }
    
    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.tag == "spike" && boss1_manager.GetComponent<Boss1_Manager>().stunned){
            Debug.Log("hit by: " + coll.gameObject.tag + " named: " + coll.gameObject.name);
            int damage = 40; //Base damage
            Destroy(coll.gameObject);
            boss1_manager.GetComponent<Boss1_Manager>().health -= damage;
            //this.GetComponent<Boss1_AttackCycle>().cooldownHelper();
            boss1_manager.GetComponent<Boss1_Manager>().stunned = false;
        }
    }

    void OnGUI()
    {
    }
}
