using UnityEngine;
using System.Collections;

public class Shockwave : MonoBehaviour {
    
    private GameObject boss1;
    private bool facingLeft;
    private Collider col1;
    private Collider col2;
    
	// Use this for initialization
	void Start () {
	   boss1 = GameObject.Find("Boss1 (Sprite)");
       facingLeft = boss1.GetComponent<Boss1_AttackCycle>().facingLeft;
       
       StartCoroutine(duration());
	}
	
	// Update is called once per frame
	void Update () {
        Physics2D.IgnoreLayerCollision(13, 0);
        Physics2D.IgnoreLayerCollision(13, 8);
        Physics2D.IgnoreLayerCollision(13, 1);
        Physics2D.IgnoreLayerCollision(13, 11);
        Physics2D.IgnoreLayerCollision(13, 12);
        if(facingLeft){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * 1100  * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (!facingLeft){
            this.transform.localScale = new Vector3(-.1f,.1f,.1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(1 * 1100  * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
        }   
	}
    
    IEnumerator duration(){
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
        yield return null;
    }
    
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "shockStop"){
            Destroy(this.gameObject);
        }
    }
}
