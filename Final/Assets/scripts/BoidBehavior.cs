using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidBehavior : MonoBehaviour {

    //WE MOVED ALL THIS INTO THE BOID CONTROLLER SO WE CAN ADJUST FOR ALL BOIDS AT ONCE
    //public Transform target;
    //[Header("Boid Motion Variables")]
    //public float maxSpeed = 0.1f;
    //public float maxTurn = 0.01f;
    //[Header("Focking Tuning Variables")]
    //public float groupingStrength = 1;
    //public float spacingStrength = 0.1f;
    //public float spacingRadius = 1;
    //public float facingStrength = 1;
    //[Space]
    //public bool drawDebug = false;

    [HideInInspector]
    public BoidController controller;

    //OUR 3 BEHAVIORS / DESIRES OF EACH BOID, DEFINED BY A VECTOR
    private Vector3 groupingVector; //cohesion
    private Vector3 spacingVector; //separation
    private Vector3 facingVector; //alignment

    //OUR CURRENT VELOCITY, UPDATED EACH FRAME
    private Vector3 currentVelocity;
	
	void Start () {
        //initialize current velocity
        currentVelocity = transform.forward*controller.maxSpeed;
        transform.position += currentVelocity;
	}
	
	
	void Update () {
        //create a desired velocity vector for this frame, set it to zero
        Vector3 desiredVelocity = Vector3.zero;

        //clear all of our behavior vectors, so leftover data from last frame isn't there
        groupingVector = Vector3.zero;
        spacingVector = Vector3.zero;
        facingVector = Vector3.zero;

        //create a variable to keep track of how many boids are within our spacing / facing radius
        int nearFishCount = 1;

        //loop through all the boids and get behavior vectors for each, then add them together into cumulative vectors that we will average
        for (int i = 0; i < controller.boids.Length; ++i)
        {
            //set the boid at this index of the loop as our current target
            Transform target = controller.boids[i];

            //make sure we're not comparing to ourselves!!
            if (target == transform)
                continue; //continue means just skip from here to the next iteration / index of the loop

            //get a grouping vector for the boid we're currently comparing to...
            Vector3 tempGrouping = (target.position - transform.position);
            //...and add it to the total grouping vector (aggregate of vector to all other boids)
            groupingVector += tempGrouping*controller.groupingStrength;

            //distance to current target boid is the LENGTH/MAGNITUDE of the vector from us to them
            float distanceToTarget = tempGrouping.magnitude;
            //if the distance to current target boid is within the radius where we care about spacing and facing behaviors...
            if (distanceToTarget < controller.spacingRadius)
            {
                //add to the count of boids we're within spacing/facing distance of
                nearFishCount++;
                //get vector pointing AWAY from current target boid (toward us)...inverse of the grouping vector to current target boid
                Vector3 tempSpacing = tempGrouping * -1;
                //add the spacing vector for the current target boid to the aggregate spacing vector for ALL boids we're near
                spacingVector += (tempSpacing / distanceToTarget)*controller.spacingStrength;
                //do the same for facing / alignment ... add current target boid's vector to all others within range
                facingVector += target.forward*controller.facingStrength;
            }
        }

        //get the AVERAGE of each of our vectors by dividing each by the total number of boids we were comparing to for that behavior
        //(or else all of these vectors would be HUGE)
        groupingVector = groupingVector / controller.boids.Length;
        spacingVector = spacingVector / nearFishCount;
        facingVector = facingVector / nearFishCount;

        //combine these total aggregated vectors, compiled from comparison to all other boids, together to get our desired velocity
        desiredVelocity = groupingVector + spacingVector + facingVector;

        //for turning on debug vectors
        if (controller.drawDebug)
        {
            Debug.DrawRay(transform.position, desiredVelocity, Color.red, 0.1f);
        }
        
        //clamp our desired velocity by maxSpeed, limiting how fast we move along that vector
        desiredVelocity = Vector3.ClampMagnitude(desiredVelocity, controller.maxSpeed);
        //lerp between the direction we're current going and the direction we WANT to go, to create smoother / more realistic turning behavior
        currentVelocity = Vector3.Lerp(currentVelocity, desiredVelocity, controller.maxTurn);

        //add the final, clamped/smoothed vector to our current position...
        transform.position += currentVelocity;
        //and rotate us to face in the direction we're currently moving
        transform.rotation = Quaternion.LookRotation(currentVelocity, Vector3.up);

        //*****************************************
        //THIS IS THE OLD CODE FOR DOING THE ABOVE WITH A *SINGLE* TARGET TO COMPARE TO //
        ////get a vector pointing from us to target
        //groupingVector = target.position - transform.position;
        ////add this vector to our desired velocity, scaled by strength var
        //desiredVelocity += groupingVector * groupingStrength;

        ////find distance to target
        //float distanceToTarget = groupingVector.magnitude;
        //if (distanceToTarget < spacingRadius)
        //{
        //    //if we're within radius to avoid other boids, find spacing Vector
        //    spacingVector = groupingVector * -1;
        //    spacingVector = spacingVector / distanceToTarget;
        //    //add spacing/separation vector to desired velocity, scaling by strength var
        //    desiredVelocity += spacingVector*spacingStrength;
        //    //find the direction our target is facing
        //    facingVector = target.forward;
        //    //add facing/alignment vector to desired velocity, scaling by strength var
        //    desiredVelocity += facingVector * facingStrength;
        //}
        //*****************************************
    }
}
