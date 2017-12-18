using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumping : MonoBehaviour {



	public AudioSource bumpNoise;


	// Use this for initialization
	void Start () {

		bumpNoise = GetComponent<AudioSource> ();
		bumpNoise.playOnAwake = false;


	
		
	}
	
	// Update is called once per frame
	void Update () {



		
	}


	void OnCollisionEnter (Collision otherBalloon)  //Plays Sound Whenever collision detected
	{


		if (otherBalloon.gameObject.tag == "target") {


			// otherBalloon.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
	
			Debug.Log ("please work");
			bumpNoise.Play ();



		} else {

			bumpNoise.Stop ();

		}




	}
		
	





//	void OnCollisionExit ()  //Plays Sound Whenever collision detected
//	{
//		bumpNoise.Stop ();
//	}
//

}
