using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private bool gameEnded;
	public GameObject endLevel;
	public GameObject gameOver;

	// Use this for initialization
	void Start () {

		gameEnded = false;
		
	}

	public void completeLevel() {
		endLevel.SetActive(true);
	}

	public void endGame() {
		if(!gameEnded) {
			gameEnded = true;
			gameOver.SetActive(true);
			Invoke("restart", 0.85f);
		}
	}

	public void restart() {
		gameOver.SetActive(false);
		gameEnded = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
