using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private bool gameEnded;
	public GameObject endLevel;

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
			Invoke("restart", 2f);
		}
	}

	public void restart() {
		gameEnded = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
