using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipBehavior : MonoBehaviour {


	public Vector3 startPosition;



	[Range(0,1)]
	public float interpolant;


	// Use this for initialization
	void Start () {

		startPosition = transform.position;

		interpolant = Random.Range(0.03f,0.06f);
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.Lerp(startPosition, new Vector3(2f,17f,-30f), Time.time * interpolant);
		
	}



}
