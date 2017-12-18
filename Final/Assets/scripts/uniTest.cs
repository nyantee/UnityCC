using UnityEngine;
using System.Collections;
using Uniduino;

public class uniTest : MonoBehaviour {

	public Arduino arduino;

	public int pin = 0;
	public int pinValue;
	public float spinSpeed = 0.2f;
	public Quaternion startRot;

	private GameObject cube;

	void Start( )
	{
		arduino = Arduino.global;
		arduino.Setup(ConfigurePins);

		cube = GameObject.Find("Cube");

		startRot = cube.transform.rotation;



		InvokeRepeating("LaunchProjectile", 2.0f, 0.3f);

	}

	void ConfigurePins( )
	{
		arduino.pinMode(pin, PinMode.ANALOG);
		arduino.reportAnalog(pin, 1);
	}

	void Update () 
	{       
		pinValue = arduino.analogRead(pin);     
		//cube.transform.rotation = Quaternion.Euler(0,pinValue*spinSpeed,0); 

		cube.transform.rotation = startRot * Quaternion.Euler(0,pinValue*spinSpeed,0); 




	}


	

void LaunchProjectile()
{
	Debug.Log (pinValue*spinSpeed);
}

}