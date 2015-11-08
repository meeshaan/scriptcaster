using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterEleFacing : MonoBehaviour {

  bool facingLeft = true;
  //public FollowPath path;
  //public IEnumerator<Transform> _currentPoint;
  public GameObject WaterEle;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
    //_currentPoint = path._currentPoint;
    Vector3 PointPos = WaterEle.GetComponent<FollowPath>()._currentPoint.Current.position;
    Vector3 ElementalPos = WaterEle.transform.position;

    if(PointPos.x < ElementalPos.x && !facingLeft)
    {
      Flip();
    }
    else if (PointPos.x > ElementalPos.x && facingLeft)
    {
      Flip();
    }
	}

  void Flip()
  {
    facingLeft = !facingLeft;
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
  }
}
