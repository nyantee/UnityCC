using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour {

    public GameObject objectToInstantiate;
    public int numberToInstantiate = 500;
    public Gradient gradient;

    public float maxSpeed = 10;

    Rigidbody[] spawnedObjectRigidBodies;
    MeshRenderer[] spawnedObjectMeshRenderers;

    // Use this for initialization
    void Start () {
		
        for (int i = 0; i < numberToInstantiate; ++i)
        {
            Vector3 SpawnPos = transform.position+Random.insideUnitSphere;
            Quaternion SpawnRot = transform.rotation;

            Instantiate<GameObject>(objectToInstantiate,SpawnPos,SpawnRot,transform);
        }

        spawnedObjectRigidBodies = GetComponentsInChildren<Rigidbody>();
        spawnedObjectMeshRenderers = GetComponentsInChildren<MeshRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
		
        for (int i = 0; i < spawnedObjectRigidBodies.Length; ++i)
        {
            spawnedObjectRigidBodies[i].AddForce(transform.position - spawnedObjectRigidBodies[i].transform.position);
            float speed = spawnedObjectRigidBodies[i].velocity.sqrMagnitude;
            Color newColor = gradient.Evaluate(speed/maxSpeed);

            //spawnedObjectRigidBodies[i].transform.GetComponent<MeshRenderer>().material.SetColor("_Color", newColor);

            //This is more efficient than the above line... I stored the Mesh renderers in an array on start along with the rigidbodies;
            //Then I don't have to call GetComponent every frame; but I've added the if statement below in case 
            //there are fewer meshRenderers than rigidbodies for some reason
            if (i < spawnedObjectMeshRenderers.Length)
            {
                spawnedObjectMeshRenderers[i].material.SetColor("_Color", newColor);
            }
            
        }
	}
}
