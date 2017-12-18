using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamCast : MonoBehaviour {


	[Range(0,100)]
	public float dist;
	public bool pressingKey = false;

	// Use this for initialization
	void Start () {

		dist = 50;
		
	}
	
	// Update is called once per frame
	void Update () {




		RaycastHit hit;

		if (Input.GetKeyDown (KeyCode.A)) {

			pressingKey = true;


			if (pressingKey) {


				if (Physics.Raycast (transform.TransformPoint(transform.position), Vector3.forward, out hit, dist)) {

						Debug.Log ("hit something");

					}

				Debug.DrawLine (transform.TransformPoint(transform.position), transform.position + transform.forward, Color.red, 2);

			}

		}


		if (Input.GetKeyUp (KeyCode.A)) {

			pressingKey = false;

		}

	
	}

		
}

