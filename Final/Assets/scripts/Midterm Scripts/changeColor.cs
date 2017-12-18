using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



	}


	void OnCollisionEnter (Collision otherDrop)  //Plays Sound Whenever collision detected
	{


	



		if (otherDrop.gameObject.tag == "blue") {

			Renderer rend = GetComponent<Renderer>();

			rend.material.SetColor("_Color", Color.red);



		} 








	}
}
