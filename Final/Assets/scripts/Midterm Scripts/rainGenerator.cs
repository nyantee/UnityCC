using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainGenerator : MonoBehaviour {



	public GameObject rain;
	// Use this for initialization
	void Start () {




		for (int i = 0; i < 20; i++) {


			Instantiate(rain, new Vector3(Random.Range(-100,100), Random.Range(0,30),0), Quaternion.identity);



		}
		
	}


	
	// Update is called once per frame
	void Update () {


		for (int i = 0; i < 20; i++) {


			Instantiate(rain, new Vector3(Random.Range(-100,100), Random.Range(100,150),0), Quaternion.identity);



		}

		
	}
}
