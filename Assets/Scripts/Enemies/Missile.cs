using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(-3,3,1);
		GetComponent<Rigidbody2D>().AddForce(-transform.right*1000);
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D collision) {
		Destroy (this.gameObject);
	}
}
