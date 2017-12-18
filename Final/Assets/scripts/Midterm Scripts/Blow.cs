using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blow : MonoBehaviour {

	public Vector3 wind;

	public Camera YourCamera;




	// Use this for initialization
	void Start () {



		
	}
	
	// Update is called once per frame
	void Update () {


		
	}


void FixedUpdate(){


		//Ray mouse = Camera.main.ScreenPointToRay (Input.mousePosition), Vector3.forward);


		//Ray ray = ;

//
//		RaycastHit target;
//
//		if (Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition), out target, 200)) {
//
//
//			target.rigidbody.AddForce(new Vector3(20,0,0));
//
//			Debug.Log ("you did it!");
//
//
//		}

		RaycastHit info;
		Ray ray = YourCamera.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out info, 1000)){


			if (info.rigidbody != null) {

				Debug.Log ("something happened");
		
				info.rigidbody.AddForce (wind);


			}
		
		}

		else{

			Debug.Log ("it stopped");





	
		}



}


}