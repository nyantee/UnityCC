using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbitBounce : MonoBehaviour {


	public enum RotationType
	{
		rotateByStep,
		rotateAdditive,
		rotateAxisAngle,
		quaternionByStep,
		quaternionAdditiveToLastRot,
		quaternionAdditiveToStartRot
	}


	public RotationType rotationType;

	//if you want a slider...
	[Range(0,1)]
	public float step;

	public Vector3 targetPosition;

	private Vector3 startPosition;
	private Quaternion startRotation;

	private Vector3 velocity; 
	public Vector3 drag;
	public float speed;
	public bool pressingKey = false;

	[Range(0,1)]
	public float interpolant;




	//private Quaternion startRotation;

	//private Vector3 acceleration; // this will be a - y direction movement

	// Use this for initialization
	void Start () {

	
		startPosition = transform.position;
		startRotation = transform.rotation;




	}

	void Update () {


		switch (rotationType)
		{
		case RotationType.rotateByStep:
			//THIS ADDS THE SAME ANGLE VALUE TO THE PREVIOUS ROTATION EVERY FRAME
			//transform.Rotate(0, step, 0);
			transform.Rotate(0, Time.deltaTime*60, 0);
			break;
		case RotationType.rotateAdditive:
			//THIS ADDS AN INCREASING ANGLE VALUE TO THE ROTATION EVERY FRAME
			transform.Rotate(0, Time.time, 0);
			break;
		case RotationType.quaternionByStep:
			//THIS ADDS THE SAME ANGLE VALUE TO THE PREVIOUS ROTATION EVERY FRAME
			transform.rotation = Quaternion.AngleAxis(step, transform.up) * transform.rotation;
			//transform.rotation = Quaternion.AngleAxis(step, axisOfRotation.up) * transform.rotation;
			break;
		case RotationType.quaternionAdditiveToLastRot:
			//THIS SETS TO ROTATION TO AN INCREASING ANGLE VALUE AROUND THE GIVEN AXIS EVERY FRAME,
			//ADDING THAT TO THE PREVIOUS FRAME'S ROTATION
			//transform.rotation = Quaternion.AngleAxis(Time.time, axisOfRotation.up) * transform.rotation;
			transform.rotation = Quaternion.AngleAxis(Time.time, transform.up) * transform.rotation;
			break;
		case RotationType.quaternionAdditiveToStartRot:
			//THIS SETS THE ROTATION TO AN INCREASING ANGLE VALUE AROUND THE GIVEN AXIS EVERY FRAME,
			//BUT ALWAYS ADDS THAT TO THE OBJECT'S ROTATION FROM THE VERY FIRST FRAME
			transform.rotation = Quaternion.AngleAxis(Time.time, transform.up) * startRotation;
			break;
		default:
			break;
		}

	


	
		if(Input.GetKeyDown(KeyCode.RightArrow))


			pressingKey = true;
			movingRabbit ();


		if(Input.GetKeyUp(KeyCode.RightArrow))
			

			pressingKey = false;
			movingRabbit ();

		}


	void movingRabbit(){

		if (pressingKey) {
			
			transform.position = Vector3.Lerp(startPosition, targetPosition, Time.time * interpolant);
			transform.Rotate(0, Time.deltaTime*80, 0);

			//rotate really fast then slow 
		}

		if (!pressingKey) {

			transform.position = Vector3.Slerp(startPosition, targetPosition, Time.time * 0.2f);


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
