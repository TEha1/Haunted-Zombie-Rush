using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class player : MonoBehaviour {

	[SerializeField] private float forceJump = 100f;

	Animator anim; // w da elli byb2a feh kol L 7agat elli by3mlha L Object
	Rigidbody rigidbody; // da elli by5li ay gsm yt2sr bi L 7agat elli 7waleh 
	private bool jump = false;

	[SerializeField] private AudioClip sfxJump;
	[SerializeField] private AudioClip sfxDead;
	AudioSource audiosource;


	void Awake() { // Awake() --> di btrag3 3la elli nta 3ayzwo 2bl ma L L3ba tbd2
		Assert.IsNotNull (sfxJump);
		Assert.IsNotNull (sfxDead);
	}

	void Start () {
		anim = GetComponent<Animator> ();
		rigidbody = GetComponent<Rigidbody> ();
		audiosource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.getGameStarted() && !GameManager.instance.getGameOver()) {
			if (Input.GetMouseButtonDown (0)) { // hna bt2ol lw das 3la click fo2 hy3ml L 7agat elli t7t di
				GameManager.instance.setPlayerStartedGame();
				anim.Play ("jump");
				jump = true;
				rigidbody.useGravity = true;
				audiosource.PlayOneShot (sfxJump);
			}
		}

	}
	void FixedUpdate() {
		if (jump == true) {
			jump = false;
			rigidbody.velocity = new Vector2 (0, 0);
			rigidbody.AddForce (new Vector2(0, forceJump) , ForceMode.Impulse);
		}
	}

	void OnCollisionEnter(Collision collision) { // di bta3t L tsadomat 
		if (collision.gameObject.tag == "obstacle") {
			rigidbody.AddForce (new Vector2 (-50, 20), ForceMode.Impulse);
			rigidbody.detectCollisions = false;
			audiosource.PlayOneShot (sfxDead);
			GameManager.instance.setPlayerCollided ();
		}
	}
}
