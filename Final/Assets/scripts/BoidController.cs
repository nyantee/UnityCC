using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour {

    public int numberOfBoids = 50;
    public GameObject boidPrefab;
    public float spawnRadius = 2;

    //THESE VARIABLES NOW ADJUST BEHAVIOR OF ALL BOIDS IN THE FLOCK
    [Header("Boid Motion Variables")]
    public float maxSpeed = 0.1f;
    public float maxTurn = 0.01f;
    [Header("Focking Tuning Variables")]
    public float groupingStrength = 1;
    public float spacingStrength = 0.1f;
    public float spacingRadius = 1;
    public float facingStrength = 1;
    [Space]
    public bool drawDebug = false;

    [HideInInspector]
    public Transform[] boids;

	void Start () {
        //initialize the array where we will store references to all the boids so they can react to each other
        boids = new Transform[numberOfBoids];

        //Run a loop on Start to do all of the following...
		for (int i = 0; i < numberOfBoids; ++i)
        {
            //get a random spawn position in a sphere around the controller's location
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;

            //spawn/instantiate a new boid at that position with a random rotation
            GameObject newBoid = Instantiate<GameObject>(boidPrefab, spawnPosition, Random.rotation);

            //store a reference to us (the controller) in the newly created boid, so it can access all our variables
            //(including the array of all boid transforms)
            newBoid.GetComponent<BoidBehavior>().controller = this;

            //store a reference to the newly created boid's transform in our array of boids
            boids[i] = newBoid.transform;
        }
	}
	
}
