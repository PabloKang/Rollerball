using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	private Rigidbody r_body;
	private int count;

	public float speed;
	public Text countText;
	public Text winText;

	// Initializes the script
	void Start() 
	{
		r_body = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	// Physics Update is called once per frame
	void FixedUpdate () 
	{
		// If any key is being pressed...
		if (Input.anyKey) {
			float moveX = Input.GetAxis("Horizontal");
			float moveY = 0.0f;
			float moveZ = Input.GetAxis("Vertical");

			Vector3 movement = new Vector3(moveX, moveY, moveZ);

			r_body.AddForce(movement * speed);
		}
	}

	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			SetCountText();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You win!";
		}
	}
}
