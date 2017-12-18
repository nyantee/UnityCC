using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStreamer : MonoBehaviour {

	public GameObject objectToInstantiate;
	// Use this for initialization
	void Start () {



		for (int i = 0; i < 20; ++i)
		{


		
			Vector3 SpawnPos = transform.position;

			SpawnPos.x =+ i; 

			Quaternion SpawnRot = transform.rotation;

			Instantiate<GameObject>(objectToInstantiate,SpawnPos,SpawnRot,transform);




		}
		
	}


	
	// Update is called once per frame
	void Update () {
		
	}
}
