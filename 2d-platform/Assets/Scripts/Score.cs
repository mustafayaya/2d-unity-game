using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Player player;
	public Text scoreAndHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		scoreAndHealth.text = "Score: " + player.getScore().ToString() + "\nHealth: " + player.getHealth().ToString(); 
		
	}
}
