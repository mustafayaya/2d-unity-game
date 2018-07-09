using UnityEngine;

public class EndLevel : MonoBehaviour {

	public GameManager game;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D Other){
         if (Other.collider.gameObject.tag == "Player") {
            game.completeLevel();
         }
    }
}
