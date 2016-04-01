using UnityEngine;
using System.Collections;
    
public class Boss2Damage : MonoBehaviour {
    public GameObject Boss;
	// Use this for initialization
	void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {
	
	}
     void OnCollisionEnter2D(Collision2D c)
        {
        
        if(c.gameObject.tag == "fireball"){
           Boss.GetComponent<Renderer>().material.color = Color.red;

           //Destroy(gameObject);
            //gameObject.transform.GetComponent<Renderer>().material.color = Color.red;
            //transform.GetComponent<Renderer>().material.color = Color.yellow;
        }
}
}     