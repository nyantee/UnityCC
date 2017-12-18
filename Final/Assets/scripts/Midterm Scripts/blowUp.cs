using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blowUp : MonoBehaviour {



	// Use this for initialization
	void Start (){



	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown ("space")) {


			transform.localScale += new Vector3 (0.5f, 0.5f, 0.5f);
		
		}
	}


}
