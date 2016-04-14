using UnityEngine;
using System.Collections;

public class Shockwave : MonoBehaviour {
    
    private GameObject boss1;
    private bool facingLeft;
    
	// Use this for initialization
	void Start () {
	   boss1 = GameObject.Find("Boss1");
       facingLeft = boss1.GetComponent<Boss1_AttackCycle>().facingLeft;
       
       StartCoroutine(duration());
	}
	
	// Update is called once per frame
	void Update () {
        Physics2D.IgnoreLayerCollision(13, 8);
        Physics2D.IgnoreLayerCollision(13, 1);
        Physics2D.IgnoreLayerCollision(13, 11);
        Physics2D.IgnoreLayerCollision(13, 12);
        if(facingLeft){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * 500  * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (!facingLeft){
            GetComponent<Rigidbody2D>().velocity = new Vector2(1 * 500  * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);           
        }   
	}
    
    IEnumerator duration(){
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
        yield return null;
    }
}
