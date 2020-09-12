using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;

public class GameOverText : MonoBehaviour {

	public GameObject helicopter;
	private Text text;
	private int coins;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();

		// start text off as completely transparent black
		text.color = new Color(0, 0, 0, 0);
	}

	// Update is called once per frame
	void Update () {
		UnityEngine.Debug.Log("Speed: " + SkyscraperSpawner.speed);
		if (helicopter != null) {
			coins = helicopter.GetComponent<HeliController>().coinTotal;
		}
		else {

			// reveal text only when helicopter is null (destroyed)
			text.color = new Color(0, 0, 0, 1);
			text.text = "Game Over\nYour Score:\n" + coins + " Coins\nPress Space to Restart!";
			
			// jump is space bar by default
			if (Input.GetButtonDown("Jump")) {

				SkyscraperSpawner.speed = 10f; //just before restarting the game, re-initialize the skyscraper speed to 10f again

				// reload entire scene, starting music over again, refreshing score, etc.
				SceneManager.LoadScene("Main");
			}
		}
	}
}
