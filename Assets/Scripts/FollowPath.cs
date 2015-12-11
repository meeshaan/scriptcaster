using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour 
{
	public enum FollowType
	{
		MoveTowards,
		Lerp
	}

	public FollowType Type = FollowType.MoveTowards;
	private PathDefinition Path;
	public PathDefinition[] p;
	public PathDefinition P1;
	public PathDefinition P2;
	public PathDefinition P3; 
	public float Speed = 1;
	public float MaxDistanceToGoal = .1f;

	public IEnumerator<Transform> _currentPoint;


	private GameManager gameManager;
	private test Test;


	public void Start()
	{
		GameObject TESTER = GameObject.FindGameObjectWithTag ("GameController");
		Test = TESTER.GetComponent<test>();

		p = FindObjectsOfType<PathDefinition> ();
		for (int i = 0; i < p.Length; i++) {
			if (i == 1)
				P2 = p [i];
			else if (i == 2) 
				P1 = p [i];
			else if (i == 0)
				P3 = p [i];
		}
		if (Test.randomSpawn == 1 )
			Path = P1;
		else if (Test.randomSpawn == 2 || Test.randomSpawn == 4)
			Path = P2;
		else if( Test.randomSpawn == 3)
			Path = P3;



		//Path = FindObjectOfType<PathDefinition> ();
		if (Path == null) 
		{
			Debug.LogError("Path cannot be null", gameObject);
			return;
		}

		_currentPoint = Path.GetPathsEnumerator ();
		_currentPoint.MoveNext ();

		if (_currentPoint.Current == null)
			return;

		//transform.position = _currentPoint.Current.position;
	}

	public void Update()
	{
		if (_currentPoint == null || _currentPoint.Current == null)
			return;

		if (Type == FollowType.MoveTowards)
			transform.position = Vector3.MoveTowards (transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);
		else if (Type == FollowType.Lerp)
			transform.position = Vector3.Lerp (transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);

		var distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;
		if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
			_currentPoint.MoveNext ();
	}
}




















