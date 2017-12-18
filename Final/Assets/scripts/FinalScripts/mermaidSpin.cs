
using UnityEngine;
using System.Collections;
using Uniduino;


using System.Collections.Generic;




public class mermaidSpin : MonoBehaviour {
	

	public AudioSource collisionSound;
	public ParticleSystem effect;

	public Arduino arduino;

	public int pin = 0;
	public int pinValue;


	private Quaternion startRotation;


	public Camera fpsCam;
	[Range(0,100)]
	public float range;

	void Start (){


		arduino = Arduino.global;
		arduino.Setup(ConfigurePins);

		range = 20;


		collisionSound = GetComponent<AudioSource> ();
		collisionSound.playOnAwake = false;


		//InvokeRepeating("checkArduino", 2.0f, 0.3f);
	}


	void ConfigurePins( )
	{
		arduino.pinMode(pin, PinMode.ANALOG);
		arduino.reportAnalog(pin, 32);
	}
	
	// Update is called once per frame
	void Update () {

		checkArduino ();

		pinValue = arduino.analogRead (pin);

			
		if (pinValue > 100) {

			range = 0;

			Scream ();

		}

		else if (pinValue < 100) {

			range = 100;

			Scream ();

		}
					//transform.rotation = Quaternion.AngleAxis(Time.time, transform.up) * transform.rotation;

	}



	

	void Scream(){

	

	

			RaycastHit hit;
			if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward , out hit, range)) {


				Debug.Log (hit.transform.name);

				Debug.DrawLine (fpsCam.transform.position, fpsCam.transform.forward , Color.red, 3);
//
//				


					Destroy (hit.transform.gameObject);

					collisionSound.Play ();
					effect.Play ();





				;


			}

		}
			




	void checkArduino()
	{
		Debug.Log ("pin val is" + " " + pinValue);
	}



}
