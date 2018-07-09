using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	public Animator anim;

	public void loadNext() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}



}
