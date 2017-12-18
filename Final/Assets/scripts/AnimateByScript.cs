using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateByScript : MonoBehaviour {

    public float step = 1;

    public float startAngle = 0;
    public float endAngle = 180;

    public Transform axisSource;

	// Use this for initialization
	void Start () {
        //transform.Rotate(0, 90, 0);
	}
	
	// Update is called once per frame
	void Update () {
        //VERY SIMPLE, BUT LIMITED
        //transform.Rotate(0, step, 0);

        //MORE LIKE QUATERNION
        //transform.Rotate(transform.right, step);
        //transform.Rotate(axisSource.up, step);

        //THIS MAKES IT SPEED UP
        //transform.Rotate(axisSource.up, Time.time);

        //...BUT THIS MAKES SMOOTH ROTATION
        //transform.Rotate(axisSource.up, Time.deltaTime);

        //WITH THIS, TIME.TIME WORKS, BUT START ROTATION IS ALWAYS SAME
        //transform.rotation = Quaternion.AngleAxis(Time.time*10, axisSource.up);

        //THIS FACTORS IN EXISTING ROTATION WITH QUATERNIONS
        //transform.rotation = Quaternion.AngleAxis(step, axisSource.up) * transform.rotation;

        transform.rotation = Quaternion.AngleAxis(Mathf.Sin(Time.time) * 90, axisSource.up);// * transform.rotation;
        transform.position += Vector3.right * Mathf.Sin(Time.time)*0.1f;

        if (transform.rotation.eulerAngles.y < endAngle)
        {
            transform.rotation = Quaternion.AngleAxis(step, axisSource.up) * transform.rotation;
        }
        
    }
}
