using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {

    public GameObject objectToInstantiate;

    public int numberToInstantiate = 500;

    public AnimationCurve curve = AnimationCurve.Linear(0,0,1,1);

    private int count = 0;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < numberToInstantiate; ++i)
        {
            //objectToInstantiate.transform.localScale = new Vector3(1, Random.value * 10, 1);
            
            //Vector3 instantiateAtPosition = objectToInstantiate.transform.position + objectToInstantiate.transform.forward * Random.value * 10;
            Vector2 randomInCircle = Random.insideUnitCircle;
            Vector3 instantiateAtPosition = objectToInstantiate.transform.position +
                objectToInstantiate.transform.rotation*(new Vector3(randomInCircle.x, 0, randomInCircle.y) *10);
            Quaternion instantiateWithRotation = objectToInstantiate.transform.rotation;//Random.rotation;

            GameObject spawnedObject = Instantiate<GameObject>(
                objectToInstantiate, //original to instantiate from
                instantiateAtPosition,//position
                instantiateWithRotation,//rotation
                transform
            );

            //Vector3 newScale = new Vector3(1, Random.value * 10, 1);
            Vector3 newScale = new Vector3(1, curve.Evaluate(1 - randomInCircle.magnitude) * 10,1);
            spawnedObject.transform.localScale = newScale;
            //spawnedObject.transform.rotation = Random.rotation;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        //SpawnEveryFrame();
    }

    void SpawnEveryFrame()
    {
        if (count > numberToInstantiate)
            return;

        Debug.LogWarning("Instantiating cube " + count);

        Instantiate<GameObject>(
            objectToInstantiate, //original to instantiate from
            objectToInstantiate.transform.position + objectToInstantiate.transform.forward * Random.value * 10,//position
            Random.rotation//,//rotation
                           //objectToInstantiate.transform //set this as parent of the newly instantiated clone
        );

        count++;
    }
}
