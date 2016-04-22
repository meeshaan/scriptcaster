using UnityEngine;
using System.Collections;

public class Boss1_HealthAndDamage : MonoBehaviour {

    private GameObject boss1_manager;
    public int typeID; //1==fire, 2==water, 3==wind, 4==earth
    private float health;
    private bool invincible;

    // Use this for initialization
    void Start()
    {
        boss1_manager = GameObject.Find("Boss1Manager");
        health = boss1_manager.GetComponent<Boss1_Manager>().health;
        invincible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(boss1_manager.GetComponent<Boss1_Manager>().attackStarted == true){
            invincible = false;            
        }
        
        if ( boss1_manager.GetComponent<Boss1_Manager>().health <= 0)
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
        
        if (c.gameObject.tag == "spike" && boss1_manager.GetComponent<Boss1_Manager>().stunned) //Detects spell type to resolve base damage
        {
            damage += 40; //Base damage
            Destroy(c.gameObject);
            Debug.Log("Damage: " + damage);
        }
        
        if(!invincible)
            boss1_manager.GetComponent<Boss1_Manager>().health -= damage;
        
        if(damage > 0){
            Debug.Log("Damage: " + damage);
            Debug.Log("Stunned? " + boss1_manager.GetComponent<Boss1_Manager>().stunned);
        }
        
        if(damage > 0 && boss1_manager.GetComponent<Boss1_Manager>().stunned){
            Debug.Log("Damage: " + damage);
            Debug.Log("Boss Health: " + boss1_manager.GetComponent<Boss1_Manager>().health);
            //this.GetComponent<Boss1_AttackCycle>().cooldownHelper();
            boss1_manager.GetComponent<Boss1_Manager>().stunned = false;
        }
        
        if(damage > 0 && boss1_manager.GetComponent<Boss1_Manager>().health < 75){
            Debug.Log("Boss Health: " + boss1_manager.GetComponent<Boss1_Manager>().health);
            this.GetComponent<Boss1_AttackCycle>().SetAnger(true);   
        }
    }
    
    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.tag == "spike" && boss1_manager.GetComponent<Boss1_Manager>().stunned){
            
            int damage = 40; //Base damage
            Destroy(coll.gameObject);
            if(!invincible)
                boss1_manager.GetComponent<Boss1_Manager>().health -= damage;
                
            boss1_manager.GetComponent<Boss1_Manager>().stunned = false;
            
            if(damage > 0 && boss1_manager.GetComponent<Boss1_Manager>().health < 75){
                Debug.Log("Boss Health: " + boss1_manager.GetComponent<Boss1_Manager>().health);
                this.GetComponent<Boss1_AttackCycle>().SetAnger(true);   
            }
        }
    }

    void OnGUI()
    {
    }
}
