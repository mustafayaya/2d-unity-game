using UnityEngine;

public class QuitGame : MonoBehaviour {

	public void quit() {
		PlayerPrefs.DeleteAll();
		Application.Quit();
	}

}
