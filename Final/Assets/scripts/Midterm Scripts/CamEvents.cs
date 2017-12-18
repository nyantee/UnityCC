using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamEvents : MonoBehaviour {

	public Camera[] cams;

	public void camMainMove(){


		cams[0].enabled = true;
		cams[1].enabled = false;
		cams[2].enabled = false;
		cams[3].enabled = false;

	}
		
	public void camTwoMove(){

		cams[0].enabled = false;
		cams[1].enabled = true;
		cams[2].enabled = false;
		cams[3].enabled = false;

	}


	public void camThreeMove(){


		cams[0].enabled = false;
		cams[1].enabled = false;
		cams[2].enabled = true;
		cams[3].enabled = false;

	}


	public void camFourMove(){

		cams[0].enabled = false;
		cams[1].enabled = false;
		cams[2].enabled = false;
		cams[3].enabled = true;

	}


}
