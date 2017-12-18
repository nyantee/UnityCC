using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationComponent : MonoBehaviour {

    //public Transform axisOfRotation;

    //this is an enum
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
    public float step = 1;

    public Vector3 targetPosition;

    private Vector3 startPosition;
    private Quaternion startRotation;

	void Start () {
        //transform.rotation = Quaternion.Euler(0,45,0);
        //transform.Rotate(new Vector3(0, 45, 0));
        //transform.Rotate(0, 45, 0);

        startPosition = transform.position;
        startRotation = transform.rotation;
        

        //transform.position = targetPosition;
	}
	

	void Update () {

        //************ rotation stuff **************

        //IF YOU WANT TO INCREMENT STEP SO IT BEHAVES LIKE Time.time...
        //step = step + 1*Time.deltaTime;

        //(INSTEAD OF AN if(){}/else(){} STATEMENT LIKE THIS..

        //if (rotationType == RotationType.rotateByStep)
        //{
        //    transform.Rotate(0, step, 0);
        //}

        //WE'LL USE A switch(){}:
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
            case RotationType.rotateAxisAngle:
                //THIS IS SUPPOSED TO ROTATE BY THE SAME ANGLE VALUE 
                //AROUND THE GIVEN AXIS EVERY FRAME, BUT DOESN'T WORK RIGHT
                transform.Rotate(transform.up, step);
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
                
                break;
            default:
                break;
        }

        //************ interpolation stuff **************

        //THIS INTERPOLATES BETWEEN START POSITION AND TARGET POSITION BY T
        //WHATEVER FRACTION/PERCENTAGE OF 1 T IS ON A GIVEN FRAME, 
        //THAT'S WHERE THE TRANSFORM POSITION WILL MOVE TO --
        //E.G. t = 0.5 means the position is set to halfway between startPos and targetPos
        transform.position = Vector3.Lerp(startPosition, targetPosition, Time.time * 0.1f);// Mathf.Sin(Time.time)*0.5f+0.5f);

        //THIS DOES THE SAME THING, BUT UPDATES THE START POSITION
        //TO THE BE THE POSITION FROM THE LAST FRAME EVERY FRAME, 
        //CREATING A 'SLOWING DOWN' EFFECT AS IT APPROACHES THE END POSITION
        //transform.position = Vector3.Lerp(transform.position, targetPosition,Time.time*0.1f);

        //THIS 'SPHERICALLY' INTERPOLATES BETWEEN TWO ROTATIONS
        //transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
    }
}
