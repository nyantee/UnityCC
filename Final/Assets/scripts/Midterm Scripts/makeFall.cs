using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeFall : MonoBehaviour {


	public Vector3 forceVector;

	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		rb.AddForce(forceVector);
		
	}
}
