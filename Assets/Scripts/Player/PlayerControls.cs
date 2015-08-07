using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	public float accelerationForce = 2f;
	public float rotationForce = 1f;
	void Update () {
		
		float rotation = Input.GetAxis("Horizontal");
		float acceleration = Input.GetAxis("Vertical");
		if(Mathf.Abs(GetComponent<Rigidbody2D>().angularVelocity)<150)
		GetComponent<Rigidbody2D>().AddTorque(-rotation * rotationForce);
		else {
			if(GetComponent<Rigidbody2D>().angularVelocity>=150)
				GetComponent<Rigidbody2D>().angularVelocity=100;
			if(GetComponent<Rigidbody2D>().angularVelocity<=-150)
				GetComponent<Rigidbody2D>().angularVelocity=-100;
		}
		GetComponent<Rigidbody2D>().AddRelativeForce(transform.right * Mathf.Abs(rotation) * accelerationForce);
		if(rotation==0){
			if(GetComponent<Rigidbody2D>().angularVelocity<0)
				GetComponent<Rigidbody2D>().AddTorque(1f);
			if(GetComponent<Rigidbody2D>().angularVelocity>0)
				GetComponent<Rigidbody2D>().AddTorque(-1f);
		}

		Debug.Log (transform.forward);
	}

}
