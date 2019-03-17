using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : bridge {

	[SerializeField] Vector3 positionTop; 
	[SerializeField] Vector3 positionBottom; 
	[SerializeField] float speed; 

	// Use this for initialization
	void Start () {
		StartCoroutine (move (positionBottom));
	}
	protected override void Update() {
		if (GameManager.instance.getPlayerActive ()) {
			base.Update ();
		}

	}

	IEnumerator move(Vector3 target) {

		while (Mathf.Abs ((target - transform.position).y) > 0.20f) {
			Vector3 direction = target.y == positionTop.y ? Vector3.up : Vector3.down;
			transform.localPosition = transform.localPosition + direction * Time.deltaTime * speed;
			yield return null;
		}
		yield return new WaitForSeconds (0.5f);
		Vector3 newTarget = target.y == positionTop.y ? positionBottom : positionTop;
		StartCoroutine (move (newTarget));
	}
}
