using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    //These are built-in unity functions that fire when a trigger is entered or exited.
    //NOTE: When using OnTriggerEnter, you must check "is Trigger" in your collider component.
    //Otherwise, use OnCollisionEnter !
    //Also one of the objects involved in the collision MUST have a Rigidbody attached, and both need colliders!
    private void OnTriggerEnter(Collider other)
    {
        Color newColor = Color.black;
        other.transform.GetComponent<MeshRenderer>().material.SetColor("_Color", newColor);
    }

    private void OnTriggerExit(Collider other)
    {
        Color newColor = Color.white;
        other.transform.GetComponent<MeshRenderer>().material.SetColor("_Color", newColor);
    }
}
