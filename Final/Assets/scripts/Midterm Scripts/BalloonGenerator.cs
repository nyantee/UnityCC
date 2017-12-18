using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonGenerator : MonoBehaviour {


	public GameObject redBalloon;
	public GameObject blueBalloon;



	// Use this for initialization
	void Start () {




		for (int i = 0; i < 20; i++) {


			Instantiate(redBalloon, new Vector3(-230,Random.Range(-100,100),0), Quaternion.identity);

			Instantiate(blueBalloon, new Vector3(-150,Random.Range(-100,100),0), Quaternion.identity);



		}
			

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
