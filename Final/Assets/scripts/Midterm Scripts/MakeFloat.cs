using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeFloat : MonoBehaviour {


	public Vector3 forceVector;

	//THESE ARE BOTH COMPONENT REFERENCES:

	public Rigidbody rb;

	// Use this for initialization
	void Start () {


	
	
	}

	// Update is called once per frame
	void Update () {


		rb.AddForce(forceVector);


	
	}
}
