using UnityEngine;

public class Player : MonoBehaviour {

	public Rigidbody2D rb;
	public Animator animator;
	public BoxCollider2D box;
	private float velocity = 20f;
	private int health;
	private int score;
	public float left;
    public float right;
    public float top;

	// Use this for initialization
	void Start() {
		animator.SetBool("Grounded", true);
		score = PlayerPrefs.GetInt("Score", 0);
		health = 50;
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

		if(transform.position.x <= left) {
			transform.position = new Vector3(left, transform.position.y, transform.position.z);
		}
		if(transform.position.x >= right) {
			transform.position = new Vector3(right, transform.position.y, transform.position.z);
		}
		if(transform.position.y >= top) {
			transform.position = new Vector3(transform.position.x, top, transform.position.z);
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
         	score += 5;
         	Other.gameObject.GetComponent<Animator>().SetTrigger("ItemCaught");
         	Destroy(Other.gameObject, 0.2f);
         } else if(Other.collider.gameObject.tag == "gem") {
         	score += 10;
         	Other.gameObject.GetComponent<Animator>().SetTrigger("ItemCaught");
         	Destroy(Other.gameObject, 0.2f);
         } else if(Other.collider.gameObject.tag == "house") {
         	PlayerPrefs.SetInt("Score", score);
         } else if (Other.collider.gameObject.tag == "enemy"){
         	if(Other.collider.GetType() == typeof(BoxCollider2D)) {
         		health -= 10;
         	} else if(Other.collider.GetType() == typeof(CircleCollider2D)){
         		score += 15;
         		Other.gameObject.GetComponent<Animator>().SetTrigger("EnemyDeath");
         		Destroy(Other.gameObject, 0.5f);
     		}
         } 
    }
}
