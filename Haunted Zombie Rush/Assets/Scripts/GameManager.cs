using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null; // Singletone Pattern

	private bool palyerActive = false;
	private bool gameOver = false;
	private bool gameStarted = false;

	[SerializeField] private GameObject mainMenu;


	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != null) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject); // di 3l4an L Object yfdl mkml m3ak fi kol L Scenes
		Assert.IsNotNull (mainMenu);
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void setPlayerStartedGame() {
		palyerActive = true;
	}
	public bool  getPlayerActive() {
		return palyerActive;
	}



	public void setPlayerCollided() {
		gameOver = true;
	}
	public bool getGameOver() {
		return gameOver;
	}



	public void setGameStarted() {
		mainMenu.SetActive (false);
		gameStarted = true;
	}
	public bool getGameStarted() {
		return gameStarted;
	}

}
