using UnityEngine;
using System.Collections;

public class ControlButtons : MonoBehaviour {

	PlayerControls playerControls;
	Collisions_Sounds collSounds;

	void Start(){
		playerControls = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControls> ();
		collSounds = GameObject.FindGameObjectWithTag ("Player").GetComponent<Collisions_Sounds> ();
	}

	public void TurnRight () {
		playerControls.rotation = 1;
		collSounds.jetpackSound ();
	}

	public void TurnLeft(){
		playerControls.rotation = -1;
		collSounds.jetpackSound ();
	}

	public void Stop(){
		playerControls.rotation = 0;
		playerControls.acceleration = 0;
	}

	public void Accelerate(){
		playerControls.acceleration = 1;
	}

}
