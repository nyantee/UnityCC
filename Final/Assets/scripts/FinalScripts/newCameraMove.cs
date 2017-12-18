using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCameraMove : MonoBehaviour {



	public bool pressingRKey = false;
	public bool pressingLKey = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per f srame
	void Update () {


		if (Input.GetKeyDown (KeyCode.UpArrow)) {

			transform.rotation = Quaternion.AngleAxis(-1, transform.right) * transform.rotation;


			Debug.Log ("panning up");

		}


		if (Input.GetKeyDown (KeyCode.DownArrow)) {

			transform.rotation = Quaternion.AngleAxis(1, transform.right) * transform.rotation;


			Debug.Log ("panning Down");

		}



		if (Input.GetKeyDown (KeyCode.RightArrow)) {

			pressingRKey = true;
			movingRight ();




		}

		if(Input.GetKeyUp(KeyCode.RightArrow)){
			pressingRKey = false;
		}



		if (Input.GetKeyDown (KeyCode.LeftArrow)) {

			pressingLKey = true;
			movingLeft ();

		}


		if(Input.GetKeyUp(KeyCode.LeftArrow)){
			pressingLKey = false;
		}


	}








	void movingLeft(){

		if (pressingLKey) {
			transform.rotation = Quaternion.AngleAxis(5.0f * (-1), transform.up) * transform.rotation;
		}

		//DO YOU NEED BRACKETS FOR IF STATEMENTS/anything OR NO?

	}


	void movingRight(){

		if (pressingRKey) {
			transform.rotation = Quaternion.AngleAxis(5.0f, transform.up) * transform.rotation;
		}

		//DO YOU NEED BRACKETS FOR IF STATEMENTS/anything OR NO?

	}

		

}
