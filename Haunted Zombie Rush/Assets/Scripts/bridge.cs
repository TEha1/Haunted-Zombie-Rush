using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridge : MonoBehaviour {

	// Use this for initialization
	[SerializeField] protected float objectSpeed;
	[SerializeField] protected int startPosition = 94;
	[SerializeField] protected int resetPoint = 5;

	void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		
		transform.Translate (Vector3.left * (objectSpeed * Time.deltaTime));
		if (transform.position.x <= resetPoint) {
			Vector3 newPosition = new Vector3 (startPosition, transform.position.y, transform.position.z);
			transform.position = newPosition;
		}
	}
}
