using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour {

	public void quit() {
		PlayerPrefs.DeleteAll();
		Application.Quit();
	}

	public void start() {
		PlayerPrefs.DeleteAll();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
	}

}
