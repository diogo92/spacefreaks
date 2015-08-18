using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {


	AudioSource audio;
	public GameObject zap;
	public bool thrust = true; //Se pode usar o thrust
	public bool shoot = true;

	public float rotation = 0;
	public float acceleration = 0;
	void Start() {
		audio = gameObject.AddComponent < AudioSource > ();
	}
	void Update () {

		/*
		 * 
		 * Fisicas e animacoes relacionadas com movimento
		 *
		 */

		// Rotacoes
		if (rotation < 0) {
			GetComponent<Animator> ().SetTrigger ("Right");
		}
		if (rotation > 0) {
			GetComponent<Animator> ().SetTrigger ("Left");
		}
		if(Mathf.Abs(GetComponent<Rigidbody2D>().angularVelocity)<50)
		GetComponent<Rigidbody2D>().AddTorque(-rotation);

		//Limitar velocidade de rotacao
		else {
			if(GetComponent<Rigidbody2D>().angularVelocity>=50)
				GetComponent<Rigidbody2D>().angularVelocity=25;
			if(GetComponent<Rigidbody2D>().angularVelocity<=-50)
				GetComponent<Rigidbody2D>().angularVelocity=-25;
		}

		//Aceleracao
		if (acceleration != 0) {
			if(thrust){
				GetComponent<Rigidbody2D>().AddForce(transform.right * 100f);
				GetComponent<Animator>().SetTrigger("Thrust");
				audio.PlayOneShot((AudioClip)Resources.Load("sfx_move"));
				StartCoroutine(thrustCooldown());
			}
		}

		//Retirar torque
		if(rotation==0){
			if(GetComponent<Rigidbody2D>().angularVelocity<0)
				GetComponent<Rigidbody2D>().AddTorque(1f);
			if(GetComponent<Rigidbody2D>().angularVelocity>0)
				GetComponent<Rigidbody2D>().AddTorque(-1f);
		}


		//Disparar
		if(Input.GetKeyDown(KeyCode.LeftControl)){
			Shoot();
		}


	}

	//Cooldown para thrust
	IEnumerator thrustCooldown(){
		thrust = false;
		yield return new WaitForSeconds (2f);
		thrust = true;
	}


	//Disparar projetil	
	public void Shoot(){
		if (shoot) {
			Transform playerTransf = GetComponent<Rigidbody2D> ().transform;
			GameObject shot = (GameObject)Instantiate (zap, playerTransf.position - playerTransf.up, Quaternion.identity);
			shot.GetComponent<Rigidbody2D> ().AddForce (-transform.up * 500);
			StartCoroutine(shootCooldown());
		}

	}

	//Cooldown para projetil 

	IEnumerator shootCooldown(){
		shoot = false;
		yield return new WaitForSeconds (1f);
		shoot = true;

	}

}
