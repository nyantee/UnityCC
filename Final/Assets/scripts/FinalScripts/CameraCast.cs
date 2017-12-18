using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCast : MonoBehaviour {

	[Range(0,100)]
	public float dist;

	// Use this for initialization
	void Start () {


		dist = 10;
		
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.UpArrow)) {

			transform.rotation = Quaternion.AngleAxis(-1, transform.right) * transform.rotation;


			Debug.Log ("panning up");

		}


		if (Input.GetKeyDown (KeyCode.DownArrow)) {

			transform.rotation = Quaternion.AngleAxis(1, transform.right) * transform.rotation;


			Debug.Log ("panning Down");

		}


	
		
	}


	void FixedUpdate()
	{
		RaycastHit hit;

		if (Physics.Raycast(transform.position, Vector3.forward, out hit, dist))
			print("Found an object - distance: " + hit.distance);


		Debug.DrawLine(transform.position, Vector3.forward, Color.red);

	
	}
}


