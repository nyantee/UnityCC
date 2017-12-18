using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerTurn : MonoBehaviour {


	public enum RotationType
	{
		rotateByStep,
		rotateAdditive,
		rotateAxisAngle,
		quaternionByStep,
		quaternionZ,
		quaternionAdditiveToStartRot
	}


	public RotationType rotationType;

	//if you want a slider...
	[Range(0,1)]
	public float step = 1;

	[Range(0,100)]
	public float angle;

	//public Vector3 targetPosition;
	//private Vector3 startPosition;

	private Quaternion startRotation;

	// Use this for initialization
	void Start () {

		startRotation = transform.rotation;

	}
	
	// Update is called once per frame
	void Update () {



		
		switch (rotationType)
		{
		case RotationType.rotateByStep:
			//THIS ADDS THE SAME ANGLE VALUE TO THE PREVIOUS ROTATION EVERY FRAME
			//transform.Rotate(0, step, 0);
			transform.Rotate (0, angle, 0);

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
		case RotationType.quaternionZ:
			//THIS SETS TO ROTATION TO AN INCREASING ANGLE VALUE AROUND THE GIVEN AXIS EVERY FRAME,
			//ADDING THAT TO THE PREVIOUS FRAME'S ROTATION
			//transform.rotation = Quaternion.AngleAxis(Time.time, axisOfRotation.up) * transform.rotation;
			transform.rotation = Quaternion.AngleAxis(20, transform.forward) * transform.rotation;
			break;
		case RotationType.quaternionAdditiveToStartRot:
			//THIS SETS THE ROTATION TO AN INCREASING ANGLE VALUE AROUND THE GIVEN AXIS EVERY FRAME,
			//BUT ALWAYS ADDS THAT TO THE OBJECT'S ROTATION FROM THE VERY FIRST FRAME
			transform.rotation = Quaternion.AngleAxis(Time.time, transform.up) * startRotation;
			break;
		default:
			break;
		}
	}
}
