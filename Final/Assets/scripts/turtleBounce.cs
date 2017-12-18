using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleBounce : MonoBehaviour {


	public Vector3 velocity;
	public float speed;
	public bool pressingKey = false;

	//private Vector3 acceleration; // this will be a - y direction movement

	// Use this for initialization
	void Start () {
		//velocity = new Vector3 (0f, 0f, 0f);
		//velocity = new Vector3 (Random.Range(-.1f, .1f), 0f, Random.Range(-.1f, .1f));
		//velocity = Random.insideUnitSphere;
		//acceleration = new Vector3 (0f, -.1f, 0f);
	}

	void Update () {


		if(Input.GetKeyDown(KeyCode.RightArrow))
			pressingKey = true;
			movingTurtle ();


		if(Input.GetKeyUp(KeyCode.RightArrow))
			pressingKey = false;
		}


	void movingTurtle(){
	
		if (pressingKey) {
			this.transform.position += velocity;
		}

		//DO YOU NEED BRACKETS FOR IF STATEMENTS/anything OR NO?

	}

}


//boundsCheck (this.transform.position, target.GetComponent<Bounds>().walls, this.transform.localScale);

//gravitationalMovement ();


//	void boundsCheck(Vector3 checkFrom, Vector3 checkAgainst, Vector3 size){
//		//if this x > box.bounds.rightWall
//		//x = x * -1
//		// if this x < box.bounds.leftWall
//		//x = x * -1
//
//		//x
//		if (checkFrom.x + size.x/2f >= checkAgainst.x / 2f) {
//			velocity.x *= -1f;
//			sfx.Play ();
//
//		}
//		if (checkFrom.x - size.x/2f <= -checkAgainst.x / 2f) {
//			velocity.x *= -1f;
//			print ("I HIT A WALL!!!!");
//		}
//
//		//y
//		if (checkFrom.y + size.y/2f >= checkAgainst.y / 2f) {
//			velocity.y*= -1f;
//			print ("I HIT A WALL!!!!");
//		}
//		if (checkFrom.y - size.y/2f <= -checkAgainst.y / 2f) {
//			velocity.y *= -1f;
//			print ("I HIT A WALL!!!!");
//		}
//
//		//z
//		if (checkFrom.z + size.z/2f >= checkAgainst.z / 2f) {
//			velocity.z*= -1f;
//			print ("I HIT A WALL!!!!");
//		}
//		if (checkFrom.z - size.z/2f <= -checkAgainst.z / 2f) {
//			velocity.z *= -1f;
//			print ("I HIT A WALL!!!!");
//		}
//	}

//	void gravitationalMovement(){
		// kinematic : vel = prevVel + accel * time;
	//	velocity = velocity + acceleration * Time.deltaTime;
	//	print (velocity.y);
	//}
