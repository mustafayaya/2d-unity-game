using UnityEngine;

public class Player : MonoBehaviour {

	public Rigidbody2D rb;
	public Animator animator;
	public BoxCollider2D box;
	private float velocity = 20f;
	private int health;
	private int score;

	// Use this for initialization
	void Start() {
		animator.SetBool("Grounded", true);
		score = PlayerPrefs.GetInt("Score", 0);
		health = 20;
	}

	public int getHealth(){
		return health;
	}
 	
	public int getScore(){
		return score;
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("d") || Input.GetKey("d")){
		    rb.AddForce(Vector2.right * velocity);
		    animator.SetTrigger("RightKeyPressed");  
		} else if(Input.GetKeyDown("a") || Input.GetKey("a")) {
			rb.AddForce(Vector2.left * velocity);
		    animator.SetTrigger("LeftKeyPressed");  
		} else if(Input.GetKeyUp("a")) { 
			animator.ResetTrigger("LeftKeyPressed");  
		    animator.SetTrigger("Idle2");
		} else if(Input.GetKey("w") && animator.GetBool("Grounded")) {
			rb.AddForce(Vector2.up * 1000);
			animator.SetBool("Grounded", false);	
		} else {
			animator.SetTrigger("Idle");
		}

		if(health <= 0) {
			PlayerPrefs.DeleteAll();
			FindObjectOfType<GameManager>().endGame();
		}

	}

	void OnCollisionEnter2D(Collision2D Other){
         if (Other.collider.gameObject.tag == "platform") {
            animator.SetBool("Grounded", true);
         } else if(Other.collider.gameObject.tag == "cherry") {
         	score += 1;
         	Destroy(Other.gameObject);
         } else if(Other.collider.gameObject.tag == "gem") {
         	score += 10;
         	Destroy(Other.gameObject);
         } else if(Other.collider.gameObject.tag == "house") {
         	PlayerPrefs.SetInt("Score", score);
         } else if (Other.collider.gameObject.tag == "enemy"){
         	if(Other.collider.GetType() == typeof(BoxCollider2D)) {
         		health -= 10;
         	} else if(Other.collider.GetType() == typeof(CircleCollider2D)){
         		score += 5;
         		Destroy(Other.gameObject);
     		}
         } 
    }
}
