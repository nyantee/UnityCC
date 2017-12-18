using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeShips : MonoBehaviour {



	string message = "";

	[Range(3,10)]
	public float life;


	public GameObject[] ships;
	public float spawnRadius;
	public GameObject ship; 
	public GameObject mermaid;
	float dist;

	// Use this for initialization
	void Start ()
	{
		

		spawnRadius = 300;


		for (int i = 0; i < 13; i++) {


			Vector3 spawnPosition = transform.position + new Vector3 (Random.Range (-100f, 100f), 0, Random.Range (-100f, 100f));

			Instantiate<GameObject> (ship, spawnPosition, transform.rotation);
		}

		new WaitForSeconds(5);

		fillArray ();

	}


		
	void fillArray(){
		
		ships = GameObject.FindGameObjectsWithTag("ship");

			Debug.Log(ships.Length);

	}


	void Update (){

		for (int i = 0; i < ships.Length; i++) {

			if (ships [i].gameObject != null) {

				life = 3;
				dist = Vector3.Distance (mermaid.transform.position, ships [i].transform.position);
			
				if (dist < 10) {

					life--;
				}

				if (life == 0) {

					message = "You Lose.";
				}
				

			}

		} 
	}



		

}
