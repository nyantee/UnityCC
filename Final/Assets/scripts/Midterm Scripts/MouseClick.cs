using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour {

	// Use this for initialization

	public float distance = 5.0f;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		Vector3 mousePosition = Input.mousePosition;

		mousePosition.z = distance;


			transform.position = Camera.main.ScreenToWorldPoint (mousePosition);

	



	}
		

}
