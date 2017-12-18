using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsForce : MonoBehaviour {
    public bool isKinematic = false;

    public Vector3 forceVector;

    //THESE ARE BOTH COMPONENT REFERENCES:
    public VectorDrawer forceVectorSource;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        //read the vector variable from our forceVectorSource component reference
        //Comment this out if you want to set the force vector directly
        //from the public Vector3 variable above
        forceVector = forceVectorSource.vector;

        //get the Rigidbody component attached to this GameObject
        //rb = GetComponent<Rigidbody>();

        //add the force vector to the rigid body ONCE ON START
        //rb.AddForce(forceVector);
    }
	
	// Update is called once per frame
	void Update () {
        //if (Time.time > 5.0f)
        //{
        //    rb.isKinematic = false;
        //}

        //if (Time.time > 6.0f)
        //{
        //    rb.isKinematic = true;
        //}
        forceVector = forceVectorSource.vector;
        //apply the force vector to the rigid body EVERY FRAME
        rb.AddForce(forceVector);
        //rb.AddForceAtPosition(forceVector, transform.position);
    }
}
