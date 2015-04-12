using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public float jumpSpeed;

	Rigidbody2D playerRigidBody;

	Vector2 movement, jumpMovement;

	public bool floorCheck;


	void Awake ()
	{
		playerRigidBody = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate ()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		Move (h);

		Jump(v);
	}

	void Move (float h)
	{
		movement.Set (h*speed, playerRigidBody.velocity.y);
		
		playerRigidBody.velocity = movement;

	}


	void Jump (float v){

		if( v > 0f && floorCheck == true){ 

			floorCheck =false;

			jumpMovement.Set (playerRigidBody.velocity.x, v*jumpSpeed) ;

			playerRigidBody.velocity = jumpMovement ;

		}


	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Floor") { floorCheck = true; }

	}

}

